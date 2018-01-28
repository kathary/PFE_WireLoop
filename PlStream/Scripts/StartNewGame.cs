using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using System.Diagnostics;
using System;
using System.IO;

public class StartNewGame : MonoBehaviour {

    private GameObject previousMenu;
    public GameObject sliderHand;

    public GameObject[] menu;


    public void LoadByIndex(int starter)
    {
        if(starter == 0)
        {
            if(PlayerPrefs.GetInt("Hand",1) == 0)
            {
                PlayerPrefs.SetFloat("DepartX",(UnityEngine.Random.value * 0.8f) + (-0.4f));
                PlayerPrefs.SetFloat("DepartY",(UnityEngine.Random.value * 0.3f) + (1.3f));
                PlayerPrefs.SetFloat("DepartZ",0.70f);

                PlayerPrefs.SetFloat("FinX",(UnityEngine.Random.value * 0.8f) + (-0.4f));
                PlayerPrefs.SetFloat("FinY",(UnityEngine.Random.value * 0.3f) + (1.3f));
                PlayerPrefs.SetFloat("FinZ",-0.70f);
            }
            else {
                PlayerPrefs.SetFloat("DepartX",(UnityEngine.Random.value * 0.8f) + (-0.4f));
                PlayerPrefs.SetFloat("DepartY",(UnityEngine.Random.value * 0.3f) + (1.3f));
                PlayerPrefs.SetFloat("DepartZ",-0.70f);

                PlayerPrefs.SetFloat("FinX",(UnityEngine.Random.value * 0.8f) + (-0.4f));
                PlayerPrefs.SetFloat("FinY",(UnityEngine.Random.value * 0.3f) + (1.3f));
                PlayerPrefs.SetFloat("FinZ",0.70f);
            }
            
            PlayerPrefs.SetFloat("Width",0);
            PlayerPrefs.SetInt("Bezier",1);
            PlayerPrefs.SetFloat("Size",5);

        }

        else if (starter == 1)
        {
            if(PlayerPrefs.GetInt("Hand",1) == 0)
            {
                PlayerPrefs.SetFloat("DepartX",(UnityEngine.Random.value * 0.8f) + (-0.4f));
                PlayerPrefs.SetFloat("DepartY",(UnityEngine.Random.value * 0.3f) + (1.3f));
                PlayerPrefs.SetFloat("DepartZ",0.70f);

                PlayerPrefs.SetFloat("FinX",(UnityEngine.Random.value * 0.8f) + (-0.4f));
                PlayerPrefs.SetFloat("FinY",(UnityEngine.Random.value * 0.3f) + (1.3f));
                PlayerPrefs.SetFloat("FinZ",-0.70f);
            }
            else {
                PlayerPrefs.SetFloat("DepartX",(UnityEngine.Random.value * 0.8f) + (-0.4f));
                PlayerPrefs.SetFloat("DepartY",(UnityEngine.Random.value * 0.3f) + (1.3f));
                PlayerPrefs.SetFloat("DepartZ",-0.70f);

                PlayerPrefs.SetFloat("FinX",(UnityEngine.Random.value * 0.8f) + (-0.4f));
                PlayerPrefs.SetFloat("FinY",(UnityEngine.Random.value * 0.3f) + (1.3f));
                PlayerPrefs.SetFloat("FinZ",0.70f);
            }

            PlayerPrefs.SetFloat("Width",0.2f);
            PlayerPrefs.SetInt("Bezier",1);
            PlayerPrefs.SetFloat("Size",5);
        }

        else if (starter == 2)
        {
            if(PlayerPrefs.GetInt("Hand",1) == 0)
            {
                PlayerPrefs.SetFloat("DepartX",(UnityEngine.Random.value * 0.8f) + (-0.4f));
                PlayerPrefs.SetFloat("DepartY",(UnityEngine.Random.value * 0.3f) + (1.3f));
                PlayerPrefs.SetFloat("DepartZ",0.70f);

                PlayerPrefs.SetFloat("FinX",(UnityEngine.Random.value * 0.8f) + (-0.4f));
                PlayerPrefs.SetFloat("FinY",(UnityEngine.Random.value * 0.3f) + (1.3f));
                PlayerPrefs.SetFloat("FinZ",-0.70f);
            }
            else {
                PlayerPrefs.SetFloat("DepartX",(UnityEngine.Random.value * 0.8f) + (-0.4f));
                PlayerPrefs.SetFloat("DepartY",(UnityEngine.Random.value * 0.3f) + (1.3f));
                PlayerPrefs.SetFloat("DepartZ",-0.70f);

                PlayerPrefs.SetFloat("FinX",(UnityEngine.Random.value * 0.8f) + (-0.4f));
                PlayerPrefs.SetFloat("FinY",(UnityEngine.Random.value * 0.3f) + (1.3f));
                PlayerPrefs.SetFloat("FinZ",0.70f);
            }

            PlayerPrefs.SetFloat("Width",0.3f);
            PlayerPrefs.SetInt("Bezier",2);
            PlayerPrefs.SetFloat("Size",5);
        }

        else if (starter == 3)
        {
            if(PlayerPrefs.GetInt("Hand",1) == 0)
            {
                PlayerPrefs.SetFloat("DepartX",(UnityEngine.Random.value * 0.8f) + (-0.4f));
                PlayerPrefs.SetFloat("DepartY",(UnityEngine.Random.value * 0.3f) + (1.3f));
                PlayerPrefs.SetFloat("DepartZ",0.70f);

                PlayerPrefs.SetFloat("FinX",(UnityEngine.Random.value * 0.8f) + (-0.4f));
                PlayerPrefs.SetFloat("FinY",(UnityEngine.Random.value * 0.3f) + (1.3f));
                PlayerPrefs.SetFloat("FinZ",-0.70f);
            }
            else {
                PlayerPrefs.SetFloat("DepartX",(UnityEngine.Random.value * 0.8f) + (-0.4f));
                PlayerPrefs.SetFloat("DepartY",(UnityEngine.Random.value * 0.3f) + (1.3f));
                PlayerPrefs.SetFloat("DepartZ",-0.70f);

                PlayerPrefs.SetFloat("FinX",(UnityEngine.Random.value * 0.8f) + (-0.4f));
                PlayerPrefs.SetFloat("FinY",(UnityEngine.Random.value * 0.3f) + (1.3f));
                PlayerPrefs.SetFloat("FinZ",0.70f);
            }
        }

        SceneManager.LoadScene(1);
    }

    public void LoadNextMenu(int menuIndex)
    {
        previousMenu.SetActive(false);
        previousMenu = menu[menuIndex];
        menu[menuIndex].SetActive(true);        
    }

    public void EditMode(Dropdown drop)
    {
        PlayerPrefs.SetString("Mode",drop.captionText.text);
    }

    public void EditSize(Text texte)
    {
        int parsedResult;
        if(int.TryParse(texte.text, out parsedResult))
        {
            PlayerPrefs.SetFloat("Size",parsedResult);
        }
        else
        {
            texte.text = "";
        }  
    }

    public void EditWidth(Text texte)
    {
        int parsedResult;
        if(int.TryParse(texte.text, out parsedResult))
        {
            PlayerPrefs.SetFloat("Width",parsedResult);
        }
        else
        {
            texte.text = "";
        }  
    }

    public void EditBezier(Text texte)
    {
        int parsedResult;
        if(int.TryParse(texte.text, out parsedResult))
        {
            PlayerPrefs.SetFloat("Bezier",parsedResult);
        }
        else
        {
            texte.text = "";
        }  
    } 



    public void ChangeMainHand()
    {
        PlayerPrefs.SetInt("Hand", (int)sliderHand.GetComponent<Slider>().value );
    }

    public void Start(){
        //Process.Start(Application.dataPath + "\\PlStream\\UnityExport.exe");
        previousMenu = menu[0];
        sliderHand.GetComponent<Slider>().value = PlayerPrefs.GetFloat("Hand",1);
        for (int i = 1 ;i<menu.Length; i++)
        {
            menu[i].SetActive(false);
        }

        //UnityEngine.Debug.Log(PlayerPrefs.GetFloat("Hand",0));
    }
}