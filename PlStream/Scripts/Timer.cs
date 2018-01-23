using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour {
	public Text timerLabel;
 	public Text bestTimeLabel;

 	public bool count = false;
 	public bool best = false;
    public float time;
    public float bestTime;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update() {
		if(best == true)
		{
			var minutes = bestTime / 60; //Divide the guiTime by sixty to get the minutes.
	        var seconds = bestTime % 60;//Use the euclidean division for the seconds.
	        var fraction = (bestTime * 100) % 100;
			bestTimeLabel.text = string.Format ("Best : {0:00} : {1:00} : {2:00}", minutes, seconds, fraction);
			best = false;
		}

		if(count == true)
		{
			time += Time.deltaTime;
 
	        var minutes = time / 60; //Divide the guiTime by sixty to get the minutes.
	        var seconds = time % 60;//Use the euclidean division for the seconds.
	        var fraction = (time * 100) % 100;
	 
	        //update the label value
	        timerLabel.text = string.Format ("{0:00} : {1:00} : {2:00}", minutes, seconds, fraction);
		}
        
     }
}
