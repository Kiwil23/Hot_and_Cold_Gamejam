using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Backround : MonoBehaviour
{
 private Animator m_Anim;

 
    private void Start()
    {
        m_Anim = GetComponent<Animator>();
    }

    private void Update()
    {
        StartCoroutine(wait());
    }

    IEnumerator wait()
    {
        m_Anim.enabled = true;
        yield return new WaitForSeconds(Random.Range(2f, 5f));
        m_Anim.enabled = false;
    }
}
