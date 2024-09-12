using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceBlock : MonoBehaviour
{
    [SerializeField] private float meltingTime = 3f;
    [SerializeField] private Animator animator;
    [SerializeField] private float meltSpeed = 1f;

    private void Start()
    {
        animator.speed = 0;
    }
    public void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.tag == "sun")
        {
            meltingTime -= Time.deltaTime;
            animator.speed = meltSpeed;
           
        }

        MeltIce();
    }

    public void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "sun")
        {
            animator.speed = 0f;
        }
    }

    private void MeltIce()
    {
        //if (meltingTime < 0)
        //{
        //    Destroy(this.gameObject.transform.gameObject);
        //}
    }
}
