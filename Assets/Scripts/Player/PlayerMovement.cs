using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private const float MOVE_SPEED = 12f;
    private Rigidbody2D compRB;
    private Vector2 movement;

    private void Awake()
    {
        compRB = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (!PauseControl.gameIsPaused)
        {
            MovementInput();
            Rotate();
        }
    }
    private void FixedUpdate()
    {
        compRB.velocity = movement * MOVE_SPEED;
    }
    void MovementInput()
    {
        float mx = Input.GetAxisRaw("Horizontal");
        float my = Input.GetAxisRaw("Vertical");

        movement = new Vector2(mx, my).normalized;
    }
    void Rotate()
    {
        var dir = Input.mousePosition - Camera.main.WorldToScreenPoint(transform.position);
        var angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle-90f, Vector3.forward);
    }
}
