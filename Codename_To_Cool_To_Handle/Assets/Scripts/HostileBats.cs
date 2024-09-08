using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HostileBats : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private PlayerMovement playerMovement;
    [SerializeField] private float range;
    private bool isInRange = false;
    private void Update()
    {
        if(Vector3.Distance(transform.position, playerMovement.transform.position) < range)
        {
            isInRange = true;
        }
        if(isInRange )
        {
            transform.Translate(new Vector3(-1 * speed * Time.deltaTime, 0, 0));
        }      
    }
}
