using UnityEngine;

public class StartPanel : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void StartClick()
    {
        LoadSceneManager.Instance.LoadScene("Game");
    }
}
