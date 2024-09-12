using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wolf : MonoBehaviour
{
    [SerializeField] private Animator m_Animator;
    [SerializeField] private Animator iceBlockAnimator;
    [SerializeField] private Transform path1;
    [SerializeField] private Transform path2;
    [SerializeField] private float animSpeed = 1f;
    [SerializeField] private float wolfSpeed = 1f;
    [SerializeField] private Vector2 startPos;
    [SerializeField] private Collider2D col;
    [SerializeField] private AudioSource audioSource;
    private float progess = 0;
    private bool isPath1Reached = false;
    private bool isSoundPlayed = false;
    private void Start()
    {
        m_Animator.speed = 0;
        startPos = transform.position;
    }
    private void Update()
    {
       
        if(iceBlockAnimator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1)
        {
            if(!isSoundPlayed)
            {
                isSoundPlayed = true;
                audioSource.Play();
            }

            m_Animator.speed = animSpeed;
            col.enabled = true;
            if (!isPath1Reached)
            {
                transform.position = Vector2.Lerp(startPos, path1.position, progess);
                progess += Time.deltaTime * wolfSpeed*1.8f;
                if (progess >= 1)
                {
                    progess = 0;
                    isPath1Reached = true;
                    Vector2 temp1 = new Vector2(transform.localScale.x * -1, transform.localScale.y);
                    transform.localScale = temp1;
                }
            }

            else
            {
                transform.position = Vector2.Lerp(path1.position, path2.position, progess);
                progess += Time.deltaTime * wolfSpeed;

                if (progess >= 1 && isPath1Reached)
                {
                    progess = 0;
                    Vector2 temp = path1.position;
                    path1.position = path2.position;
                    path2.position = temp;
                    Vector2 temp1 = new Vector2(transform.localScale.x * -1, transform.localScale.y);
                    transform.localScale = temp1;
                }
            }
        }
    }
}
