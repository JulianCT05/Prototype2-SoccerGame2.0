using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public GameObject projectilePrefab;
    public Transform firePoint;
    public float projectileSpeed = 10f;

    public static bool canShoot = true;

    void Update()
    {
        // Move player up/down
        float verticalInput = Input.GetAxisRaw("Vertical");
        transform.Translate(Vector2.up * verticalInput * moveSpeed * Time.deltaTime);

        // Shoot if space is pressed and no projectile exists
        if (Input.GetKeyDown(KeyCode.Space) && canShoot)
        {
            Shoot();
        }
    }

    void Shoot()
    {
        canShoot = false;

        GameObject proj = Instantiate(projectilePrefab, firePoint.position, Quaternion.identity);
        Projectile projScript = proj.GetComponent<Projectile>();
        if (projScript != null)
        {
            projScript.speed = projectileSpeed;
            projScript.SetDirection(Vector2.right); // Shoots right
        }
    }
}
