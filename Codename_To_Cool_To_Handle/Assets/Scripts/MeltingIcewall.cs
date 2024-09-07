using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeltingIcewall : MonoBehaviour
{
    [SerializeField] private float meltingTime = 3f;
    private Animator m_animator;
    [SerializeField] private Animator animator;
    [SerializeField] private SpriteRenderer realObj;
    [SerializeField] private SpriteRenderer fakeObj;
    [SerializeField] private float animatorSpeed;

    private void Start()
    {
        m_animator = this.transform.GetChild(0).GetComponent<Animator>();
        m_animator.speed = 0;
        animator.speed = 0;
    }
    private void Update()
    {
       
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
        }
    }

    private void MeltIce()
    {
        if (meltingTime < 0)
        {
            Destroy(this.gameObject);
        }
    }
}
