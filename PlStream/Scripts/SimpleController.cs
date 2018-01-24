//  VSS $Header: /PiDevTools11/Inc/PDIg4.h 18    1/09/14 1:05p Suzanne $  
using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SimpleController : MonoBehaviour {
    
    private PlStream plstream;
    private Vector3 prime_position;
    private GameObject[] knuckles;
    private Timer time;
    private int[] dropped;

    // Use this for initialization
    void Awake ()
    {
        time = GameObject.Find("Canvas").GetComponent<Timer>();
        time.bestTime = PlayerPrefs.GetFloat("Score",0);
        time.best = true;
        // set divisor defaults
        //divisor_slider.value = 1.0f;

        // set sensors defaults
        //sensors_slider.value = 1;
        //this.transform.position = GameObject.Find("Line").transform.position + new Vector3 (0,2,-5);
        // get the stream component
        plstream = GetComponent<PlStream>();
        
        // get knuckles
        knuckles = GameObject.FindGameObjectsWithTag("Knuckle");
        dropped = new int[knuckles.Length];

        // set sensors_slider max value
        //sensors_slider.maxValue = Mathf.Min(knuckles.Length, plstream.active.Length);
    }

    void Start () {
        // initializes arrays, fixes positions
        zero();
    }
    
    // Update is called once per frame
    void Update () {
        if (Input.GetKeyDown("escape"))
            Application.Quit();
    }

    // called before performing any physics calculations
    void FixedUpdate()
    {
        // update divisor text
        //divisor_value.text = divisor_slider.value.ToString("F1");

        // for each knuckle up to sensors slider value, update the position
        for (int i = 0; plstream != null && i < 1; ++i)
        {
            if (plstream.active[i])
            {
                Vector3 pol_position = plstream.positions[i] -prime_position ;
                Vector4 pol_rotation = plstream.orientations[i];

                // doing crude (90 degree) rotations into frame
                Vector3 unity_position;
                unity_position.x = -pol_position.y;
                unity_position.y = pol_position.z;
                unity_position.z = -pol_position.x;


                Quaternion unity_rotation;
                unity_rotation.w = pol_rotation[0];
                unity_rotation.x = -pol_rotation[2];
                unity_rotation.y = pol_rotation[3];
                unity_rotation.z = -pol_rotation[1];
                unity_rotation *= new Quaternion((float)0.70707,0,0,(float)0.70707);
                //unity_rotation = Quaternion.Inverse(unity_rotation);

                if (!knuckles[i].activeSelf)
                    knuckles[i].SetActive(true);
                knuckles[i].transform.position = (unity_position + new Vector3 ( 0,10,-10)) / 10;
                knuckles[i].transform.rotation = unity_rotation;

                // set deactivate frame count to 10
                dropped[i] = 10;

                if (plstream.digio[i] != 0)
                {
                    zero();
                }
            }
            else
            {
                if(knuckles[i])
                {
                   if (knuckles[i].activeSelf)
                {
                    dropped[i] -= 1;
                    if (dropped[i] <= 0)
                        knuckles[i].SetActive(false);
                } 
                }
                
            }
        }
    }

    public void zero()
    {
        for (var i = 0; i < dropped.Length; ++i)
            dropped[i] = 0;

        for (var i = 0; i < plstream.active.Length; ++i)
        {
            if (plstream.active[i])
            {
                prime_position = plstream.positions[i];
                break;
            }
        }
    }
}
