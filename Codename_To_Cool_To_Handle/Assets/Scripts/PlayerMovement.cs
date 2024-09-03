using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D m_rigidbody;
    public Transform groundCheck;
    public LayerMask groundLayer;

    [SerializeField] private float Speed = 1f;
    [SerializeField] private float maxSpeed = 8f;
    [SerializeField] private float stoppAcceleration = 1f;


    [SerializeField] private float jumpingPower = 16f;
    private float horizontal;
    private bool isFacingRight = true;

    [SerializeField] private PlayerSounds playerSounds;

    private void Awake()
    {
        m_rigidbody = GetComponent<Rigidbody2D>();
    }
    private void FixedUpdate()
    {
        if(m_rigidbody.velocity.x > -maxSpeed && m_rigidbody.velocity.x < maxSpeed)
        {
            m_rigidbody.AddForce(new Vector2(horizontal * Speed,0));
        }

        if(!getIsPlayerMoving())
        {
            if(m_rigidbody.velocity.x > 0 && m_rigidbody.velocity.x > 0.5)
            m_rigidbody.velocity -= new Vector2(stoppAcceleration * Time.deltaTime,0);

            if (m_rigidbody.velocity.x < 0 && m_rigidbody.velocity.x < -0.5)
                m_rigidbody.velocity += new Vector2(stoppAcceleration * Time.deltaTime, 0);
        }
    }

    private void Update()
    {
        // Handle flipping the character based on movement direction
        if (!isFacingRight && horizontal > 0f)
        {
            Flip();
        }
        else if (isFacingRight && horizontal < 0f)
        {
            Flip();
        }
    }

    public void Jump(InputAction.CallbackContext contex)
    {
        if (contex.performed && getIsPlayerGrounded())
        {
            m_rigidbody.velocity = new Vector2(m_rigidbody.velocity.x, jumpingPower);
            playerSounds.playJump();
        }

        if (contex.canceled && m_rigidbody.velocity.y > 0f)
        {
            m_rigidbody.velocity = new Vector2(m_rigidbody.velocity.x, m_rigidbody.velocity.y * 0.5f);
        }

    }

    public bool getIsPlayerGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.3f, groundLayer);
    }

    private void Flip()
    {
        isFacingRight = !isFacingRight;
        Vector3 localScale = transform.localScale;
        localScale.x *= -1f;
        transform.localScale = localScale;
    }

    public void Move(InputAction.CallbackContext context)
    {
        horizontal = context.ReadValue<Vector2>().x;
    }

    public bool getIsPlayerMoving()
    {
        return horizontal != 0f;
    }

    public float getPlayerDirection()
    {
        return horizontal;
    }

    public Vector2 getVelocity()
    {
        return m_rigidbody.velocity;
    }
}
