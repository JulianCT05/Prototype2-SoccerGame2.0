using UnityEngine;
using System.Collections.Generic;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public GameObject projectilePrefab;
    public Transform firePoint;
    public float projectileSpeed = 10f;
    public float shootCooldown = 0.5f; // time between shots
    public int maxProjectiles = 3;
    public AudioClip shootSound;

    private AudioSource audioSource;
    private float lastShotTime = -Mathf.Infinity;
    private List<GameObject> activeProjectiles = new List<GameObject>();

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        // Move player up/down
        float verticalInput = Input.GetAxisRaw("Vertical");
        transform.Translate(Vector2.up * verticalInput * moveSpeed * Time.deltaTime);

        // Check shoot input
        if (Input.GetKeyDown(KeyCode.Space) && CanShoot())
        {
            Shoot();
        }

        // Clean up destroyed projectiles
        activeProjectiles.RemoveAll(p => p == null);
    }

    bool CanShoot()
    {
        return Time.time - lastShotTime >= shootCooldown && activeProjectiles.Count < maxProjectiles;
    }

    void Shoot()
    {
        lastShotTime = Time.time;

        GameObject proj = Instantiate(projectilePrefab, firePoint.position, Quaternion.identity);
        Projectile projScript = proj.GetComponent<Projectile>();
        if (projScript != null)
        {
            projScript.speed = projectileSpeed;
            projScript.SetDirection(Vector2.right); // shoot right
        }

        activeProjectiles.Add(proj);

        if (shootSound != null)
            audioSource.PlayOneShot(shootSound);
    }
}
