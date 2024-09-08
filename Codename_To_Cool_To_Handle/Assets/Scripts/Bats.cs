using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bats : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private int direction;

    private void Start()
    {
        Invoke("KillBat", 120);
    }
    private void Update()
    {    
        if(transform.localScale.x > .4)
        {
            transform.Translate(new Vector3(direction * speed * Time.deltaTime, 0, 0));
        }
       else
        {
      transform.Translate(new Vector3(direction * (speed-2) * Time.deltaTime, 0, 0));
        }
    }

    private void KillBat()
    {
        Destroy(gameObject);
    }
}
