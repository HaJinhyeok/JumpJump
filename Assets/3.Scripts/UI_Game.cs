using UnityEngine;
using UnityEngine.UI;

public class UI_Game : MonoBehaviour
{
    public Text ScoreText;

    void Start()
    {
        ScoreText.text = $"Score : {GameManager.Instance.Score}";
    }

    void Update()
    {
        ScoreText.text = $"Score : {GameManager.Instance.Score}";
    }
}
