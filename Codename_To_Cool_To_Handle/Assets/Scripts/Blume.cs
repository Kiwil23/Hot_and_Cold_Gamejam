using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class Blume : MonoBehaviour
{
    [SerializeField] private float meltingTime = 3f;
    [SerializeField] private Animator animator;
    [SerializeField] private float meltSpeed = 1f;
    [SerializeField] private float initationsTime;
    [SerializeField] bool isRdy = false;
    [SerializeField] private Shake1 shake1;
    [SerializeField] private GameObject plattform;
    private void Start()
    {
        animator.speed = 0;
    }

    private void Update()
    {
        if(animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1)
        {
            plattform.SetActive(true);
        }
    }
    public void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.tag == "sun")
        {
            if (shake1)
                shake1.enabled = true;

            if (isRdy)
            {
                meltingTime -= Time.deltaTime;
                animator.speed = meltSpeed;
            }

            else
            {
                initationsTime -= Time.deltaTime;
                if (initationsTime < 0)
                {
                    isRdy = true;
                    if(shake1)
                    shake1.KillObj();
                }
            }


        }

        MeltIce();
    }

    public void OnTriggerExit2D(Collider2D other)
    {
        if(shake1)
        shake1.enabled = false;

        if (other.gameObject.tag == "sun")
        {
            animator.speed = 0f;
        }
    }

    private void MeltIce()
    {
        //if (meltingTime < 0)
        //{
        //    Destroy(this.gameObject.transform.parent.gameObject);
        //}
    }
}
