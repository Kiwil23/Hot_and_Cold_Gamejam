using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class IceGround: MonoBehaviour
{
    [SerializeField] private float meltingTime = 3f;
    private float startMeltingTime;
    [SerializeField] private Animator m_animator;
    [SerializeField] private Animator animator;
    [SerializeField] private SpriteRenderer realObj;
    [SerializeField] private SpriteRenderer fakeObj;
    [SerializeField] private Collider2D realCol;
    [SerializeField] private Collider2D fakeCol;
    [SerializeField] private float animatorSpeed;
    [SerializeField] private float yPos;
    private bool isMelting = false;
    [SerializeField] private float colliderSpeed;
    private bool isExited = false;

    private void Start()
    {
        startMeltingTime = meltingTime;
        m_animator.speed = 0;
        animator.speed = 0;
    }
    private void Update()
    {
        MoveCollider();

        if (isExited)
        {

            if (meltingTime < startMeltingTime)
                meltingTime += Time.deltaTime;
        }
        if(m_animator.GetCurrentAnimatorStateInfo(0).normalizedTime < 0 && !isMelting)
        {
            m_animator.speed = 0;
            animator.speed = 0;
        }


    }
    public void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.tag == "sun")
        {
            meltingTime -= Time.deltaTime;
            m_animator.speed = animatorSpeed;
            animator.speed = animatorSpeed;
            realObj.enabled = true;
            realCol.enabled = true;
            fakeObj.enabled = false;
            fakeCol.enabled = false;
            isMelting = true;
              m_animator.SetFloat("_direction", 1);
            animator.SetFloat("_direction", 1);
            isExited = false;
        }

        MeltIce();
    }

    public void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "sun")
        {

            //m_animator.speed = animatorSpeed - 1f;
            //animator.speed = animatorSpeed - 1f;

            realObj.enabled = false;
            realCol.enabled = false;
            fakeObj.enabled = true;
            fakeCol.enabled = true;
            isMelting = false;
            m_animator.SetFloat("_direction", -1);
            animator.SetFloat("_direction", -1);
            isExited = true;
        }
    }

    private void MeltIce()
    {
        if (meltingTime < 0)
        {
            Destroy(this.gameObject.transform.parent.gameObject);
        }
    }

    private void MoveCollider()
    {
        if( isMelting)
        {
            transform.Translate(new Vector3(0, (colliderSpeed/yPos) *Time.deltaTime, 0));
        }      
        else
        {
            if(transform.localPosition.y < 2.73f)
            {
                transform.Translate(new Vector3(0, -(colliderSpeed / yPos) * Time.deltaTime, 0));
            }
          
        }
    }
}
