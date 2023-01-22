using UnityEngine;

public class FinalPlayerMovement : MonoBehaviour
{
    Animator animator;

    public float speed;
    private int direction; //if 1 is right, if -1 is left

    public bool isRunning;

    public ParticleSystem dust;

    public bool isOnFloor;
    public bool stopped;

    public GameObject gate;
    public GameObject boxDetector;
    Animator gateAnimator;

    public GameObject finalBlackScreen;
    public GameObject boxDetector2;


    void Start()
    {
        direction = 1;

        animator = GetComponent<Animator>();
        gateAnimator = gate.GetComponent<Animator>();

        stopped = false;

    }

    private void FixedUpdate()
    {
        transform.Translate(new Vector3(direction, 0, 0) * speed * Time.deltaTime);
    }

    void Update()
    {

        if (isOnFloor)
        {
            CreateDustFx();
        }

        if (!isOnFloor)
        {
            StopDustFx();
        }

    }

        private void OnCollisionEnter2D(Collision2D collision)  //when player touch the wall
        {
                if (collision.gameObject.tag == "floor")
                {
                isOnFloor = true;
                animator.SetBool("isOnGround", true);
                animator.SetBool("jump", false);
                }

        if (collision.gameObject.tag == "openGate")
        {
            gateAnimator.SetBool("isOpened", true);
            boxDetector.SetActive(false);
        }

        if (collision.gameObject.tag == "Finish")
        {
            boxDetector2.SetActive(false);
            finalBlackScreen.SetActive(true);
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

    void CreateDustFx()
    {
        dust.Play();
    }


    void StopDustFx()
    {
        dust.Stop();
    }
}
