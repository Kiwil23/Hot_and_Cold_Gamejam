using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour
{
    [SerializeField] private GameSceneManager gameSceneManager;
    
    public void startScene()
    {
        gameSceneManager.restartScene("IceCave");
    }
}
