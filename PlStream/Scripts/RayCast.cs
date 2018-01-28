using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayCast : MonoBehaviour {
	public Camera cam;
	public GameObject gaze;
	public Material mat1;
	public Material mat2;
	int nb = 0;
	// Use this for initialization
	void Start () {
		GetComponent<Renderer> ().material = mat1;
	}

	public void Tadaa()
	{
		//RaycastHit hit;

		print ("yolo");
		if (nb == 0) {
			GetComponent<Renderer> ().material = mat2;
			nb = 1;
		}
		else {
			GetComponent<Renderer> ().material = mat1;
			nb = 0;
		}


		//GetComponent<Renderer> ().material = mat2;
		/*if (Physics.Raycast(cam.ScreenPointToRay(gaze.transform.position),out hit))
			GetComponent<Renderer> ().material = mat2;*/
	}

	/*public void Dedans() {
		GetComponent<Renderer> ().material = mat2;
	}

	public void Dehors () {
		GetComponent<Renderer> ().material = mat1;
	}*/
}
