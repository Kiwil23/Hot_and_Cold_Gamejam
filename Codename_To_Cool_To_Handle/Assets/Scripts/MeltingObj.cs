using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeltingObj : MonoBehaviour
{
    [SerializeField] private float meltingTime = 3f;
    private Animator m_animator;
    [SerializeField] private float animatorSpeed;
    [SerializeField] private int meltingReaction = 0;

    private void Start()
    {
        //m_animator = this.GetComponent<Animator>();
        //animatorSpeed = animatorSpeed / meltingTime;
    }

    private void Update()
    {
        //m_animator.speed = animatorSpeed;
    }

    public void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.tag == "sun")
        {
            meltingTime -= Time.deltaTime;
        }

        switch (meltingReaction)
        {
            case 0:
                MeltIce();
                break;

            case 1:
                FallOfWall();
                break;
        }

    }

    private void MeltIce()
    {
        if (meltingTime < 0)
        {
            Debug.Log("ich bin geschnolzen");
            Destroy(this.gameObject);
        }
    }

    private void FallOfWall()
    {
        Debug.Log("Free Falling Down");
    }

}
