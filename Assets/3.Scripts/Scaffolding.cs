using UnityEngine;
using System.Collections;

public class Scaffolding : MonoBehaviour
{
    bool _isStepped = false;

    public float Speed = 1f;

    void Start()
    {
        Destroy(gameObject, 20f);
    }

    void Update()
    {
        transform.Translate(Vector3.down * Speed * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // 같은 발판을 여러 번 밟았을 때 점수 여러 번 오르지 않도록
        if (collision.gameObject.CompareTag("Player") && !_isStepped)
        {
            _isStepped = true;
            // 점수 추가
            GameManager.Instance.Score += 1;
        }
    }
}
