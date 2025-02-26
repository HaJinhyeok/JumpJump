using UnityEngine;
using UnityEngine.UI;

public class UI_Main : MonoBehaviour
{
    public Button StartButton;

    void Start()
    {
        // StartButton.onClick.AddListener(OnStartButtonClick);
        StartButton.onClick.AddListener(() => UnityEngine.SceneManagement.SceneManager.LoadScene("Game"));
    }

    void OnStartButtonClick()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Game");
    }

}
