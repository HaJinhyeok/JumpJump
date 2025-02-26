using UnityEngine;
using UnityEngine.UI;

public class UI_GameOver : MonoBehaviour
{
    public Button RetryButton;
    public Button QuitButton;
    public Text ScoreText;
    public Text BestScoreText;

    void Start()
    {
        RetryButton.onClick.AddListener(OnRetryButtonClick);
        QuitButton.onClick.AddListener(OnQuitButtonClick);
        BestScoreText.text = $"BestScore : {GameManager.Instance.BestScore}";
        ScoreText.text = $"Score : {GameManager.Instance.Score}";
    }
    
    void OnRetryButtonClick()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Game");
        GameManager.Instance.Score -= GameManager.Instance.Score;
    }

    void OnQuitButtonClick()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}
