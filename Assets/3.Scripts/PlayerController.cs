using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public Image JumpGauge;

    bool _isJumping = false;
    float _playerSize = 0.5f;
    float _speed = 5f;
    float _jumpGauge = 0f;

    Animator _animator;
    Rigidbody2D _rigidbody;
    BoxCollider2D _boxCollider;

    void Start()
    {
        _animator = GetComponent<Animator>();
        _rigidbody = GetComponent<Rigidbody2D>();
        _boxCollider = GetComponent<BoxCollider2D>();

        transform.localScale = new Vector3(1, 1, 1) * _playerSize;
    }

    void Update()
    {
        Move();
        Jump();
        CheckJumping();

        JumpGauge.fillAmount = _jumpGauge;

        if (transform.position.y < -11)
        {
            // Game Over
            UnityEngine.SceneManagement.SceneManager.LoadScene("GameOver");
            transform.parent = null;
        }
    }

    void Move()
    {
        if (Input.GetButton("Horizontal"))
        {
            float h = Input.GetAxisRaw("Horizontal");
            if (h > 0.1f || h < -0.1f)
                _animator.SetBool("isRun", true);
            transform.Translate(Vector3.right * h * _speed * Time.deltaTime);

            Vector3 currentPos = transform.position;
            currentPos.x = Mathf.Clamp(transform.position.x, -9, 9);
            transform.position = currentPos;

            if (h > 0)
                transform.localScale = new Vector3(1, 1, 1) * _playerSize;
            else if (h < 0)
                transform.localScale = new Vector3(-1, 1, 1) * _playerSize;
        }
        else
        {
            _animator.SetBool("isRun", false);
        }
    }

    void Jump()
    {
        if (Input.GetKey(KeyCode.Space) && _isJumping == false)
        {
            _jumpGauge += Time.deltaTime * 2;
            _jumpGauge = Mathf.Clamp(_jumpGauge, 0, 1);
        }
        if(Input.GetKeyUp(KeyCode.Space))
        {
            _isJumping = true;
            _rigidbody.AddForce(Vector3.up * 500 * _jumpGauge);
            _animator.SetBool("isJump", true);
            _jumpGauge = 0f;
        }
    }

    void CheckJumping()
    {
        if (_rigidbody.linearVelocityY <= 0.5f || _isJumping == false)
            _boxCollider.enabled = true;
        else
            _boxCollider.enabled = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Floor"))
        {
            _isJumping = false;
            _animator.SetBool("isJump", false);
            transform.parent = collision.transform;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Floor"))
        {
            transform.parent = null;
        }
    }

    // https://quickclid.tistory.com/1   참조!!! parent 바꿔 설정해줄때는 transform의 size가 서로 다르면 이상하게 출력되기도함
}
