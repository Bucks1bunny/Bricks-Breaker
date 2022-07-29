using UnityEngine;

public class Ball : MonoBehaviour
{
    public Rigidbody2D rb
    {
        get;
        private set;
    }

    [SerializeField]
    private float speed;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        Invoke("ShootRandomly", 2f);
    }

    private void ShootRandomly()
    {
        Vector2 force = Vector2.zero;
        force.x = Random.Range(-1f, 1f);
        force.y = -1f;

        rb.AddForce(force.normalized * speed);
    }

    protected void Shoot()
    {
        Vector2 force = Vector2.zero;
        force.y = -1f;

        rb.AddForce(force.normalized * speed);
    }
}
