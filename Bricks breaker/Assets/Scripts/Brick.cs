using System;
using UnityEngine;

public class Brick : MonoBehaviour
{
    public event Action<int> ScoreAdded = delegate { };

    [SerializeField]
    private BricksScriptableObject data;
    [SerializeField]
    private GameObject[] powerups;
    private int currentHealth;

    private void Awake()
    {
        currentHealth = data.health;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision != null && data.isBreakable)
        {
            currentHealth--;
            if (currentHealth == 0)
            {
                Death();
            }
        }
    }

    private void Death()
    {
        Destroy(gameObject);
        ScoreAdded();
        if (data.hasPowerup)
        {
            DropPowerup();
        }
    }

    private void DropPowerup()
    {
        var powerup = powerups[Random.Range(0, powerups.Length)];
        Instantiate(powerup, transform.position, Quaternion.identity);
    }
}
