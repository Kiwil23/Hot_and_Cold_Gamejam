using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Backround : MonoBehaviour
{
 private Animator m_Anim;
    private bool isOn = false;
 
    private void Start()
    {
        m_Anim = GetComponent<Animator>();
    }

    private void Update()
    {
        if(!isOn)
        StartCoroutine(wait());
    }

    private IEnumerator wait()
    {    
        m_Anim.enabled = true;
        isOn = true;
        yield return new WaitForSeconds(Random.Range(2f, 5f));
        m_Anim.enabled = false;
        yield return new WaitForSeconds(Random.Range(2f, 5f));
        isOn = false;
    }
}
