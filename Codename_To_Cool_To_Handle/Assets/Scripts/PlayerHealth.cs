using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    private int health = 100;
    private bool isInvincible = false;
    [SerializeField] private float invincibilityTime = 2f;
    private float invincibilityTimer = 0f;
    [SerializeField] private GameSceneManager gameSceneManager;
    [SerializeField] private int icicleDmg = 25;
    [SerializeField] private SpriteRenderer playerSpriteRenderer;
    [SerializeField] private Color color;
    [SerializeField] private PlayerMovement playerMovement;
    [SerializeField] private Vector2 playerBounce;
    [SerializeField] private float blinkIntervall = 1f;
    [SerializeField] private PlayerSounds playerSounds;
    private float blinkTimer = 0f;

    private void Update()
    {
        MakeInvincible(Time.deltaTime);
        if (health <= 0)
        {
            gameSceneManager.restartScene("IceCave");
        }
    }

    private void CharacterBlink(float time)
    {
        blinkTimer += time;
        if (blinkTimer < blinkIntervall)
        {
            color.a = 0.5f;
            playerSpriteRenderer.color = color;
        }
        else if (blinkTimer < blinkIntervall * 2)
        {
            color.a = 1f;
            playerSpriteRenderer.color = Color.white;
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
        }
        else
        {
            color.a = 1f;
            playerSpriteRenderer.color = Color.white;
        }

        if (invincibilityTimer > invincibilityTime)
        {
            isInvincible = false;
            invincibilityTimer = 0;
        }
    }
}
