using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using UnityEditor;

public class Clock : MonoBehaviour{

    public TMP_Text clockText;
    public TMP_Text appleText;
    // Start is called before the first frame update
    void Start()
    {
     
 
    }
    public GameObject Apple;
    // Update is called once per frame
    void Update()
    {
        
        clockText.text = DateTime.Now.ToString("HH:mm:ss");
        appleText.text = "SCORE: " + Apple.GetComponent<EatPositionChanger>().Apple_count.ToString();

        //appleText.text = Apple.GetComponent<EatPositionChanger>().Apple_count.ToString();
        //Debug.Log(Apple.GetComponent<EatPositionChanger>().Apple_count);
        
    }
}
