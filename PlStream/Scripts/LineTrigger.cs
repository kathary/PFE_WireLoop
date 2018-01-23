using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineTrigger : MonoBehaviour {

	private Timer time;
	private AudioSource loseAudio;
	// Use this for initialization
	void Start () {
		time = GameObject.Find("Canvas").GetComponent<Timer>();
		loseAudio = GetComponent<AudioSource> ();
	}

	void OnTriggerEnter(Collider other) {
		if(other.name == "anneau" && time.count == true )
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
