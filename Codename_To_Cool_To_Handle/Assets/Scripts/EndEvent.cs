using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndEvent : MonoBehaviour
{
    [SerializeField] private TriggerSchlitten triggerSchlitten;
    [SerializeField] private GameObject blackBlock1;
    [SerializeField] private GameObject blackBlock2;

    private bool isTriggert = false;

    private void Update()
    {
        if(!isTriggert && triggerSchlitten.isTriggert)
        {
            blackBlock1.SetActive(true);
            blackBlock2.SetActive(true);
            isTriggert=true;
            animate();
        }

        //blackBlock1.transform.localPosition = new Vector3(blackBlock1.transform.localPosition.x, blackBlock1.transform.localPosition.y, 5);
        //blackBlock2.transform.localPosition = new Vector3(blackBlock2.transform.localPosition.x, blackBlock2.transform.localPosition.y, 5);
    }

    private void animate()
    {
        blackBlock1.LeanMoveLocal(new Vector3(0, 8f, blackBlock1.transform.localPosition.z), 2);
        blackBlock2.LeanMoveLocal(new Vector3(0,-8f, blackBlock2.transform.localPosition.z), 2);  

    }
}
