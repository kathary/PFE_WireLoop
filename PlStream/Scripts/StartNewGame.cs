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

    public GameObject menu0;
    public GameObject menu1;
    public GameObject menu2;
    public GameObject menu3;


    public void LoadByIndex(int starter)
    {
        if(starter == 0)
        {
            PlayerPrefs.SetInt("DepartX",0);
            PlayerPrefs.SetInt("DepartY",0);
            PlayerPrefs.SetInt("DepartZ",0);

            PlayerPrefs.SetInt("FinX",15);
            PlayerPrefs.SetInt("FinY",15);
            PlayerPrefs.SetInt("FinZ",15);

            PlayerPrefs.SetInt("Width",0);
            PlayerPrefs.SetInt("Bezier",1);

        }

        else if (starter == 1)
        {
            PlayerPrefs.SetInt("DepartX",0);
            PlayerPrefs.SetInt("DepartY",0);
            PlayerPrefs.SetInt("DepartZ",0);

            PlayerPrefs.SetInt("FinX",15);
            PlayerPrefs.SetInt("FinY",15);
            PlayerPrefs.SetInt("FinZ",15);

            PlayerPrefs.SetInt("Width",1);
            PlayerPrefs.SetInt("Bezier",1);
        }

        else if (starter == 2)
        {
            PlayerPrefs.SetInt("DepartX",0);
            PlayerPrefs.SetInt("DepartY",0);
            PlayerPrefs.SetInt("DepartZ",0);

            PlayerPrefs.SetInt("FinX",15);
            PlayerPrefs.SetInt("FinY",15);
            PlayerPrefs.SetInt("FinZ",15);

            PlayerPrefs.SetInt("Width",2);
            PlayerPrefs.SetInt("Bezier",1);
        }

        SceneManager.LoadScene(1);
    }

    public void LoadNextMenu(int menuIndex)
    {
   		previousMenu.SetActive(false);
        
        if (menuIndex == 0)
        {
            previousMenu = menu0;
            menu0.SetActive(true);
        }

        else if (menuIndex == 1)
        {
            previousMenu = menu1 ;
            menu1.SetActive(true);
        }

        else if (menuIndex == 2)
        {
            previousMenu = menu2;
            menu2.SetActive(true);
        }

        else if (menuIndex == 3)
        {
            previousMenu = menu3;
            menu3.SetActive(true);
        }
   		
    }

    public void EditPointDepartX(Text texte)
    {
        int parsedResult;
        if(int.TryParse(texte.text, out parsedResult))
        {
            PlayerPrefs.SetInt("DepartX",parsedResult);
            UnityEngine.Debug.Log("DepartX");
            UnityEngine.Debug.Log(PlayerPrefs.GetInt("DepartX"));
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
            PlayerPrefs.SetInt("DepartY",parsedResult);
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
            PlayerPrefs.SetInt("DepartZ",parsedResult);
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
            PlayerPrefs.SetInt("FinX",parsedResult);
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
            PlayerPrefs.SetInt("FinY",parsedResult);
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
            PlayerPrefs.SetInt("FinZ",parsedResult);
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
            PlayerPrefs.SetInt("Width",parsedResult);
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
            PlayerPrefs.SetInt("Bezier",parsedResult);
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
    	previousMenu = menu0;
    	sliderHand.GetComponent<Slider>().value = PlayerPrefs.GetInt("Hand",1);

        menu0.SetActive(true);
        menu1.SetActive(false);
        menu2.SetActive(false);
        menu3.SetActive(false);

    	//UnityEngine.Debug.Log(PlayerPrefs.GetInt("Hand",0));
    }
}