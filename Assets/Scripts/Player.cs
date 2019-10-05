using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    float moveSpeed;

    SpriteRenderer spriteRenderer;
    Rigidbody2D rigidbody2D;
    Animator animator;

    [SerializeField]
    float maxVel;

    Vector2 axis;

    bool btnJump;

    [SerializeField]
    float jumpForce;

    [SerializeField]
    float rayDistance;

    [SerializeField]
    LayerMask groundLayer;

    void Awake(){
        spriteRenderer = GetComponent<SpriteRenderer>();
        rigidbody2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
        rigidbody2D.AddForce(Vector2.right * axis.x * moveSpeed, ForceMode2D.Impulse);
        Vector2 currentVelocity = rigidbody2D.velocity;
        rigidbody2D.velocity = new Vector2(Mathf.Clamp(currentVelocity.x,-maxVel,maxVel), currentVelocity.y);
        
        //grounding
        RaycastHit2D hit = Physics2D.Raycast(transform.position, -transform.up, rayDistance, groundLayer);
        if(hit.collider){
            //jumping
            if(btnJump){
                rigidbody2D.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            }
        }


        
    }

    void Update(){
        axis = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        btnJump = Input.GetButtonDown("Jump");
    }

    void LateUpdate(){
        spriteRenderer.flipX =axis.x < 0 ? true : axis.x > 0 ? false : spriteRenderer.flipX;
        animator.SetFloat("axisX", Mathf.Abs(axis.x));
    }

    void OnDrawGizmos(){
        Gizmos.color = Color.red;
        Gizmos.DrawRay(transform.position, -transform.up * rayDistance);
    }

}
