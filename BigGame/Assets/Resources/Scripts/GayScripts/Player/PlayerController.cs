using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float moveSpeed;

    private Animator anim;
    private Rigidbody2D myRigidBody;

    private bool playerMoving;
    public Vector2 lastMove;
    private Vector2 moveInput;

    private static bool playerExists;

    public float attackSpeed;
    private float attackSpeedCounter;

    public GameObject projectile;
    public float projectileSpeed;

    public string startPoint;

    public bool canMove;

    private SFXManager sfxmanager;

	void Start () {
        anim = GetComponent<Animator>();
        myRigidBody = GetComponent<Rigidbody2D>();
        sfxmanager = FindObjectOfType<SFXManager>();

        if (!playerExists)
        {
            playerExists = true;
            DontDestroyOnLoad(transform.gameObject);
        } else {
            Destroy(gameObject);
        }
        canMove = true;

        lastMove = new Vector2(0, -1);
	}

    void Update()
    {
        playerMoving = false;

        if (!canMove)
        {
            myRigidBody.velocity = Vector2.zero;
            return;
        }

        moveInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized;

        if (moveInput != Vector2.zero)
        {
        myRigidBody.velocity = new Vector2(moveInput.x * moveSpeed, moveInput.y * moveSpeed);
        playerMoving = true;
        lastMove = moveInput;
        }
        else
        {
        myRigidBody.velocity = Vector2.zero;
        }

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
                Vector2 target = Camera.main.ScreenToWorldPoint(new Vector2(Input.mousePosition.x, Input.mousePosition.y));
                Vector2 myPos = new Vector2(transform.position.x, transform.position.y);
                Vector2 direction = target - myPos;
                direction.Normalize();
                Quaternion rotation = Quaternion.Euler(0, 0, Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 135);
                GameObject projectile1 = (GameObject)Instantiate(projectile, myPos, rotation);
                projectile1.GetComponent<Rigidbody2D>().velocity = direction * projectileSpeed;
                attackSpeedCounter = attackSpeed;
                anim.SetBool("Attack", true);
        }

        sfxmanager.playerMeleeAttack.Play();

        if(attackSpeedCounter > 0)
        {
            attackSpeedCounter -= Time.deltaTime;
        }

        if (attackSpeedCounter <= 0)
        {
            anim.SetBool("Attack", false);
        }



        anim.SetFloat("MoveX", Input.GetAxisRaw("Horizontal"));
        anim.SetFloat("MoveY", Input.GetAxisRaw("Vertical"));
        anim.SetBool("PlayerMoving", playerMoving);
        anim.SetFloat("LastMoveX", lastMove.x);
        anim.SetFloat("LastMoveY", lastMove.y);
    }
}
