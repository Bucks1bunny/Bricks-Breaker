using UnityEngine;

public class Brick : MonoBehaviour
{
    [SerializeField]
    private BricksScriptableObject data;
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
    }
}
