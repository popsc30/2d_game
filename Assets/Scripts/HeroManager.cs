using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroManager : MonoBehaviour
{
    private float deltaX;
    private int health;
    private Animator anim;
    private Rigidbody2D rb;
    private bool onGround;
    private bool motionState;
    // Start is called before the first frame update
    void Start()
    {
        deltaX = 0.02f;
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        onGround = true;
        health = 100;
        motionState = false;
        anim.SetInteger("Transition", 1);
    }
    public void UpdateHealth(int updateParam, bool live)
    {
        if (live)
        {
            health += updateParam;
            if (health > 100)
            {
                health = 100;
            }
        }
        else
        {
            health -= updateParam;
            if (health > 0)
            {
                Debug.Log("Health is:" + health);
            }
            else
            {
                health = 0;
                Debug.Log("Game Over!!");
            }
            
        }
       
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {   
        
        onGround = true;
        if (motionState)
        {
            anim.SetInteger("Transition", 3);
        }
        else
        {
            anim.SetInteger("Transition", 1);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("right"))
        {
            motionState = true;
            anim.SetInteger("Transition", 2);
            transform.localScale = new Vector3(1f, 1f, 1f);
            transform.position = new Vector3(transform.position.x + deltaX, transform.position.y, 0);
        }
        if (Input.GetKey("left"))
        {
            motionState = true;
            anim.SetInteger("Transition", 2);
            transform.localScale = new Vector3(-1f, 1f, 1f);
            transform.position = new Vector3(transform.position.x - deltaX, transform.position.y, 0);
        }
        if (Input.GetKeyUp("left") || Input.GetKeyUp("right"))
        {
            motionState = false;
        }
       /* else
        {
            anim.SetInteger("Transition", 2);
        }*/
        if (Input.GetKeyDown("up"))
        {
            if (onGround)
            {
                /*anim.SetTrigger("jump");*/
                anim.SetInteger("Transition", 3);
                rb.AddForce(new Vector2(0f, 7f), ForceMode2D.Impulse);
                onGround = false;
            }
        }
    }
}
