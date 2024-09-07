using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DangerSpikes : MonoBehaviour
{
    [SerializeField] private PlayerHealth playerHealth;

    public void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            playerHealth.SpikePierce();
        }
    }

}
