using UnityEngine;

public class HeroManager : MonoBehaviour
{
    private float deltaX;
    private int health;
    private Animator anim;
    private Rigidbody2D rb;
    private bool onGround;
    private bool motionState;
    public static HeroManager instance;
    bool isOpen = false;
    bool isA = false;

    private void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        //AudioManager.Instance.PlayBKMusic();
        AudioManager.Instance.PlaySoundMusic("bgm", true);
        deltaX = 0.15f;
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        onGround = true;
        health = 100;
        motionState = false;
        anim.SetInteger("Transition", 1);
        GamePanel.instance.ReduceHealt(health);
    }
    public void UpdateHealth(int updateParam, bool live)
    {
        if (GamePanel.instance.isPause) return;
    
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
                GamePanel.instance.GameOver();
                Debug.Log("Game Over!!");
            }
            
        }
        GamePanel.instance.ReduceHealt(health);

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
        if (GamePanel.instance.isPause) return;
        if(isOpen)
        {
            if(isA)
            {
                anim.SetInteger("Transition", 2);
                transform.localScale = new Vector3(1f, 1f, 1f);
                transform.position = new Vector3(transform.position.x + deltaX, transform.position.y, 0);
            }
            else
            {
                anim.SetInteger("Transition", 2);
                transform.localScale = new Vector3(-1f, 1f, 1f);
                transform.position = new Vector3(transform.position.x - deltaX, transform.position.y, 0);
            }
        }
        if (Input.GetKey("right"))
        {
            MoveRight();
        }
        if (Input.GetKey("left"))
        {
            MoveLeft();
        }
        if (Input.GetKeyUp("left") || Input.GetKeyUp("right"))
        {
            RetMoveIdle();
        }
       /* else
        {
            anim.SetInteger("Transition", 2);
        }*/
        if (Input.GetKeyDown("up"))
        {
            MoveUp();
        }
    }

    public void RetMoveIdle()
    {
        isOpen = false;
        motionState = false;
        anim.SetInteger("Transition", 1);
    }
    public void MoveRight()
    {
        isOpen = true;
        isA = true;
        motionState = true;
 
    }
    public void MoveLeft()
    {
        isOpen = true;
        isA = false;
        motionState = true;
       
    }
    public void MoveUp()
    {
        if (onGround)
        {
            AudioManager.Instance.PlaySoundMusic("Jump");
            /*anim.SetTrigger("jump");*/
            anim.SetInteger("Transition", 3);
            rb.AddForce(new Vector2(0f, 9f), ForceMode2D.Impulse);
            onGround = false;
        }
    }
}
