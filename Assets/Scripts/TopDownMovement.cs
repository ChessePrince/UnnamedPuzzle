using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopDownMovement : MonoBehaviour
{
    //References
    public Transform trnsGun;
    public Transform trnsGunTip;
    public SpriteRenderer sprRndDude;
    public SpriteRenderer sprRndGun;
    //Movement
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

            FlipSprites();
            //Shoot();
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
        var dir = Input.mousePosition - Camera.main.WorldToScreenPoint(trnsGun.position);
        var angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        trnsGun.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }
    void Shoot()
    {
        if (Input.GetMouseButtonDown(0))
        {
            //GameObject insantiatedMelon = Instantiate(melon, trnsGunTip.position, Quaternion.identity);
            //insantiatedMelon.GetComponent<FakeHeightObject>().Initialize(trnsGun.right * Random.Range(groundDispenseVelocity.x, groundDispenseVelocity.y), Random.Range(verticalDispenseVelocity.x, verticalDispenseVelocity.y));
        }
    }
    void FlipSprites()
    {
        var dir = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        if (dir.x > transform.position.x)
        {
            sprRndDude.flipX = false;
            sprRndGun.flipY = false;
        }
        else
        {
            sprRndDude.flipX = true;
            sprRndGun.flipY = true;
        }
    }
}
