using System.Collections;
using TMPro;
using UnityEngine;

public class PlayerHealthManager : MonoBehaviour
{

    public int life;

    public bool isDamaged;
    public bool isDeath = false;

    public bool deathBodyIsSpawned;

    Animator animator;

    SpriteRenderer PlayerChestSpriteRenderer;
    SpriteRenderer PlayerHeadSpriteRenderer;

    SpriteRenderer PlayerLeg1SpriteRenderer;
    SpriteRenderer PlayerLeg2SpriteRenderer;

    public Rigidbody2D playerAfterDeath;
    public Rigidbody2D deathFx;
    Vector3 addPosition;

    public TextMeshProUGUI lifeCounterText;


    [SerializeField]
    private AudioSource damageHit;



    void Start()
    {

        deathBodyIsSpawned = false;

        animator = GetComponent<Animator>();

        PlayerChestSpriteRenderer = transform.Find("chest").GetComponent<SpriteRenderer>();
        PlayerHeadSpriteRenderer = transform.Find("head").GetComponent<SpriteRenderer>();

        PlayerLeg1SpriteRenderer = transform.Find("leg 1").GetComponent<SpriteRenderer>(); 
        PlayerLeg2SpriteRenderer = transform.Find("leg 2").GetComponent<SpriteRenderer>();

        addPosition = new Vector3(0f, -1.5f, 0.0f);
    }


    void Update()
    {

        lifeCounterText.text = "x " + life.ToString();

        if (life <= 0)
        {
            isDeath = true;
            animator.SetBool("death", true);

           
            if (!deathBodyIsSpawned){


                Rigidbody2D fx = Instantiate(deathFx, transform.position-addPosition, transform.rotation);
                Destroy(fx.gameObject, 1.3f);
                Rigidbody2D e = Instantiate(playerAfterDeath, transform.position, transform.rotation);
                gameObject.SetActive(false);
                deathBodyIsSpawned = true;
            }
        }
    }


    private void OnCollisionEnter2D(Collision2D collision)  //when enemy touch the player and he's not dashing
    {

        if ((collision.gameObject.tag == "enemy") && !(animator.GetBool("dash")))
        {
            isDamaged = true;
            StartCoroutine(PlayerDamagedRoutine());
        }

        if (collision.gameObject.tag == "obstacle")
        {
            isDamaged = true;
            StartCoroutine(PlayerDamagedRoutine());
        }

        if ((collision.gameObject.tag == "obstacle_laser") && !(animator.GetBool("dash")))
        {
            isDamaged = true;
            StartCoroutine(PlayerDamagedRoutine());
        }

    }

    IEnumerator PlayerDamagedRoutine()
    {
        DamageHealth();
        yield return new WaitForSeconds(0.3f);
        PlayerChestSpriteRenderer.color = Color.red;
        PlayerHeadSpriteRenderer.color = Color.red;
        PlayerLeg1SpriteRenderer.color = Color.red;
        PlayerLeg2SpriteRenderer.color = Color.red;

        yield return new WaitForSeconds(0.2f);
        PlayerChestSpriteRenderer.color = Color.white;
        PlayerHeadSpriteRenderer.color = Color.white;
        PlayerLeg1SpriteRenderer.color = Color.white;
        PlayerLeg2SpriteRenderer.color = Color.white;

        yield return new WaitForSeconds(0.2f);
        PlayerChestSpriteRenderer.color = Color.clear;
        PlayerHeadSpriteRenderer.color = Color.clear;
        PlayerLeg1SpriteRenderer.color = Color.clear;
        PlayerLeg2SpriteRenderer.color = Color.clear;

        yield return new WaitForSeconds(0.2f);
        PlayerChestSpriteRenderer.color = Color.white;
        PlayerHeadSpriteRenderer.color = Color.white;
        PlayerLeg1SpriteRenderer.color = Color.white;
        PlayerLeg2SpriteRenderer.color = Color.white;

        yield return new WaitForSeconds(0.2f);
        PlayerChestSpriteRenderer.color = Color.clear;
        PlayerHeadSpriteRenderer.color = Color.clear;
        PlayerLeg1SpriteRenderer.color = Color.clear;
        PlayerLeg2SpriteRenderer.color = Color.clear;

        yield return new WaitForSeconds(0.2f);
        PlayerChestSpriteRenderer.color = Color.white;
        PlayerHeadSpriteRenderer.color = Color.white;
        PlayerLeg1SpriteRenderer.color = Color.white;
        PlayerLeg2SpriteRenderer.color = Color.white;

        isDamaged = false;

    }


    public void DamageHealth()
    {
        life -= 1;
        damageHit.Play();
    }

 
      


}
