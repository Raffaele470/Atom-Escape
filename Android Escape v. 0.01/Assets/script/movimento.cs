using System.Collections;
using UnityEngine;
using UnityEngine.UI;

using UnityEngine.InputSystem;

public class movimento : MonoBehaviour
{

    public GameObject player;

    Animator animator;

    Rigidbody2D playerRigidBody;


    public float jumpForce = 1000000f;
    public float jumpGravity; //new add
    public float fallGravity; //new add

    private float canJump = 0f;
    private float canSlide = 0f;

    public float speed;
    private int direction; //if 1 is right, if -1 is left


    public float timeToHold;


    private float spacePressedTime = 0;
    private bool spaceHeld;
    private float minimumHeldDuration = 0.5f;


    public float dashingPower;
    private float dashingTime = 0.05f;
    private float dashingCooldown = 1.1f;

    public bool isJumping;
    public bool isDashing;
    public bool isRunning;

    PlayerHealthManager playerHealthManager;

    public Slider energyBar;
    Animator sliderAnimator;

    public ParticleSystem dust;
    public ParticleSystem dashFx;
    public TrailRenderer dashTrailFx;

    public bool isOnFloor;

    ShakeFx cameraShakeScript;
    public GameObject camera;

    public bool stopped;

    public bool isOnPause;

    //audio

    [SerializeField]
    private AudioSource jumping;
    [SerializeField]
    private AudioSource dashing;
    [SerializeField]
    private AudioSource walking;
    [SerializeField]
    private AudioSource changeDir;

    KeyCode currentKeyPressed;

    void Start()
    {
        playerRigidBody = GetComponent<Rigidbody2D>();
        direction = 1;

        isJumping = false;
        isDashing = false;
        animator = GetComponent<Animator>();

        playerHealthManager = player.GetComponent<PlayerHealthManager>();
        sliderAnimator = energyBar.GetComponent<Animator>();

        cameraShakeScript = camera.GetComponent<ShakeFx>();

        isOnPause = false;
        stopped = false;
        walking.Play();
    }

    private void FixedUpdate()
    {
        transform.Translate(new Vector3(direction, 0, 0) * speed * Time.deltaTime);
    }

    void Update()
    {

        if (Time.time > canSlide)
        {
            IncreaseEnergyBar();
        }

        if (playerRigidBody.velocity.y < 0) //new
        {
            playerRigidBody.gravityScale = fallGravity;
        }



        //-----------------------------------------------|
        //Controllo tasti da tastiera

        /* OLD SYSTEM
        if (Input.GetKeyDown(KeyCode.Space) && !isJumping && !isDashing &&!stopped) // Use has pressed the Space key. We don't know if they'll release or hold it, so keep track of when they started holding it.
        {
            spacePressedTime = Time.timeSinceLevelLoad;
            spaceHeld = false;
        }
        */

        //NEW SYSTEM
        if ((Keyboard.current.anyKey.wasPressedThisFrame) && (!Keyboard.current.pKey.isPressed) && !isJumping && !isDashing && !stopped) // Use has pressed the Space key. We don't know if they'll release or hold it, so keep track of when they started holding it.
        {
            spacePressedTime = Time.timeSinceLevelLoad;
            spaceHeld = false;
        }




        /* OLD SYSTEM
        else if (Input.GetKeyUp(KeyCode.Space) && !isJumping && !isDashing && !stopped)  // Player has released the space key without holding it. Perform the action for when Space is pressed
        {   
            if (!spaceHeld)
            {
                if (Time.time > canJump)
                {
                    isJumping = true;

                    jumping.Play();

                    animator.SetBool("jump", true);
                    animator.SetBool("isOnGround", false);
                    playerRigidBody.AddForce(Vector3.up * jumpForce, ForceMode2D.Impulse);
                    playerRigidBody.gravityScale = jumpGravity; //new add
                    canJump = Time.time + 1f;
                }        
            }
            spaceHeld = false;
        }
        */

        else if ((Keyboard.current.anyKey.wasReleasedThisFrame) && (!Keyboard.current.pKey.wasReleasedThisFrame) && !Input.GetKey("p") && !isJumping && !isDashing && !stopped)  // Player has released the space key without holding it. Perform the action for when Space is pressed
        {
            if (!spaceHeld)
            {
                if (Time.time > canJump)
                {
                    isJumping = true;

                    jumping.Play();

                    animator.SetBool("jump", true);
                    animator.SetBool("isOnGround", false);
                    playerRigidBody.AddForce(Vector3.up * jumpForce, ForceMode2D.Impulse);
                    playerRigidBody.gravityScale = jumpGravity; //new add
                    canJump = Time.time + 1f;
                }
            }
            spaceHeld = false;
        }


        /*
        //OLD SYSTEM
        if (Input.GetKey(KeyCode.Space) && !isJumping && !isDashing && !stopped)
        {
            if (Time.timeSinceLevelLoad - spacePressedTime > minimumHeldDuration)  // Player has held the Space key for seconds. Consider it "held"
            {

                    if (Time.time > canSlide)
                    {                             
                        isDashing = true;

                        dashing.Play();

                        animator.SetBool("dash", true);
                        StartCoroutine(Dash());
                        spaceHeld = true;
                        canSlide = Time.time + 5f;
                    }
                
                 
            }
        }
        */
        //NEW SYSTEM
        if (Keyboard.current.anyKey.isPressed && (!Keyboard.current.pKey.isPressed) && !isJumping && !isDashing && !stopped)
        {
            if (Time.timeSinceLevelLoad - spacePressedTime > minimumHeldDuration)  // Player has held the Space key for seconds. Consider it "held"
            {

                if (Time.time > canSlide)
                {
                    isDashing = true;

                    dashing.Play();

                    animator.SetBool("dash", true);
                    StartCoroutine(Dash());
                    spaceHeld = true;
                    canSlide = Time.time + 5f;
                }


            }
        }
        //---------------------------------------|

        //CONTROLLO TASTI CONTROLLER

        if (Gamepad.current != null) //verifica se controller connesso
        {
            if ((Gamepad.current.aButton.wasPressedThisFrame || Gamepad.current.bButton.wasPressedThisFrame || Gamepad.current.xButton.wasPressedThisFrame || Gamepad.current.yButton.wasPressedThisFrame) && !isJumping && !isDashing && !stopped) // Use has pressed the Space key. We don't know if they'll release or hold it, so keep track of when they started holding it.
            {
                spacePressedTime = Time.timeSinceLevelLoad;
                spaceHeld = false;
            }


            else if ((Gamepad.current.aButton.wasReleasedThisFrame || Gamepad.current.bButton.wasReleasedThisFrame || Gamepad.current.xButton.wasReleasedThisFrame || Gamepad.current.yButton.wasReleasedThisFrame) && !isJumping && !isDashing && !stopped)  // Player has released the space key without holding it. Perform the action for when Space is pressed
            {
                if (!spaceHeld)
                {
                    if (Time.time > canJump)
                    {
                        isJumping = true;

                        jumping.Play();

                        animator.SetBool("jump", true);
                        animator.SetBool("isOnGround", false);
                        playerRigidBody.AddForce(Vector3.up * jumpForce, ForceMode2D.Impulse);
                        playerRigidBody.gravityScale = jumpGravity; //new add
                        canJump = Time.time + 1f;
                    }
                }
                spaceHeld = false;
            }


            if ((Gamepad.current.aButton.isPressed || Gamepad.current.bButton.isPressed || Gamepad.current.xButton.isPressed || Gamepad.current.yButton.isPressed) && !isJumping && !isDashing && !stopped)
            {
                if (Time.timeSinceLevelLoad - spacePressedTime > minimumHeldDuration)  // Player has held the Space key for seconds. Consider it "held"
                {
                    if (Time.time > canSlide)
                    {
                        isDashing = true;

                        dashing.Play();

                        animator.SetBool("dash", true);
                        StartCoroutine(Dash());
                        spaceHeld = true;
                        canSlide = Time.time + 5f;
                    }
                }
            }
        }




        if (!isJumping && !isDashing)
        {
            isRunning = true;
        }

        else if (isJumping || isDashing)
        {
            isRunning = false;
        }


        if (isOnFloor)
        {
            CreateDustFx();
        }

        if (!isOnFloor)
        {
            StopDustFx();
        }




        if (isDashing)
        {
            CreateDashFx();
            dashTrailFx.gameObject.SetActive(true);
            cameraShakeScript.activeShaking();
        }

        if (!isDashing)
        {
            dashTrailFx.gameObject.SetActive(false);
        }



        if (isRunning && isOnFloor && !isOnPause && !stopped)
        {
            walking.mute = false;
        }

        if (!isRunning || !isOnFloor || isOnPause || stopped)
        {
            walking.mute = true;
        }
    }

    private IEnumerator Dash()  //allow player to slide/dash
    {

        playerRigidBody.velocity = new Vector2(transform.localScale.x * dashingPower, 0f);

        DecreaseEnergyBar();



        yield return new WaitForSeconds(dashingTime);
        yield return new WaitForSeconds(dashingCooldown);
        isDashing = false;
        animator.SetBool("dash", false);
    }



    private void OnCollisionEnter2D(Collision2D collision)  //when player touch the wall
    {
        if (collision.gameObject.tag == "wall")
        {

            changeDir.Play();

            if (direction == -1)
            {
                direction = 1;

                Vector3 currentScale = player.transform.localScale;
                currentScale.x *= -1;
                player.transform.localScale = currentScale;

            }

            else if (direction == 1)
            {
                direction = -1;

                Vector3 currentScale = player.transform.localScale;
                currentScale.x *= -1;
                player.transform.localScale = currentScale;

            }
        }


        if (collision.gameObject.tag == "floor")
        {
            isOnFloor = true;
            isJumping = false;
            animator.SetBool("isOnGround", true);
            animator.SetBool("jump", false);
        }


        if (playerHealthManager.life <= 0)
        {
            animator.SetBool("run", false);
            animator.SetBool("dash", false);
            animator.SetBool("jump", false);
            speed = 0;
            jumpForce = 0;
            dashingPower = 0;
        }

    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "floor")
        {
            isOnFloor = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "floor")
        {
            isOnFloor = false;
        }
    }


    void IncreaseEnergyBar()
    {
        sliderAnimator.SetTrigger("IncreaseBar");
    }

    void DecreaseEnergyBar()
    {
        sliderAnimator.ResetTrigger("IncreaseBar");
        sliderAnimator.SetTrigger("DecreaseBar");
    }

    void CreateDustFx()
    {
        dust.Play();
    }

    void CreateDashFx()
    {
        dashFx.Play();
    }

    void StopDustFx()
    {
        dust.Stop();
    }

    void OnGUI()
    {
        Event e = Event.current;
        if (e.isKey)
        {
            currentKeyPressed = e.keyCode;
        }
    }

}
