using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;

public class Outro : MonoBehaviour
{
    [SerializeField] private AudioSource oldAudio;
    [SerializeField] private AudioSource newAudio;
    [SerializeField] private AudioSource wind;

    [SerializeField] private GameObject Panel;
    [SerializeField] private GameObject Titel;
    [SerializeField] private GameObject Credits;
    [SerializeField] private GameObject Credis1;
    [SerializeField] private GameObject Credis2;
    [SerializeField] private GameObject Thanks;
    private bool isSingelton = false;
    private bool isSingelton1 = false;

    [SerializeField] private TriggerSchlitten triggerSchlitten;

   private void Update()
    {
        if(triggerSchlitten.isTriggert && !isSingelton)
        {
            isSingelton=true;
            LeanTween.value(1f, 0f, 1f).setOnUpdate((float val) => { oldAudio.volume = val; }).setOnComplete(playWind);
        }
        if(triggerSchlitten.isEnd && !isSingelton1)
        {
            isSingelton1 =true;
            LeanTween.value(1f, 0f, 4f).setOnUpdate((float val) => { wind.volume = val; });
            Invoke("showTitel", 4);
        }
    }

    //private void showPanel()
    //{
    //    Panel.SetActive(true);
    //    newAudio.Play();
    //    Invoke("showTitel", 2);
    //}
    private void showTitel()
    {
        newAudio.Play();
        Panel.SetActive(true);
        Titel.SetActive(true);
        Invoke("showCredits", 3.1f);
     
    }

    private void showCredits()
    {
        Titel.SetActive(false); 
        Credits.SetActive(true);
        Invoke("showCredits1", 3f);
    }

    private void showCredits1()
    {
        Credits.SetActive(false);
        Credis1.SetActive(true);
        Invoke("showCredits2", 3f);
    }

    private void showCredits2()
    {
        Credis1.SetActive(false);
        Credis2.SetActive(true);
        Invoke("showThanks", 3f);

    }

    private void showThanks()
    {
        Credis2 .SetActive(false);
        Thanks .SetActive(true);
    }

    private void playWind()
    {
        wind.Play();
    }
}
