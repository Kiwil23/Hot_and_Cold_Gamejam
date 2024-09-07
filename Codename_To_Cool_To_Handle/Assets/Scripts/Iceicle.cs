using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Iceicle : MonoBehaviour
{
    [SerializeField] private GameObject icicleToDestroy;
   private Rigidbody2D m_rigidbody2D;

    [SerializeField] private float meltingTime = 3f;
   [SerializeField] private Animator m_animator;
    [SerializeField] private float animatorSpeed;
    [SerializeField] private Vector3 stopPosition;
    private Collider2D[] colList;
    [SerializeField] private PlayerHealth playerHealth;
    private bool isPierced = false;
    private void Start()
    {
        colList = GetComponentsInChildren<Collider2D>();
        m_rigidbody2D = GetComponent<Rigidbody2D>();
        m_rigidbody2D.isKinematic = true;
        stopPosition = new Vector3(this.gameObject.transform.localPosition.x, stopPosition.y, this.gameObject.transform.localPosition.z);
    }

   private void Update()
    {
        if(this.gameObject.transform.localPosition.y < stopPosition.y)
        {
            m_rigidbody2D.isKinematic = true;
            m_rigidbody2D.velocity = new Vector2(0, 0);
            isPierced = true;
        }
    }

    public void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.tag == "sun")
        {
            meltingTime -= Time.deltaTime;
            //m_animator.speed = animatorSpeed;
        }
        if(icicleToDestroy != null)
        {
            MeltIceicle();
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" && !isPierced)
        {
            playerHealth.SpikePierce();          
        }
    }

    private void MeltIceicle()
    {
        if (meltingTime < 0)
        {            
                m_rigidbody2D.isKinematic = false;
                Destroy(icicleToDestroy);
            Destroy(colList[0]);

        }
    }
}
