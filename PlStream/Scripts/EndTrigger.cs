using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndTrigger : MonoBehaviour {

	private Timer time;
	private AudioSource endAudio;
	private string score;

	// Use this for initialization
	void Start () {
		time = GameObject.Find("Canvas").GetComponent<Timer>();
		endAudio = GetComponent<AudioSource> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void OnTriggerEnter(Collider other) {
		if(time.count == true)
		{
			if(time.time < time.bestTime)
			{
				PlayerPrefs.SetFloat("Score", time.time);
				time.bestTime = time.time;
				time.best = true;
			}
			endAudio.Play();
        	Debug.Log("The End");
        	time.count = false;
        }
    }
}
