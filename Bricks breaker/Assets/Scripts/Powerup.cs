using System.Collections.Generic;
using UnityEngine;

public class Powerup : Ball
{
    [SerializeField]
    private bool bigBall;
    [SerializeField]
    private bool multiplyBall;
    [SerializeField]
    private GameObject ball;

    public void GetPowerup()
    {
        if (bigBall)
        {
            foreach (var _ball in GameObject.FindGameObjectsWithTag("Ball"))
            {
                _ball.transform.localScale += new Vector3(0.2f, 0.2f, 0);
            }
        }
        if (multiplyBall)
        {
            foreach (var _ball in GameObject.FindGameObjectsWithTag("Ball"))
            {
                Instantiate(ball, _ball.transform.position, Quaternion.identity);
            }
        }
        Destroy(gameObject);
    }

    private void Start()
    {
        Shoot();
    }
}
