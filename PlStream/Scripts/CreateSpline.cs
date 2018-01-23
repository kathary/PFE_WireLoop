using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateSpline : MonoBehaviour {
	private bool neverDone = true;
	private BezierSpline spline;
	private GameObject start;
	private GameObject end;
	private GameObject anneau;
	// Use this for initialization

	void Awake () {
		start = GameObject.Find("Start");
		end = GameObject.Find("End");
		anneau = GameObject.Find("Player");
		spline = GameObject.Find("MySpline").GetComponent<BezierSpline>();
		spline.SetControlPoint(0,new Vector3(PlayerPrefs.GetInt("DepartX",0),PlayerPrefs.GetInt("DepartY",0),PlayerPrefs.GetInt("DepartZ",0)));
		spline.SetControlPoint(spline.ControlPointCount-1,new Vector3(PlayerPrefs.GetInt("FinX",10),PlayerPrefs.GetInt("FinY",10),PlayerPrefs.GetInt("FinZ",10)));
		spline.Width = PlayerPrefs.GetInt("Width",0);
		spline.NbBezier = PlayerPrefs.GetInt("Bezier",1);
	}
	
	// Update is called once per frame
	void Update () {
		if (neverDone == true){
			Vector3 positionDepart = new Vector3(27,6,0);
			Vector3 positionFin = new Vector3(-30,25,13);
		    GameObject[] objs = GameObject.FindGameObjectsWithTag("Line");
		    GameObject depart = null;
		    GameObject fin = null;
		    
		    foreach (GameObject go in objs) {
		      if (go.transform.position == positionDepart) {
		        depart = go;
		        break;
		      }
		    }
		    foreach (GameObject go in objs) {
		      if (go.transform.position == positionFin) {
		        fin = go;
		        break;
		      }
		    }

		    start.transform.position = depart.transform.position - new Vector3(0,0,(float)0.1);
		    start.transform.rotation = depart.transform.rotation;
		    
		    anneau.transform.position = depart.transform.position - 2 * depart.transform.forward;
		    anneau.transform.rotation = depart.transform.rotation;

		    end.transform.position = fin.transform.position;
		    end.transform.rotation = fin.transform.rotation;

		    neverDone = false;
		}
	}
}
