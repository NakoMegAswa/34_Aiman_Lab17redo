using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Character : MonoBehaviour
{
    public float jumpForce;
    private int healthCount;
    private int coinCount;
    public float moveSpeed = 5.0f;

    private Rigidbody2D rb;
    private Animator animator;

    public GameObject HealthText;
    public GameObject CoinText;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        HealthText.GetComponent<Text>().text = "Start Function";
        HealthText.GetComponent<Text>().text = "Health: " + healthCount.ToString();


        CoinText.GetComponent<Text>().text = "Start Function";
        CoinText.GetComponent<Text>().text = "Coin: " + coinCount.ToString();



    }

    // Update is called once per frame
    void Update()
    {
        float hVelocity = 0;
        float vVelocity = 0;

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            hVelocity = -moveSpeed;
            transform.localScale = new Vector3(-1, 1, 1);
       
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            hVelocity = moveSpeed;
            transform.localScale = new Vector3(1, 1, 1);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            vVelocity = jumpForce;
            animator.SetTrigger("JumpTrigger");
        }

        hVelocity = Mathf.Clamp(rb.velocity.x + hVelocity, -5, 5);

        rb.velocity = new Vector2(hVelocity, rb.velocity.y + vVelocity);
        
        /*
         animator.SetFloat("xVelocity", Mathf.Abs(hVelocity));
        
         animator.SetFloat("xVelocity", 0);

         */

        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            healthCount -= 10;
        }

        if (collision.gameObject.tag == "Coin")
        {
            Destroy(this.gameObject);
            coinCount++;
        }

    }
}
