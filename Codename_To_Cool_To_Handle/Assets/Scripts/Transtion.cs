using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Transtion : MonoBehaviour
{
    [SerializeField] private GameSceneManager gameSceneManager;
    [SerializeField] private PlayerHealth playerHealth;
    private void OnTriggerEnter2D(Collider2D other)
    {
        HealthBar.health = playerHealth.health;
        gameSceneManager.restartScene("Overworld");
    }
}
