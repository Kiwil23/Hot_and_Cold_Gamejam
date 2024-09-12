using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class KillGame : MonoBehaviour
{
public void endAll()
    {
        Application.Quit();
    }
    public void menu()
    {
        SceneManager.LoadScene("Menu");
        HealthBar.health = 3;
    }

}
