using UnityEngine;

public class StartFloor : MonoBehaviour
{
    void Start()
    {
        Destroy(gameObject, 5.0f);
    }

    void Update()
    {
        transform.Translate(Vector3.down * Time.deltaTime);
    }
}
