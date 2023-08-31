using UnityEngine;

public class Bullet : MonoBehaviour
{
    bool isFire = false;
    public GameObject obj;
    public float atkTimer = 3f;
    Vector3 startPos;
    public Animator anim;

    Vector2 dis;
    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (GamePanel.instance.isPause) return;
        RayPlayer();
        atkTimer -= Time.deltaTime;
        if (isFire)
        {
          
            transform.Translate(dis * Time.deltaTime *3);
            if(atkTimer<=-10)
            {
                transform.position = startPos;
            }
        }
    }
    void RayPlayer()
    {
        if (atkTimer>0) return;
        Collider2D coll = Physics2D.OverlapCircle(transform.position, 5f, 1 << LayerMask.NameToLayer("Player"));

        if(coll!=null)
        {
            anim.SetTrigger("Fire");
            atkTimer = 2;
            isFire = true;
            dis = (coll.transform.position - transform.position).normalized;
        }

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player")&&isFire)
        {
            isFire = false;
            transform.position = startPos;
            AudioManager.Instance.PlaySoundMusic("pain");
            HeroManager.instance.UpdateHealth(10, false);

        }
        if(collision.CompareTag("Ground"))
        {
            isFire = false;
            transform.position = startPos;
           
        }
    }
}
