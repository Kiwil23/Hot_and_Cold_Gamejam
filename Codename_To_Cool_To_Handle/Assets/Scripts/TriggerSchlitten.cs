using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class TriggerSchlitten : MonoBehaviour
{
    [SerializeField] private GameObject schlittenMitPingu;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private GameObject Player;
    [SerializeField] private GameObject Cam;
    [SerializeField] private GameObject endPoint;
    [SerializeField] private GameObject camSocket;
    [SerializeField] private Image glassesSprite;
    [SerializeField] private float velocity = 5f;
    public bool isEnd = false;
    private bool isFollow = false;
    public bool isTriggert = false;

    
    private void Update()
    {
        if(isFollow)
        {
            camSocket.transform.position = schlittenMitPingu.transform.position;
        }
        if (Vector2.Distance(endPoint.transform.position, schlittenMitPingu.transform.position) <= 3)
            if (rb.velocity.y <= 0 && isTriggert)
        {
            isEnd = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
     
        glassesSprite.enabled = false;
        isTriggert  = true;
        this.GetComponent<SpriteRenderer>().enabled = false;
        schlittenMitPingu.SetActive(true);
        Player.SetActive(false);
        Cam.GetComponent<CameraMovement>().enabled = false;
        Cam.transform.parent = camSocket.transform;
        camSocket.transform.position = schlittenMitPingu.transform.position;
        isFollow = true;
        if(Vector2.Distance(endPoint.transform.position, schlittenMitPingu.transform.position) <= 3)
        {
            if(velocity <= 0)
            {
                isEnd = true;
            }

            if(!isEnd)
            schlittenMitPingu.GetComponent<Rigidbody2D>().velocity = new Vector2(velocity -= Time.deltaTime *5,0);
        }
        else if(!isEnd)
        {
            schlittenMitPingu.GetComponent<Rigidbody2D>().velocity = new Vector2(velocity,0);
        }
    }
}
