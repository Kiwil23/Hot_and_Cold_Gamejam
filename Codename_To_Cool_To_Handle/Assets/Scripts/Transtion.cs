using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Transtion : MonoBehaviour
{
    [SerializeField] private GameSceneManager gameSceneManager;
    private void OnTriggerEnter2D(Collider2D other)
    {
        gameSceneManager.restartScene("Overworld");
    }
}
