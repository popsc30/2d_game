using UnityEngine;
using UnityEngine.UI;

public class GamePanel : MonoBehaviour
{

    public static GamePanel instance;
    public Text scoreText;
    private int scoreValue = 0;
    public Text healtText;
    public bool isPause = false;
    public GameObject pausePanel;
    public Sprite[] spr;
    public Image i1;
    public GameObject overPanel;
    private void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        scoreText.text = "Score: 0";
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void PauseGame()
    {
        isPause = !isPause;
        if (isPause)
        {
            pausePanel.SetActive(true);
            i1.sprite = spr[1];
        }
        else
        {
            pausePanel.SetActive(false);
            i1.sprite = spr[0];
        }
    }
    public void AddScore()
    {
        scoreValue += 10;
        scoreText.text = "Score: " + scoreValue;
    }
    public void ReduceHealt(int value)
    {
        if (value <= 0)
        {
            GameOver();
        }
        healtText.text = "Health: " + value;
    }

    public void GameOver()
    {
        overPanel.SetActive(true);
        isPause = true;
    }
    public void QuitGame1()
    {
        Application.Quit();
    }
    public void Restar()
    {
        isPause = false;
        LoadSceneManager.Instance.LoadScene("Game");
    }
}
