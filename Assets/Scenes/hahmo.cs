using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class hahmo : MonoBehaviour
{
    public Image HPbar;
    float timer;
    float maxHealth;
    float currentHealth;
    public float moveSpeed = 4f; 
    public float jumpPower;
    bool grounded;
    Rigidbody2D rb;
    public float rayDist;
    public TextMeshProUGUI timerText;
    void OnTriggerEnter2D(Collider2D other)
    {

    }
    void timercalc()
    {
        timer += Time.deltaTime;
        timerText.text = "Timer:" + timer.ToString("0.0");
    }
    //void OnCollisionEnter2D(Collision2D collision) {
        //if(collision.gameObject.tag == "Ground")
       // { grounded = true;}}

    //Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        currentHealth=maxHealth;
    }

    //Update is called once per frame
    void Update()
    {
        //Instantiate(GameObject.damage,,);
        timercalc();
        HPbar.GetComponent<Image>().fillAmount=1.00f / maxHealth * currentHealth;
        LayerMask lm = LayerMask.GetMask("ground");
        RaycastHit2D hit = Physics2D.Raycast(transform.position,Vector2.down ,rayDist, lm);
        
        if(hit)
        {
        Debug.Log(hit.collider.gameObject.name);
        Debug.DrawRay(transform.position, Vector2.down* rayDist, Color.red);
        grounded = true;
        }
        else
        {
            grounded = false;
        }
        

        if(Input.GetKey(KeyCode.A))
        {
            transform.Translate(Vector2.left*Time.deltaTime*moveSpeed);
            GetComponent<SpriteRenderer>().flipX=true;
        } 
        if(Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector2.right*Time.deltaTime*moveSpeed);
            GetComponent<SpriteRenderer>().flipX=false;
        }
        if(Input.GetKeyDown(KeyCode.Space))
        {
            if(grounded)
            {
                rb.AddForce(Vector2.up*jumpPower, ForceMode2D.Impulse);
                grounded = false;
            }
        }
        if(Input.GetKeyDown(KeyCode.S))
        {
            rb.AddForce(Vector2.down * jumpPower);
        }
    }
}
