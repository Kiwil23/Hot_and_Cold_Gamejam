using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D m_rigidbody;
    public Transform groundCheck;
    public LayerMask groundLayer;

    [SerializeField] private float speed = 8f;
    [SerializeField] private float jumpingPower = 16f;
    private float horizontal;
    private bool isFacingRight = true;

    private void Awake()
    {
        m_rigidbody = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        m_rigidbody.velocity = new Vector2(horizontal * speed, m_rigidbody.velocity.y);

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
        if (contex.performed && CheckIsGrounded())
        {
            m_rigidbody.velocity = new Vector2(m_rigidbody.velocity.x, jumpingPower);
        }

        if(contex.canceled && m_rigidbody.velocity.y > 0f)
        {
            m_rigidbody.velocity = new Vector2(m_rigidbody.velocity.x, m_rigidbody.velocity.y * 0.5f);
        }
    }

    private bool CheckIsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
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
}
