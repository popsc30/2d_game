using UnityEngine;

public class AddHealth : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            HeroManager.instance.UpdateHealth(5, true);
            AudioManager.Instance.PlaySoundMusic("fuelcan");
            Destroy(gameObject);
        }
    }
}
