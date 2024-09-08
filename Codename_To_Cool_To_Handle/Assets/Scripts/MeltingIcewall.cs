using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeltingIcewall : MonoBehaviour
{
    [SerializeField] private float meltingTime = 3f;
    [SerializeField] private Animator m_animator;
    [SerializeField] private Animator animator;
    [SerializeField] private SpriteRenderer realObj;
    [SerializeField] private SpriteRenderer fakeObj;
    [SerializeField] private float animatorSpeed;
    [SerializeField] private float yPos;
    private bool isMelting = false;

    private void Start()
    {
     
        m_animator.speed = 0;
        animator.speed = 0;
    }
    private void Update()
    {
        MoveCollider();
    }
    public void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.tag == "sun")
        {
            meltingTime -= Time.deltaTime;
            m_animator.speed = animatorSpeed;
            animator.speed = animatorSpeed;
            realObj.enabled = true;
            fakeObj.enabled = false;
            isMelting = true;
        }

        MeltIce();
    }

    public void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "sun")
        {
            m_animator.speed = 0;
            animator.speed = 0;
            realObj.enabled = false;
            fakeObj.enabled = true;
            isMelting = false;
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
            transform.Translate(new Vector3(0, (7.1f/yPos) *Time.deltaTime, 0));
        }      
    }
}
