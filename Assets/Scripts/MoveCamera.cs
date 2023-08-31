using UnityEngine;

public class MoveCamera : MonoBehaviour
{
    public GameObject heroCopy;
    public static GamePanel instance;
    public GameObject sensor1ToDeactivate, sensor2ToDeactivate;
    private float timer = 0f;
    private float interval = 1f;
    // Start is called before the first frame update
    void Start()
    {
        sensor1ToDeactivate.SetActive(false);
        sensor2ToDeactivate.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (heroCopy.transform.position.x > transform.position.x)
        {
            if (timer >= interval)
            { 
                timer = 0;
                GamePanel.instance.AddScore();
            }
            
            transform.position = new Vector3(heroCopy.transform.position.x, transform.position.y, transform.position.z);
        }
    }
}
