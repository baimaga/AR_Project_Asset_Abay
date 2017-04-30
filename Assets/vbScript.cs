using UnityEngine;

using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using Vuforia;

public class vbScript : MonoBehaviour, IVirtualButtonEventHandler
{
    //holds information about contries
    public Text information;
    private Dictionary<string, string> dictionary_countryInfo =
            new Dictionary<string, string>();
    //initialise dictionary
    

    // Use this for initialization
    void Start()
    {
        setInfo("NONE");

        dictionary_countryInfo.Add("C_Ireland", "IRELAND\n\n  Capital city: Dublin\n  Population: 6M\n  Official language: Irish, English");
        dictionary_countryInfo.Add("C_Kazakhstan", "KAZAKHSTAN\n\n  Capital city: Astana\n  Population: 18M\n  Official language: Kazakh, Russian");
        dictionary_countryInfo.Add("C_China", "CHINA\n\n  Capital city: Beijing\n  Population: 1373M\n  Official language: Chinese");
        dictionary_countryInfo.Add("C_Mexico", "MEXICO\n\n  Capital city: Mexico City\n  Population: 119M\n  Official language: Spanish");
        dictionary_countryInfo.Add("C_India", "INDIA\n\n  Capital city: New Delhi\n  Population: 1326M\n  Official language: Hindi, English");
        dictionary_countryInfo.Add("C_Nepal", "NEPAL\n\n  Capital city: Kathmandu\n  Population: 26M\n  Official language: Nepali");
        dictionary_countryInfo.Add("C_Greece", "GREECE\n\n  Capital city: Athens\n  Population: 10M\n  Official language: Greek");
        dictionary_countryInfo.Add("C_France", "FRANCE\n\n  Capital city: Paris\n  Population: 67M\n  Official language: French");
        dictionary_countryInfo.Add("C_Germany", "GERMANY\n\n  Capital city: Berlin\n  Population: 82M\n  Official language: German");
        dictionary_countryInfo.Add("C_SaudiArabia", "SAUDI ARABIA\n\n  Capital city: Riyadh\n  Population: 33M\n  Official language: Arabic");
        dictionary_countryInfo.Add("C_Malaysia", "MALAYSIA\n\n  Capital city: Kuala Lumpur\n  Population: 31M\n  Official language: Malay/Bahasa Malasian");


        Debug.Log("test::  C_Ireland" + dictionary_countryInfo["C_Ireland"]);


    }

    RaycastHit hit;
    Ray ray;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))// if LMB button is clicked
        {
            
            ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit))
            {
                Debug.Log(" you clicked on:" + hit.collider.gameObject.transform.name + "!1");
                

                displayInfo(hit.collider.gameObject.transform.name);
                /*
                if (hit.collider.gameObject.name == "C_Ireland" && dictionary_countryInfo.ContainsKey("C_Ireland"))
                {
                    setInfo(dictionary_countryInfo["C_Ireland"]);
                }
                */
            }
        }

    }


    public void OnButtonPressed(VirtualButtonAbstractBehaviour vb)
    {
        Debug.Log("Button down!!!");
        
    }

    public void OnButtonReleased(VirtualButtonAbstractBehaviour vb)
    {
        Debug.Log("Button released!!!");
        
    }

    //set value for information
    void setInfo(string text)
    {
        information.text = text;
    }

    //
    void displayInfo(string country)
    {
        Debug.Log("country=" + country + "!2");
        string value = dictionary_countryInfo[country];
        Debug.Log("value=" + value);

        if (dictionary_countryInfo.ContainsKey(country))
        {
            setInfo(dictionary_countryInfo[country]);
            //new WaitForSeconds(2);
            //setInfo("");
        }

        //GameObject canvas = GameObject.Find("Canvas");
        //Fade.use.Alpha(canvas, 1.0, 0.0, 1.0);
    }
}
