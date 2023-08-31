using UnityEngine;

public class TK : MonoBehaviour
{
    bool isOne = false;

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
        if(!isOne&&collision.CompareTag("Player"))
        {
            isOne = true;
            GameObject obj = GameObject.Instantiate(Resources.Load<GameObject>("Map"));
            obj.transform.position=transform.position+new Vector3(76.80217f, 0,0);
        }
        
    }
}
