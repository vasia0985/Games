using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hero : MonoBehaviour
{
    private Rigidbody2D rb;
    private SpriteRenderer sprite;
    [SerializeField] private float speed = 3f;
    [SerializeField] private float lives = 5;
    [SerializeField] private float jumpForce = 15f;
    private bool isGrounded = false;


    // Start is called before the first frame update
   
    private void Awake()
    {
         rb= GetComponent<Rigidbody2D>();
        sprite = GetComponentInChildren<SpriteRenderer>();

    }

    private void FixedUpdate()
    {
        CheckGround();
    }

    private void Update()
    {
        if (Input.GetButton("Horizontal"))
            Run();
        if (isGrounded && Input.GetButton("Jump"))
            Jump();
    }

    private void Run()
    {
        Vector3 dir = transform.right * Input.GetAxis("Horizontal");
       
        transform.position = Vector3.MoveTowards(transform.position, transform.position + dir, speed + Time.deltaTime);
        sprite.flipX = dir.x < 0.0f;
    }

    private void Jump()
    {
        
        rb.AddForce(transform.up * jumpForce, ForceMode2D.Impulse);
    }
     private void CheckGround()
    {
        Collider2D[] collider = Physics2D.OverlapCircleAll(transform.position, 0.3f);
        isGrounded = collider.Length > 1;
    }

}
