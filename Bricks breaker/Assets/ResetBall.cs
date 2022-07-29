using UnityEngine;

public class ResetBall : MonoBehaviour
{
    [SerializeField]
    private GameObject ball;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Ball")
        {
            Destroy(collision.gameObject);
            Instantiate(ball, Vector2.zero, Quaternion.identity);
        }
    }
}
