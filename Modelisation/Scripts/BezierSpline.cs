using UnityEngine;
using System;

public class BezierSpline : MonoBehaviour {

	[SerializeField]
	private Vector3[] points;

	[SerializeField]
	private BezierControlPointMode[] modes;

	[SerializeField]
	private bool loop;
	public bool Loop {
		get {
			return loop;
		}
		set {
			loop = value;
			if (value == true) {
				modes[modes.Length - 1] = modes[0];
				SetControlPoint(0, points[0]);
			}
		}
	}

	[SerializeField]
	private bool isRand;
	public bool IsRand {
		get {
			return isRand;
		}
		set {
			isRand = value;
		}
	}

	[SerializeField]
	private float width;
	public float Width {
		get {
			return width;
		}
		set {
			width = value;
		}
	}

	[SerializeField]
	private int nbBezier;
	public int NbBezier{
		get{
			return nbBezier;
		}
		set {
			nbBezier = value;
		}
	}

	[SerializeField]
	private BezierControlPointMode modeAlea;
	public BezierControlPointMode ModeAlea {
		get {
			return modeAlea;
		}
		set {
			modeAlea = value;
		}
	}
		
	public int ControlPointCount {
		get {
			return points.Length;
		}
	}

	public Vector3 GetControlPoint (int index) {
		return points[index];
	}

	public void SetControlPoint (int index, Vector3 point) {
		if (index % 3 == 0) {
			Vector3 delta = point - points[index];
			if (loop) {
				if (index == 0) {
					points[1] += delta;
					points[points.Length - 2] += delta;
					points[points.Length - 1] = point;
				}
				else if (index == points.Length - 1) {
					points[0] = point;
					points[1] += delta;
					points[index - 1] += delta;
				}
				else {
					points[index - 1] += delta;
					points[index + 1] += delta;
				}
			}
			else {
				if (index > 0) {
					points[index - 1] += delta;
				}
				if (index + 1 < points.Length) {
					points[index + 1] += delta;
				}
			}
		}
		points[index] = point;
		EnforceMode(index);
	}

	public BezierControlPointMode GetControlPointMode (int index) {
		return modes[(index + 1) / 3];
	}

	public void SetControlPointMode (int index, BezierControlPointMode mode) {
		int modeIndex = (index + 1) / 3;
		modes[modeIndex] = mode;
		if (loop) {
			if (modeIndex == 0) {
				modes[modes.Length - 1] = mode;
			}
			else if (modeIndex == modes.Length - 1) {
				modes[0] = mode;
			}
		}
		EnforceMode(index);
	}

	private void EnforceMode (int index) {
		int modeIndex = (index + 1) / 3;
		BezierControlPointMode mode = modes[modeIndex];
		if (mode == BezierControlPointMode.Free || !loop && (modeIndex == 0 || modeIndex == modes.Length - 1)) {
			return;
		}

		int middleIndex = modeIndex * 3;
		int fixedIndex, enforcedIndex;
		if (index <= middleIndex) {
			fixedIndex = middleIndex - 1;
			if (fixedIndex < 0) {
				fixedIndex = points.Length - 2;
			}
			enforcedIndex = middleIndex + 1;
			if (enforcedIndex >= points.Length) {
				enforcedIndex = 1;
			}
		}
		else {
			fixedIndex = middleIndex + 1;
			if (fixedIndex >= points.Length) {
				fixedIndex = 1;
			}
			enforcedIndex = middleIndex - 1;
			if (enforcedIndex < 0) {
				enforcedIndex = points.Length - 2;
			}
		}

		Vector3 middle = points[middleIndex];
		Vector3 enforcedTangent = middle - points[fixedIndex];
		if (mode == BezierControlPointMode.Aligned) {
			enforcedTangent = enforcedTangent.normalized * Vector3.Distance(middle, points[enforcedIndex]);
		}
		points[enforcedIndex] = middle + enforcedTangent;
	}

	public int CurveCount {
		get {
			return (points.Length - 1) / 3;
		}
	}

	public Vector3 GetPoint (float t) {
		int i;
		if (t >= 1f) {
			t = 1f;
			i = points.Length - 4;
		}
		else {
			t = Mathf.Clamp01(t) * CurveCount;
			i = (int)t;
			t -= i;
			i *= 3;
		}

		return transform.TransformPoint(Bezier.GetPoint(points[i], points[i + 1], points[i + 2], points[i + 3], t));
	}
	
	public Vector3 GetVelocity (float t) {
		int i;
		if (t >= 1f) {
			t = 1f;
			i = points.Length - 4;
		}
		else {
			t = Mathf.Clamp01(t) * CurveCount;
			i = (int)t;
			t -= i;
			i *= 3;
		}
		return transform.TransformPoint(Bezier.GetFirstDerivative(points[i], points[i + 1], points[i + 2], points[i + 3], t)) - transform.position;
	}
	
	public Vector3 GetDirection (float t) {
		return GetVelocity(t).normalized;
	}

	public void AddCurve () {
		Vector3 point = points[points.Length - 1];
		Array.Resize(ref points, points.Length + 3);
		point.x += 1f;
		points[points.Length - 3] = point;
		point.x += 1f;
		points[points.Length - 2] = point;
		point.x += 1f;
		points[points.Length - 1] = point;

		Array.Resize(ref modes, modes.Length + 1);
		modes[modes.Length - 1] = modes[modes.Length - 2];
		EnforceMode(points.Length - 4);

		if (loop) {
			points[points.Length - 1] = points[0];
			modes[modes.Length - 1] = modes[0];
			EnforceMode(0);
		}
	}
	
	public void Reset () {
		points = new Vector3[] {
			new Vector3(1f, 0f, 0f),
			new Vector3(2f, 0f, 0f),
			new Vector3(3f, 0f, 0f),
			new Vector3(4f, 0f, 0f)
		};
		modes = new BezierControlPointMode[] {
			BezierControlPointMode.Free,
			BezierControlPointMode.Free
		};
		isRand = false;
		nbBezier = 1;
		modeAlea = BezierControlPointMode.Free;
	}

	public void RandBezier() {
		Vector3 begin = points [0];
		Vector3 end = points [this.ControlPointCount - 1];
		System.Random alea = new System.Random();
		double delta = 0.000001;

		//On calcul le vecteur normal donnant la direction de begin->end
		Vector3 director = new Vector3(end.x - begin.x,end.y - begin.y,end.z - begin.z);
		double norme = Math.Sqrt (director.x * director.x + director.y * director.y + director.z * director.z);
		director.x /= (float)norme; director.y /= (float)norme; director.z /= (float)norme; 

		// Calcul du pas pour parcourir la distance begin -> end
		double pas = norme / (nbBezier*3);

			// Initialisation du point en cours de parcour sur le vecteur
		Vector3 pts = begin;

		points = new Vector3[]{ begin };

		//Debut de la boucle
		for(int i = 1; i <= nbBezier * 3; i++){
			// On avance sur le vecteur directeur de "pas". Calcul absolue pour eviter imprecision
			pts.x = begin.x + director.x * (float)pas * i; 
			pts.y = begin.y + director.y * (float)pas * i;
			pts.z = begin.z + director.z * (float)pas * i;

			//calcul de la direction random pour créer un pts de control
			float vx, vy, vz;
			if (i < nbBezier * 3) {
				if (director.z < -delta || director.z > delta) {
					vx = (float)alea.NextDouble () - 0.5f; // on rand les composants d'un vecteur 
					vy = (float)alea.NextDouble () - 0.5f;
					vz = (float)(-(director.x * vx + director.y * vy) / director.z);
				} else {
					if (director.y < -delta || director.y > delta) {
						vx = (float)alea.NextDouble () - 0.5f;
						vy = (float)(-(director.x * vx) / director.y);
						vz = (float)alea.NextDouble () - 0.5f;
					} else {
						if (director.x < -delta || director.x > delta) {
							vx = 0.0f;
							vy = (float)alea.NextDouble () - 0.5f;
							vz = (float)alea.NextDouble () - 0.5f;
						} else {
							vx = 0.0f;
							vy = 0.0f;
							vz = 0.0f;
						}
					}
				}
			} else {
				vx = 0.0f;
				vy = 0.0f;
				vz = 0.0f;
			}

			Vector3 newDir = new Vector3 (vx, vy, vz); // création du vecteur qu'on va normaliser
			double newNorme = Math.Sqrt (newDir.x * newDir.x + newDir.y * newDir.y + newDir.z * newDir.z);
			if (newNorme > delta || newNorme < -delta) {
				newDir.x /= (float)newNorme; 
				newDir.y /= (float)newNorme; 
				newDir.z /= (float)newNorme;
			}
			//On rand la distance au vecteur directeur entre 1/4 de width et width
			float dist = (float)((alea.NextDouble ()*width*3/4)+width/4);
			newDir.x *= dist; newDir.y *= dist; newDir.z *= dist;

			//Calcul du nouveau point à ajouter et ajout
			Vector3 newPoint = new Vector3(pts.x + newDir.x, pts.y + newDir.y, pts.z + newDir.z);
			Array.Resize(ref points, points.Length + 1);
			points [points.Length - 1].x = newPoint.x;
			points [points.Length - 1].y = newPoint.y;
			points [points.Length - 1].z = newPoint.z;

			if (i % 3 == 0) {
				Array.Resize (ref modes, modes.Length + 1);
				modes [modes.Length - 1] = modes [modes.Length - 2];
				EnforceMode (points.Length - 4);
				SetControlPointMode (i, modeAlea);
			}
		}
	}
}
