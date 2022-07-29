using UnityEngine;
using System;

public class ResetBall : MonoBehaviour
{
    public event Action<bool, Ball> BallAdded = delegate { };
    public event Action BallPassed = delegate { };

    [SerializeField]
    private GameObject ball;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Ball")
        {
            //BallAdded(false, collision.gameObject);
            Destroy(collision.gameObject);
            BallPassed();
            Instantiate(ball, Vector2.zero, Quaternion.identity);
            //BallAdded(true, ball);
        }
        else if (collision.gameObject.tag == "Powerup")
        {
            Destroy(collision.gameObject);
        }
    }
}
