using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Animator animator;
    private Rigidbody2D body;

    private float xInput, yInput;
    private bool isMoving;

    private static bool playerExists;

    private float playerSpeed; //for now will just be = what is in Player will create a calculation though later

    private float playerDex; //for now will just be = what is in Player will create a calculation though later
    private float attackSpeedCounter;
    private float attackSpeed;

    private float xAim, yAim;
    public Transform projectilePrefab;
    public Transform shotPoint;

    void Start()
    {
        animator = GetComponent<Animator>();
        body = GetComponent<Rigidbody2D>();
        isMoving = false;

        //might just end up making an dontdestroyonload script to throw on continous objects instead of throwing this in every script
        if (!playerExists)
        {
            playerExists = true;
            DontDestroyOnLoad(transform.gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Update()
    {
        FetchStats();
        Movement();
        AimAndShoot();
    }

    private void Movement()
    {
        //Get Input
        xInput = Input.GetAxisRaw("Horizontal");
        yInput = Input.GetAxisRaw("Vertical");

        //Set isMoving to true if x/yInput have a value other than 0
        isMoving = (xInput != 0 || yInput != 0);
        animator.SetBool("isMoving", isMoving);

        //Set Velocity if moving is true and remove if moving is false
        if (isMoving)
        {
            body.velocity = new Vector2(xInput * playerSpeed, yInput * playerSpeed);

            //Set animator values of x/yInput for animator
            animator.SetFloat("xInput", xInput);
            animator.SetFloat("yInput", yInput);
        } else {
            body.velocity = Vector2.zero;
        }

    }

    //Will change this so that the prefab used is changed based on weapon equipped eventually
    private void AimAndShoot()
    {
        //Find position of mouse (right,left,up,down)
        Vector2 mousePosition = new Vector2(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y);
        xAim = (mousePosition.x - shotPoint.position.x);
        yAim = (mousePosition.y - shotPoint.position.y);

        //Create way to move shotPoint in front of character here so animation looks smoother (may have to do this in the shotPoint rotation function

        //Fire Projectile
        attackSpeed = 1 / playerDex;
        if (attackSpeedCounter <= 0)
        {
            if (Input.GetButton("Fire1"))
            {
                animator.SetBool("isAttacking", true);
                animator.SetFloat("xAim", xAim);
                animator.SetFloat("yAim", yAim);

                Instantiate(projectilePrefab, shotPoint.position, shotPoint.rotation);
                attackSpeedCounter = attackSpeed;
            } else {
                animator.SetBool("isAttacking", false);
            }
        } else {
            attackSpeedCounter -= Time.deltaTime;
        }

    }

    private void FetchStats()
    {
        //Fetch Player Stats so they stay up to date
        Player player = FindObjectOfType<Player>();

        playerSpeed = player.agility;
        playerDex = player.dexterity;
    }
}
