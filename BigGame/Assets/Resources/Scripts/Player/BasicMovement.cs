using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public Animator animator;
    private Rigidbody2D body;

    public Texture2D cursorTexture;
    private CursorMode cursorMode = CursorMode.Auto;
    public Vector2 hotSpot = Vector2.zero;

    public float playerSpeed;

    private float xInput, yInput;
    private bool isMoving;

    public Transform projectilePrefab;

    public Transform shotPoint;
    private float xAim, yAim;

    //Attack speed variables
    private float attackSpeedCounter;
    public float attackSpeed;

    void Start()
    {
        animator = GetComponent<Animator>();
        body = GetComponent<Rigidbody2D>();
        Cursor.SetCursor(cursorTexture, hotSpot, cursorMode);
        isMoving = false;
    }

	void Update () {
        Movement();
        AimAndShoot();
	}

    private void Movement()
    {
        //Get Input
        xInput = Input.GetAxisRaw("Horizontal");
        yInput = Input.GetAxisRaw("Vertical");

        // If isMoving, move with vector
        isMoving = (xInput != 0 || yInput != 0);
        if (isMoving)
        {
            body.velocity = new Vector2(xInput * playerSpeed, yInput * playerSpeed);
            animator.SetFloat("xInput", xInput);
            animator.SetFloat("yInput", yInput);
        } else
        {
            body.velocity = Vector2.zero;
        }

        animator.SetBool("isMoving", isMoving);
    }

    private void AimAndShoot()
    {
        //Find position of mouse (right,left,up,down)
        Vector2 mousePosition = new Vector2 (Camera.main.ScreenToWorldPoint (Input.mousePosition).x, Camera.main.ScreenToWorldPoint (Input.mousePosition).y);
        float xDirection = (mousePosition.x - shotPoint.position.x);
        float yDirection = (mousePosition.y - shotPoint.position.y);
        
        //Move shotPoint in front of character

        //Fire with attack speed control
        if (attackSpeedCounter <= 0)
        {
            if (Input.GetButton("Fire1"))
            {
                animator.SetBool("isAttacking", true);
                Instantiate(projectilePrefab, shotPoint.position, shotPoint.rotation);

                animator.SetFloat("xAim", xDirection);
                animator.SetFloat("yAim", yDirection);

                attackSpeedCounter = attackSpeed;
            } else
            {
                animator.SetBool("isAttacking", false);
            }
        }
        else
        {
            attackSpeedCounter -= Time.deltaTime;
        }
    }
}
