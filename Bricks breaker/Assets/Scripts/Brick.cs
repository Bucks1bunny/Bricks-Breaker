using System;
using UnityEngine;

public class Brick : MonoBehaviour
{
    public event Action<Brick> BrickDestroyed = delegate { };

    [field: SerializeField]
    public BricksScriptableObject Data
    {
        get;
        private set;
    }

    [SerializeField]
    private GameObject[] powerups;
    private int currentHealth;

    private void Awake()
    {
        currentHealth = Data.health;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision != null && Data.isBreakable)
        {
            currentHealth--;
            if (currentHealth == 0)
            {
                Destroyed();
            }
        }
    }

    private void Destroyed()
    {
        BrickDestroyed(this);
        Destroy(gameObject);
        if (Data.hasPowerup)
        {
            DropPowerup();
        }
    }

    private void DropPowerup()
    {
        var powerup = powerups[UnityEngine.Random.Range(0, powerups.Length)];
        Instantiate(powerup, transform.position, Quaternion.identity);
    }
}
