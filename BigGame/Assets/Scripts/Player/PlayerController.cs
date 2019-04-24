using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private Transform shotPoint;
    private float xAim, yAim;
    public Transform projectilePrefab;

    private Rigidbody2D body;
    private float xInput, yInput;
    private bool isMoving;

    private static bool playerExists;

    private float weaponDamage;
    private float fireRate;

    private float playerStrength;
    private float playerDexterity;
    private float playerSpeed;

    private float attackSpeedCounter;
    private float attackSpeed;

    private bool canShoot;

    private void Start()
    {
        animator = GetComponent<Animator>();
        body = GetComponent<Rigidbody2D>();
        isMoving = false;

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

    private void Update()
    {
        FetchStats(this.gameObject.GetComponent<Character>());
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
            //Allow players to move slowly for BIG PRECISION
            if (Input.GetKey(KeyCode.LeftShift))
            {
                if (xInput != 0 && yInput != 0)
                {
                    body.velocity = new Vector2((xInput * 1) * .7714f, (yInput * 1) * .7714f);
                }
                else
                {
                    body.velocity = new Vector2(xInput * 1, yInput * 1);
                }
            }
            //Normal movement
            else
            {
                if (xInput != 0 && yInput != 0)
                {
                    body.velocity = new Vector2((xInput * playerSpeed) * .7714f, (yInput * playerSpeed) * .7714f);
                }
                else
                {
                    body.velocity = new Vector2(xInput * playerSpeed, yInput * playerSpeed);
                }
            }
            //Set animator values of x/yInput for animator
            animator.SetFloat("xInput", xInput);
            animator.SetFloat("yInput", yInput);
        }
        else
        {
            body.velocity = Vector2.zero;
        }
    }

    //Will change this so that the prefab used is changed based on weapon equipped eventually
    private void AimAndShoot()
    {
        if (this.GetComponent<Character>().EquipmentPanel.isActiveAndEnabled || this.GetComponent<Character>().Inventory.isActiveAndEnabled || this.GetComponent<Character>().containerIsOpen /*|| this.GetComponent<Character>().TalentTree.isActiveAndEnabled*/)
        {
            canShoot = false;
        } else
        {
            canShoot = true;
        }
        
        if (canShoot)
        {
            //Find position of mouse (right,left,up,down)
            Vector2 mousePosition = new Vector2(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y);
            xAim = (mousePosition.x - shotPoint.position.x);
            yAim = (mousePosition.y - shotPoint.position.y);

            //Create way to move shotPoint in front of character here so animation looks smoother (may have to do this in the shotPoint rotation function

            //Fire Projectile
            attackSpeed = (1 / playerDexterity) / fireRate;
            if (attackSpeedCounter <= 0)
            {
                if (Input.GetButton("Fire1"))
                {
                    if (fireRate != 0)
                    {
                        animator.SetBool("isAttacking", true);
                        animator.SetFloat("xAim", xAim);
                        animator.SetFloat("yAim", yAim);

                        Instantiate(projectilePrefab, shotPoint.position, shotPoint.rotation);
                        attackSpeedCounter = attackSpeed;
                    }
                    else
                    {
                        Debug.Log("No Weapon Equipped!");
                    }
                }
                else
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

    //Maybe when fetching stats fetch the equipment slot for weapons instead of the player...

    public void FetchStats(Character stat)
    {
        playerSpeed = 1 + (stat.Agility.Value / 50);
        playerStrength = 1 + (stat.Strength.Value / 25);
        playerDexterity = 1 + (stat.Dexterity.Value / 25);

        weaponDamage = stat.WeaponDamage.Value;
        fireRate = stat.WeaponFireRate.Value;
    }
}