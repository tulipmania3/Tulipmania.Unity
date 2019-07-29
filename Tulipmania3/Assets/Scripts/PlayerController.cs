using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Direction
{
    Up,
    Down,
    Left,
    Right,
    Idle
}

public class PlayerController : MonoBehaviour
{

    public float speed;
    public GameObject greenhouseUI;


    Rigidbody2D rigidbody2d;
    Animator animator;
    Direction direction = Direction.Idle;
    Direction oldDirection = Direction.Idle;

    GreenhouseController greenhouse;

    // Start is called before the first frame update
    void Start()
    {

        rigidbody2d = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();

        animator.SetFloat("Move X", -0.01f);
        animator.SetFloat("Move Y", -0.1f);
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        if(Input.GetKeyDown(KeyCode.F)){
            if(greenhouse != null){
                openGreenhouseUI();
            }
        }
    }

    public void SetGreenhouse(GreenhouseController _greenhouse){
        greenhouse = _greenhouse;
    }

    //Horrible Move Logic
    private void Move()
    {
        
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
        {
            direction = Direction.Up;
        }
        if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
        {
            direction = Direction.Left;
        }
        if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
        {
            direction = Direction.Down;
        }
        if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
        {
            direction = Direction.Right;
        }

        switch (direction)
        {
            case Direction.Up:
                if (Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.UpArrow))
                {
                    direction = Direction.Idle;
                }
                break;
            case Direction.Left:
                if (Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.LeftArrow))
                {
                    direction = Direction.Idle;
                }
                break;
            case Direction.Down:
                if (Input.GetKeyUp(KeyCode.S) || Input.GetKeyUp(KeyCode.DownArrow))
                {
                    direction = Direction.Idle;
                }
                break;
            case Direction.Right:
                if (Input.GetKeyUp(KeyCode.D) || Input.GetKeyUp(KeyCode.RightArrow))
                {
                    direction = Direction.Idle;
                }
                break;
            default:
                break;
        }

        Vector2 position = rigidbody2d.position;

        switch (direction)
        {
            case Direction.Up:
                position.y = position.y + speed * vertical * Time.deltaTime;
                animator.SetFloat("Move X", 0);
                animator.SetFloat("Move Y", vertical);
                break;
            case Direction.Left:
                position.x = position.x + speed * horizontal * Time.deltaTime;
                animator.SetFloat("Move X", horizontal);
                animator.SetFloat("Move Y", 0);
                break;
            case Direction.Down:
                position.y = position.y + speed * vertical * Time.deltaTime;
                animator.SetFloat("Move X", 0);
                animator.SetFloat("Move Y", vertical);
                break;
            case Direction.Right:
                position.x = position.x + speed * horizontal * Time.deltaTime;
                animator.SetFloat("Move X", horizontal);
                animator.SetFloat("Move Y", 0);
                break;
            case Direction.Idle:
                switch (oldDirection)
                {
                    case Direction.Up:
                        animator.SetFloat("Move X", -0.1f);
                        animator.SetFloat("Move Y", 0.5f);
                        break;
                    case Direction.Left:
                        animator.SetFloat("Move X", -0.5f);
                        animator.SetFloat("Move Y", -0.1f);
                        break;
                    case Direction.Down:
                        animator.SetFloat("Move X", -0.1f);
                        animator.SetFloat("Move Y", -0.5f);
                        break;
                    case Direction.Right:
                        animator.SetFloat("Move X", 0.5f);
                        animator.SetFloat("Move Y", 0.1f);
                        break;
                    default:
                        break;

                }
                break;
        }

        if (direction != oldDirection)
        {
            oldDirection = direction;
        }

        rigidbody2d.MovePosition(position);
    }

    public void closeGreenhouseUI(){
        greenhouseUI.SetActive(false);
    }

    public void openGreenhouseUI() {
        greenhouseUI.SetActive(true);
    }
}
