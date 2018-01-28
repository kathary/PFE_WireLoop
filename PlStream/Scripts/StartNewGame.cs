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
            PlayerPrefs.SetFloat("DepartX",(UnityEngine.Random.value * 0.8f) + (-0.4f));
            PlayerPrefs.SetFloat("DepartY",(UnityEngine.Random.value * 0.3f) + (0.95f));
            PlayerPrefs.SetFloat("DepartZ",-0.90f);

            PlayerPrefs.SetFloat("FinX",(UnityEngine.Random.value * 0.8f) + (-0.4f));
            PlayerPrefs.SetFloat("FinY",(UnityEngine.Random.value * 0.3f) + (0.95f));
            PlayerPrefs.SetFloat("FinZ",0.90f);

            PlayerPrefs.SetFloat("Width",0);
            PlayerPrefs.SetInt("Bezier",1);
        }

        else if (starter == 1)
        {
            PlayerPrefs.SetFloat("DepartX",(UnityEngine.Random.value * 0.8f) + (-0.4f));
            PlayerPrefs.SetFloat("DepartY",(UnityEngine.Random.value * 0.3f) + (0.95f));
            PlayerPrefs.SetFloat("DepartZ",-0.90f);

            PlayerPrefs.SetFloat("FinX",(UnityEngine.Random.value * 0.8f) + (-0.4f));
            PlayerPrefs.SetFloat("FinY",(UnityEngine.Random.value * 0.3f) + (0.95f));
            PlayerPrefs.SetFloat("FinZ",0.90f);

            PlayerPrefs.SetFloat("Width",0.2f);
            PlayerPrefs.SetInt("Bezier",1);
        }

        else if (starter == 2)
        {
            PlayerPrefs.SetFloat("DepartX",(UnityEngine.Random.value * 0.8f) + (-0.4f));
            PlayerPrefs.SetFloat("DepartY",(UnityEngine.Random.value * 0.3f) + (0.95f));
            PlayerPrefs.SetFloat("DepartZ",-0.90f);

            PlayerPrefs.SetFloat("FinX",(UnityEngine.Random.value * 0.8f) + (-0.4f));
            PlayerPrefs.SetFloat("FinY",(UnityEngine.Random.value * 0.3f) + (0.95f));
            PlayerPrefs.SetFloat("FinZ",0.90f);

            PlayerPrefs.SetFloat("Width",0.3f);
            PlayerPrefs.SetInt("Bezier",2);
        }

        SceneManager.LoadScene(1);
    }

    public void LoadNextMenu(int menuIndex)
    {
   		previousMenu.SetActive(false);
        previousMenu = menu[menuIndex];
        menu[menuIndex].SetActive(true);   		
    }

    public void EditPointDepartX(Text texte)
    {
        int parsedResult;
        if(int.TryParse(texte.text, out parsedResult))
        {
            PlayerPrefs.SetFloat("DepartX",parsedResult);
            UnityEngine.Debug.Log("DepartX");
            UnityEngine.Debug.Log(PlayerPrefs.GetFloat("DepartX"));
        }
        else
        {
            texte.text = "";
        }  
    }

    public void EditPointDepartY(Text texte)
    {
        int parsedResult;
        if(int.TryParse(texte.text, out parsedResult))
        {
            PlayerPrefs.SetFloat("DepartY",parsedResult);
        }
        else
        {
            texte.text = "";
        }  
    }


    public void EditPointDepartZ(Text texte)
    {
        int parsedResult;
        if(int.TryParse(texte.text, out parsedResult))
        {
            PlayerPrefs.SetFloat("DepartZ",parsedResult);
        }
        else
        {
            texte.text = "";
        }  
    }

    public void EditPointFinX(Text texte)
    {
        int parsedResult;
        if(int.TryParse(texte.text, out parsedResult))
        {
            PlayerPrefs.SetFloat("FinX",parsedResult);
        }
        else
        {
            texte.text = "";
        }  
    }

    public void EditPointFinY(Text texte)
    {
        int parsedResult;
        if(int.TryParse(texte.text, out parsedResult))
        {
            PlayerPrefs.SetFloat("FinY",parsedResult);
        }
        else
        {
            texte.text = "";
        }  
    }

    public void EditPointFinZ(Text texte)
    {
        int parsedResult;
        if(int.TryParse(texte.text, out parsedResult))
        {
            PlayerPrefs.SetFloat("FinZ",parsedResult);
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
    	Process.Start(Application.dataPath + "\\PlStream\\UnityExport.exe");
    	previousMenu = menu[0];
    	sliderHand.GetComponent<Slider>().value = PlayerPrefs.GetFloat("Hand",1);
        for (int i = 1 ;i<menu.Length; i++)
        {
            menu[i].SetActive(false);
        }

    	//UnityEngine.Debug.Log(PlayerPrefs.GetFloat("Hand",0));
    }
}