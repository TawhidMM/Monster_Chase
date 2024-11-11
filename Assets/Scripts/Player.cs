using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Animator animator;
    private SpriteRenderer sr;
    private Rigidbody2D rigidbody;
    [SerializeField] private float moveForce = 10f;
    [SerializeField] private float jumpForce = 12f;
    private float movementX;
    private bool isGrounded;
    private string WALK_ANIMATION = "Walk";
    
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
        rigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMoveKeyBoard();
        AnimatePlayer();
        PlayerJump();
    }


    void PlayerMoveKeyBoard() {
        movementX = Input.GetAxisRaw("Horizontal");
        transform.position += new Vector3(movementX, 0, 0) * moveForce * Time.deltaTime;
    }

    void AnimatePlayer() {
        if (movementX > 0) {
            animator.SetBool(WALK_ANIMATION, true);
            sr.flipX = false;
        }
        else if (movementX < 0) {
            animator.SetBool(WALK_ANIMATION, true);
            sr.flipX = true;
        }
        else {
            animator.SetBool(WALK_ANIMATION, false);
        }
    }

    void PlayerJump() {
        if(Input.GetButtonDown("Jump") && isGrounded) {
            rigidbody.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
            isGrounded = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.CompareTag(Tags.GROUND_TAG)) {
            isGrounded = true;
        }
        if (other.gameObject.CompareTag(Tags.ENEMY_TAG)) {
            Destroy(gameObject);
        }
    }

}
