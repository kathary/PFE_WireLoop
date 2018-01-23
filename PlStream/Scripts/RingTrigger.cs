using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RingTrigger : MonoBehaviour {

	private Timer time;
	private AudioSource loseAudio;
	// Use this for initialization
	void Start () {
		time = GameObject.Find("Canvas").GetComponent<Timer>();
		loseAudio = GetComponent<AudioSource> ();
	}

	void OnCollisionEnter(Collision other) {
		Debug.Log(other.collider.name);
		if(time.count == true && other.collider.name == "Sphere(Clone)")
		{
			loseAudio.Play();
			Debug.Log("PERDU");
	        time.count = false;
	        time.timerLabel.text = "Loser";
		}
        
    }

	// Update is called once per frame
	void Update () {
		
	}
}
