using UnityEngine;

public class Background : MonoBehaviour
{
    public GameObject[] Backgrounds;
    public float Speed = 2f;

    private void FixedUpdate()
    {
        for (int i = 0; i < Backgrounds.Length; i++)
        {
            Backgrounds[i].transform.Translate(Vector3.down * Speed * Time.deltaTime);
            if (Backgrounds[i].transform.position.y <= -25)
            {
                Backgrounds[i].transform.position = new Vector3(0, 38.5f, 0);
            }
        }
    }
}
