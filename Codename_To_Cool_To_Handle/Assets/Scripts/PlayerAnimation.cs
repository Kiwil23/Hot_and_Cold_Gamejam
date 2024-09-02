using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    private PlayerMovement m_PlayerMovement;
    private Animator m_Animator;
   
   private void Awake()
    {
        m_PlayerMovement = GetComponent<PlayerMovement>();
        m_Animator = GetComponent<Animator>();
    }

   private void Update()
    {
        ChangeAnimation(m_PlayerMovement.getIsPlayerMoving());
    }

    private void ChangeAnimation(bool isMoving)
    {
        m_Animator.SetBool("_walking", isMoving);
        if (m_PlayerMovement.getIsPlayerGrounded())
        {          
            m_Animator.SetBool("_jumping", false);
        }
        else
        {
            m_Animator.SetBool("_jumping", true);
        }       
    }
}
