//  VSS $Header: /PiDevTools11/Inc/PDIg4.h 18    1/09/14 1:05p Suzanne $  
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class SimpleController : MonoBehaviour {
    
    private PlStream plstream;
    private Vector3 prime_position;
    private GameObject[] player;
    private Timer time;
    private int[] dropped;

    // Use this for initialization
    void Awake ()
    {
        time = GameObject.Find("Canvas").GetComponent<Timer>();
        time.bestTime = PlayerPrefs.GetFloat("Score",0);
        time.best = true;

        // get the stream component
        plstream = GetComponent<PlStream>();
        
        // get player
        player = GameObject.FindGameObjectsWithTag("Player");
        dropped = new int[player.Length];

        // set sensors_slider max value
        //sensors_slider.maxValue = Mathf.Min(player.Length, plstream.active.Length);
    }

    void Start () {
        // initializes arrays, fixes positions
        zero();
    }
    
    // Update is called once per frame
    void Update () {
        if (Input.GetKeyDown("escape"))
        {
            Debug.Log("ca marche");
            SceneManager.LoadScene(0);
        }
        
    }

    // called before performing any physics calculations
    void FixedUpdate()
    {
        // for each knuckle up to sensors slider value, update the position
        for (int i = 0; plstream != null && i < 1; ++i)
        {
            if (plstream.active[i])
            {
                Vector3 pol_position = plstream.positions[i] -prime_position ;
                Vector4 pol_rotation = plstream.orientations[i];

                // doing crude (90 degree) rotations into frame
                Vector3 unity_position;
                //Debug.Log(pol_position.y);
                unity_position.x = -pol_position.x;
                unity_position.y = pol_position.z;
                unity_position.z = pol_position.y;


                Quaternion unity_rotation;
                unity_rotation.w = pol_rotation[0];
                unity_rotation.x = -pol_rotation[2];
                unity_rotation.y = pol_rotation[3];
                unity_rotation.z = -pol_rotation[1];
                unity_rotation *= new Quaternion((float)0.70707,0,0,(float)0.70707);
                

                if (!player[i].activeSelf)
                    player[i].SetActive(true);
                player[i].transform.position = (unity_position + new Vector3 ( 0,10,-10)) / 10;
                player[i].transform.rotation = unity_rotation;

                // set deactivate frame count to 10
                dropped[i] = 10;

                if (plstream.digio[i] != 0)
                {
                    zero();
                }
            }
            else
            {
                if(player[i])
                {
                   if (player[i].activeSelf)
                {
                    dropped[i] -= 1;
                    if (dropped[i] <= 0)
                        player[i].SetActive(false);
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
