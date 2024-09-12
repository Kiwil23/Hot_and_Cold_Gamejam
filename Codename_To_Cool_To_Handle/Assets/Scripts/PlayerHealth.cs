using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public int health = 3;
    private bool isInvincible = false;
    [SerializeField] private float invincibilityTime = 2f;
    private float invincibilityTimer = 0f;
    [SerializeField] private GameSceneManager gameSceneManager;
    [SerializeField] private int icicleDmg = 1;
    [SerializeField] private SpriteRenderer playerSpriteRenderer;
    [SerializeField] private Color color;
    [SerializeField] private PlayerMovement playerMovement;
    [SerializeField] private Vector2 playerBounce;
    [SerializeField] private float blinkIntervall = 1f;
    [SerializeField] private PlayerSounds playerSounds;
    private float blinkTimer = 0f;
    [SerializeField] private GameObject healthbar;
    [SerializeField] private List<GameObject> leben;
    private int tempHealth;

    private void Start()
    {
      
        health = HealthBar.health;

        
        if(health == 0)
        {
            leben[0].SetActive(true);
        }

        if (health == 1)
        {
            leben[0].SetActive(true);
            leben[1].SetActive(true);
        }

        if (health == 2)
        {
           
            leben[2].SetActive(true);
            leben[1].SetActive(true);
            leben[0].SetActive(true);
        }
        if (health == 3)
        {
            leben[3].SetActive(true);
            leben[2].SetActive(true);
            leben[1].SetActive(true);
            leben[0].SetActive(true);
        }
    }

    private void Update()
    {
        healthbar.transform.position = new Vector3(this.gameObject.transform.position.x - 0.037f, this.gameObject.transform.position.y -.5f, -3);
        MakeInvincible(Time.deltaTime);
        if (health < 0)
        {
            health = 3;
            HealthBar.health = health;  
            gameSceneManager.restartScene(SceneManager.GetActiveScene().name);
        }
    }

    private void CharacterBlink(float time)
    {
        blinkTimer += time;
        if (blinkTimer < blinkIntervall)
        {
            color.a = 0.5f;
            playerSpriteRenderer.color = color;
            leben[health + 1].SetActive(false);
        }
        else if (blinkTimer < blinkIntervall * 2)
        {
            color.a = 1f;
            playerSpriteRenderer.color = Color.white;
            leben[health + 1].SetActive(true);
        }
        if (blinkTimer > blinkIntervall * 2)
        {
            blinkTimer = 0f;
       }
    }

    public void SpikePierce()
    {
        if (!isInvincible)
        {
            playerSounds.PlayDMGSound();
           health -= icicleDmg;
            isInvincible = true;
            Vector2 temp = new Vector2(playerBounce.x * playerMovement.getPlayerDirection(), playerBounce.y);
            if (temp.y == 0)
            {
                temp.y = playerBounce.y;
            }
            playerMovement.m_rigidbody.velocity = temp;
        }
    }

    private void MakeInvincible(float time)
    {
        if (isInvincible)
        {
            invincibilityTimer += time * 1f;
            CharacterBlink(time);
          healthbar.SetActive(true);
        }
        else
        {
            color.a = 1f;
            playerSpriteRenderer.color = Color.white;
          

            healthbar.SetActive(false);
        }

        if (invincibilityTimer > invincibilityTime)
        {
            isInvincible = false;
            invincibilityTimer = 0;
            leben[health + 1].SetActive(false);

        }
    }

}
