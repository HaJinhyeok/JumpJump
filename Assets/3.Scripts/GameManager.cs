using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private static GameManager s_instance = null;
    public static GameManager Instance
    {
        get
        {
            if (s_instance == null)
            {
                return null;
            }
            return s_instance;
        }
    }

    private void Awake()
    {
        if (s_instance == null)
        {
            s_instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
            Destroy(gameObject);
    }

    private int _score = 0;

    public int BestScore { get => PlayerPrefs.GetInt("Score"); }

    public int Score
    {
        get { return _score; }
        set
        {
            _score = value;
            if (_score > PlayerPrefs.GetInt("Score"))
            {
                PlayerPrefs.SetInt("Score", _score);
            }
        }
    }

    private void OnEnable()
    {
        _score = 0;
    }
}
