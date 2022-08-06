using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player Instance { get; private set; }

    Rigidbody2D body;

    float horizontal;
    float vertical;
    float moveLimiter = 0.7f;

    public float runSpeed = 20.0f;

    public float attackInterval = 5f;

    Vector3 bottomLeftLimit;
    Vector3 topRightLimit;

    Animator animator;
    public bool CanMove { get; set; }
    bool isCurrentlyAttacking = false;

    public Transform attackPoint;
    PlayerProjectileManager playerProjectileManager;


    // Start is called before the first frame update

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }

    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        CanMove = true;
        playerProjectileManager = GetComponentInChildren(typeof(PlayerProjectileManager)) as PlayerProjectileManager;

        InvokeRepeating("Attack", 1f, 3f);
    }

    void Update()
    {
        CalculateInput();
    }

    void FixedUpdate()
    {
        MovePlayer();
    }

    void CalculateInput()
    {
        // Gives a value between -1 and 1
        horizontal = Input.GetAxisRaw("Horizontal"); // -1 is left
        vertical = Input.GetAxisRaw("Vertical"); // -1 is down
    }

    void MovePlayer()
    {
        if (CanMove)
        {
            if (horizontal != 0 && vertical != 0) // Check for diagonal movement
            {
                // limit movement speed diagonally, so you move at 70% speed
                horizontal *= moveLimiter;
                vertical *= moveLimiter;
            }
            body.velocity = new Vector2(horizontal * runSpeed, vertical * runSpeed);
            Animate();
        }
        else
        {
            animator.SetBool("IsPlayerMoving", false);
            body.velocity = Vector3.zero;
        }

        KeepTheCameraInside();
    }

    void Animate()
    {
        float moveX = body.velocity.x;
        float moveY = body.velocity.y;

        bool horizontalMovement = moveX > 0.1 || moveX < -0.1;
        bool verticalMovement = moveY > 0.1 || moveY < -0.1;

        if (verticalMovement || horizontalMovement)
        {
            animator.SetBool("IsPlayerMoving", true);
        }
        else
        {
            animator.SetBool("IsPlayerMoving", false);
        }

        animator.SetFloat("MoveX", body.velocity.x);
        animator.SetFloat("MoveY", body.velocity.y);

        if (Input.GetAxisRaw("Horizontal") == 1 || Input.GetAxisRaw("Horizontal") == -1 || Input.GetAxisRaw("Vertical") == 1 || Input.GetAxisRaw("Vertical") == -1)
        {
            animator.SetFloat("LastMoveX", Input.GetAxisRaw("Horizontal"));
            animator.SetFloat("LastMoveY", Input.GetAxisRaw("Vertical"));
        }
    }

    void KeepTheCameraInside()
    {
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, bottomLeftLimit.x, topRightLimit.x), Mathf.Clamp(transform.position.y, bottomLeftLimit.y, topRightLimit.y), transform.position.z);
    }

    public void SetBounds(Vector3 botLeft, Vector3 topRight)
    {
        bottomLeftLimit = botLeft + new Vector3(0.5f, 0.5f, 0f);
        topRightLimit = topRight + new Vector3(-0.5f, -0.5f, 0f);
    }

    void Attack()
    {
        if (!isCurrentlyAttacking)
        {
            animator.SetBool("IsAttacking", true);
            var state = animator.GetCurrentAnimatorStateInfo(0);
            isCurrentlyAttacking = true;
            Debug.Log("Attack interval: " + state.length);
            StartCoroutine(InstantiateProjectile(state.length));
        }
    }

    IEnumerator InstantiateProjectile(float interval)
    {
        //TODO: GET PROJECTILE FROM PROJECTILE MANAGER
        var projectile = playerProjectileManager.GetPoolObject();
        projectile.transform.position = attackPoint.transform.position;
        SetupProjectile(projectile);
        yield return new WaitForSeconds(interval);

        Debug.Log("Player Attacked ! Attack: " + animator.GetBool("IsAttacking") + " Moving: " + animator.GetBool("IsPlayerMoving"));
        animator.SetBool("IsAttacking", false);
        isCurrentlyAttacking = false;
    }

    void SetupProjectile(GameObject projectile)
    {
        float lastMoveX = animator.GetFloat("LastMoveX");
        float lastMoveY = animator.GetFloat("LastMoveY");

        if (lastMoveX > 0.1 && lastMoveX != 0 && lastMoveY == 0)
        {
            float zRotation = 180.0f;
            projectile.transform.eulerAngles = new Vector3(projectile.transform.eulerAngles.x, projectile.transform.eulerAngles.y, zRotation);
        }
        else if (lastMoveX < 0.1 && lastMoveX != 0 && lastMoveY == 0)
        {
            float zRotation = 0f;
            projectile.transform.eulerAngles = new Vector3(projectile.transform.eulerAngles.x, projectile.transform.eulerAngles.y, zRotation);
        }
        else if (lastMoveY > 0.1 && lastMoveY != 0 && lastMoveX == 0)
        {
            float zRotation = 270.0f;
            projectile.transform.eulerAngles = new Vector3(projectile.transform.eulerAngles.x, projectile.transform.eulerAngles.y, zRotation);
        }
        else if (lastMoveY < 0.1 && lastMoveY != 0 && lastMoveX == 0 || (lastMoveX == 0 && lastMoveY == 0))
        {
            float zRotation = 90.0f;
            projectile.transform.eulerAngles = new Vector3(projectile.transform.eulerAngles.x, projectile.transform.eulerAngles.y, zRotation);
        }
    }

    public int GetPlayerLastDirection()
    {
        return animator.GetFloat("LastMoveX") > 0 ? 1 : -1;
    }
}
