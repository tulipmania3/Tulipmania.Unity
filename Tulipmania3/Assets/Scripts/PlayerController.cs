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
    Rigidbody2D rigidbody2d;
    Animator animator;
    Direction direction = Direction.Idle;

    // Start is called before the first frame update
    void Start()
    {

        rigidbody2d = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        switch (direction)
        {
            case Direction.Up:
                if (vertical <= 0)
                {
                    ChangeDirection(horizontal, vertical);
                }
                break;
            case Direction.Left:
                if (horizontal >= 0)
                {
                    ChangeDirection(horizontal, vertical);
                }
                break;
            case Direction.Down:
                if (vertical >= 0)
                {
                    ChangeDirection(horizontal, vertical);
                }
                break;
            case Direction.Right:
                if (horizontal <= 0)
                {
                    ChangeDirection(horizontal, vertical);
                }
                break;
            case Direction.Idle:
                ChangeDirection(horizontal, vertical);
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
                animator.SetFloat("Move X", 0);
                animator.SetFloat("Move Y", 0);
                break;
        }

        rigidbody2d.MovePosition(position);
    }

    private void ChangeDirection(float horizontal, float vertical)
    {
        if (vertical > 0)
        {
            direction = Direction.Down;
        }
        else if (vertical < 0)
        {
            direction = Direction.Up;
        }
        else if (horizontal < 0)
        {
            direction = Direction.Right;
        }
        else if (horizontal > 0)
        {
            direction = Direction.Left;
        }
        else
        {
            direction = Direction.Idle;
        }
    }
}
