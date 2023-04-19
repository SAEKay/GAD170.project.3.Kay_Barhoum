using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace KayBarhoum
{



    public class PlayerController : MonoBehaviour
    {
        private float horizontal;
        public float speed = 8f;
        public float jumpingPower = 16f;
        
        private bool isFacingRight = true;
        [SerializeField] private Rigidbody2D rb;
        [SerializeField] private Transform groundCheck;
        [SerializeField] private LayerMask groundLayer;
        //private Animator animator; //References the players animation animator

        public float deathDelay = 2f; //delay time before player dies

        // Start is called before the first frame update
        void Start()
        {
            //soundManager = GetComponent<PlayerSoundManager>();
            //if (soundManager == null)
            //{
            //    Debug.LogWarning("PlayerSoundManager component not found");
            //}

            //Gets reference to the animator component
            //animator = GetComponent<Animator>();

        }

        // Update is called once per frame
        void Update()
        {


            horizontal = Input.GetAxisRaw("Horizontal");

            if (Input.GetButtonDown("Jump") && IsGrounded())
            {
                rb.velocity = new Vector2(rb.velocity.x, jumpingPower);

                //Play jump sounds
                //soundManager.PlayerJumpSound();
            }

            //set jump animation
            //animator.SetBool("isJumping", true);

            if (Input.GetButtonUp("Jump") && rb.velocity.y > 0f)
            {
                rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);
            }



            Flip();


            // Sets the running animation for if the player is moving
            if (IsGrounded() && Mathf.Abs(horizontal) > 0f)
            {
                //animator.SetBool("isRunning", true);
            }
            else
            {
                //animator.SetBool("isRunning", false);
            }


            //Set animation back to idle
            //if (animator.GetBool("isJumping") && rb.velocity.y < 0.1f && IsGrounded())
            //{
              //  animator.SetBool("isJumping", false);
            //}
        }

        private void FixedUpdate()
        {
            rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);

        }


        private bool IsGrounded()
        {
            return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
        }


        private void Flip()
        {
            if (isFacingRight && horizontal < 0f || !isFacingRight && horizontal < 0f)
            {
                isFacingRight = !isFacingRight;
                Vector3 localScale = transform.localScale;
                localScale.x *= -1f;
                transform.localScale = localScale;
            }
        }

        //handle collisions between player and other objects
        //private void OnTriggerEnter2D(Collider2D collision)
        //{
        //    if (collision.gameObject.CompareTag("SideCollision"))
        //    {
        //        //Get a reference to the PlayerLives component
        //        PlayerLives playerLives = GetComponent<PlayerLives>();

        //        //Call LoseALife Method
        //        playerLives.LoseALife();

        //        // trigger death animation
        //        animator.SetTrigger("Death");

        //        //Disable the players rigidbody2d so it cant move
        //        rb.simulated = false;

        //        //play death sound
        //        soundManager.PlayerDeathSound();

        //        //Reload the scene after delay
        //        StartCoroutine(ReloadSceneAfterDelay(deathDelay));
        //    }
        //}

        //coroutine to reload the scene after delay
        //private IEnumerator ReloadSceneAfterDelay(float delay)
        //{
        //    yield return new WaitForSeconds(delay);
        //    SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        //}

    }









}



