using UnityEngine;

public class Paddle : MonoBehaviour
{
    [SerializeField]
    private float speed;
    [SerializeField]
    private float maxBounceAngle;

    private void Update()
    {
        var target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = Vector3.MoveTowards(transform.position,
            new Vector3(target.x, transform.position.y, transform.position.z), speed * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.tag == "Ball")
        {
            Ball ball = collision.gameObject.GetComponent<Ball>();
            Vector3 paddlePosition = transform.position;
            Vector2 contactPoint = collision.GetContact(0).point;

            float offset = paddlePosition.x - contactPoint.x;
            float width = collision.otherCollider.bounds.size.x / 2;

            float currentAngle = Vector2.SignedAngle(Vector2.up, ball.rb.velocity);
            float boucenAngle = (offset / width) * maxBounceAngle;
            float newAngle = Mathf.Clamp(currentAngle + boucenAngle, -maxBounceAngle, maxBounceAngle);

            Quaternion rotation = Quaternion.AngleAxis(newAngle, Vector3.forward);
            ball.rb.velocity = rotation * Vector2.up * ball.rb.velocity.magnitude * 1.1f;
        }
        else if (collision.gameObject.tag == "Powerup")
        {
            Powerup powerup = collision.gameObject.GetComponent<Powerup>();
            powerup.GetPowerup();
        }
    }
}
