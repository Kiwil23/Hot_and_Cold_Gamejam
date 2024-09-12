using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathFall : MonoBehaviour
{
    [SerializeField] private GameSceneManager gameSceneManager;

    public void OnTriggerEnter2D(Collider2D collision)
    {
        gameSceneManager.restartScene("Overworld");
    }
}
