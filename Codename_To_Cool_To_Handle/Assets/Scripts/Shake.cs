using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shake : MonoBehaviour
{
    private Vector2 startingPos;
   [SerializeField] private float speed = 1.0f;
   [SerializeField] private float intensity = 1.0f;

    [SerializeField] private SpriteRenderer baseIceicle;
    [SerializeField] private SpriteRenderer fallOff;

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
            baseIceicle.enabled = false;
            fallOff.enabled = false;
        }
        else  
        {
            baseIceicle.enabled = true;
            fallOff.enabled = true;
        }
    }

    public void KillObj()
    {
        baseIceicle.enabled = true;
        fallOff.enabled= true;
        Destroy(gameObject);
    }
}
