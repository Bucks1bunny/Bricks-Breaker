using UnityEngine;
using System;

public class ResetBall : MonoBehaviour
{
    public event Action BallPassed = delegate { };

    [SerializeField]
    private GameObject ball;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Ball")
        {
            Destroy(collision.gameObject);
            BallPassed();
            Instantiate(ball, Vector2.zero, Quaternion.identity);
        }
        else if (collision.gameObject.tag == "Powerup")
        {
            Destroy(collision.gameObject);
        }
    }
}
