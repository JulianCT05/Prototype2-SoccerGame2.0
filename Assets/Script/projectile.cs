using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed = 10f;
    private Vector2 direction;

    public AudioClip hitSound;
    private bool hasHit = false;

    public void SetDirection(Vector2 dir)
    {
        direction = dir.normalized;
    }

    void Update()
    {
        if (!hasHit)
            transform.Translate(direction * speed * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (hasHit) return;

        Debug.Log("Hit something: " + other.name); // For debugging
        hasHit = true;

        if (other.CompareTag("Goal"))
        {
            Debug.Log("Goal hit!");

            if (hitSound != null)
                AudioSource.PlayClipAtPoint(hitSound, transform.position);

            ScoreManager.Instance.AddPoint();
        }

        Destroy(gameObject);
    }
}

