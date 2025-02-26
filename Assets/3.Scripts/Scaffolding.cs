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
        // ���� ������ ���� �� ����� �� ���� ���� �� ������ �ʵ���
        if (collision.gameObject.CompareTag("Player") && !_isStepped)
        {
            _isStepped = true;
            // ���� �߰�
            GameManager.Instance.Score += 1;
        }
    }
}
