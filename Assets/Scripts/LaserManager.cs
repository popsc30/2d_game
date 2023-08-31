using UnityEngine;

public class LaserManager : MonoBehaviour
{
    public HeroManager heroCopy;
    private int counter;
    public static bool isPause = false;
    private static float atkTime = 1f;
    // Start is called before the first frame update
    void Start()
    {
        counter = 1;
        heroCopy = HeroManager.instance;
    }

    // Update is called once per frame
    void Update()
    {
        atkTime += Time.deltaTime;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (atkTime >= 1 && !isPause)
        {
            atkTime = 0;
            heroCopy.UpdateHealth(1, false);
            AudioManager.Instance.PlaySoundMusic("laser");
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {

    }
}
