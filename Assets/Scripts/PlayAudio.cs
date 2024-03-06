using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

public class PlayAudio : MonoBehaviour
{
    public AudioSource ButtonSFX;
    public AudioSource EatAppleSFX;
    // Start is called before the first frame update
    void Start()
    { 
        
    }

    // Update is called once per frame
    void Update()
    {

    }

        public void buttonsound()
        {
            ButtonSFX.Play();
        }

        public void eatsound()
        {
            EatAppleSFX.Play();
        }
        
    }
