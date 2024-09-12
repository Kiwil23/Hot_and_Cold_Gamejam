using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shake1 : MonoBehaviour
{
    private Vector2 startingPos;
   [SerializeField] private float speed = 1.0f;
   [SerializeField] private float intensity = 1.0f;

    [SerializeField] private SpriteRenderer realObj;


    private void Awake()
    {
        startingPos.x = transform.localPosition.x;
        startingPos.y = transform.localPosition.y;
    }

   private void Update()
    {
        transform.localPosition = startingPos+ (intensity * new Vector2(Random.Range(0, 2) * 2 - 1 * Mathf.PerlinNoise(speed * Time.time, 1), Random.Range(0, 2) * 2 - 1 * Mathf.PerlinNoise(speed * Time.time, 2)));
        
        if(this.enabled)
        {

                realObj.enabled = false;

        }
        else  
        {

                realObj.enabled = true;

        }
    }

    public void KillObj()
    {

        realObj.enabled = true;

        Destroy(gameObject);
    }
}
