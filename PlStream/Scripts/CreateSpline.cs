using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateSpline : MonoBehaviour {
	private bool neverDone = true;
	private BezierSpline spline;
	public GameObject start;
	public GameObject end;
	public GameObject anneau;
	// Use this for initialization

	void Awake () {

		spline = GameObject.Find("MySpline").GetComponent<BezierSpline>();
		spline.SetControlPoint(0,new Vector3(PlayerPrefs.GetFloat("DepartX",0),PlayerPrefs.GetFloat("DepartY",0),PlayerPrefs.GetFloat("DepartZ",0)));
		spline.SetControlPoint(spline.ControlPointCount-1,new Vector3(PlayerPrefs.GetFloat("FinX",10),PlayerPrefs.GetFloat("FinY",10),PlayerPrefs.GetFloat("FinZ",10)));
		spline.Width = PlayerPrefs.GetFloat("Width",0);
		spline.NbBezier = PlayerPrefs.GetInt("Bezier",1);
	}
	
	// Update is called once per frame
	void Update () {
		if (neverDone == true){
			Vector3 positionDepart = new Vector3(PlayerPrefs.GetFloat("DepartX",0),PlayerPrefs.GetFloat("DepartY",0),PlayerPrefs.GetFloat("DepartZ",0));
			Vector3 positionFin = new Vector3(PlayerPrefs.GetFloat("FinX",10),PlayerPrefs.GetFloat("FinY",10),PlayerPrefs.GetFloat("FinZ",10));
		    GameObject[] objs = GameObject.FindGameObjectsWithTag("Line");
		    GameObject depart = null;
		    GameObject fin = null;
		    depart = objs[0];
		    fin = objs[objs.Length -1];
		    

		    start.transform.position = depart.transform.position ;
		    start.transform.rotation = depart.transform.rotation;
		    //Debug.Log(depart.transform.position);

		    anneau.transform.position = depart.transform.position - 0.5f * depart.transform.forward;
		    anneau.transform.rotation = depart.transform.rotation;
		    anneau.transform.localScale = new Vector3(0.03f * PlayerPrefs.GetFloat("Size",10),0.03f * PlayerPrefs.GetFloat("Size",10),0.03f * PlayerPrefs.GetFloat("Size",10));

		    end.transform.position = fin.transform.position;
		    end.transform.rotation = fin.transform.rotation;

		    neverDone = false;
		}
	}
}
