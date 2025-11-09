using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 10f;        // Vitesse du projectile
    public float lifeTime = 2f;      // Durée de vie avant destruction

    void Start()
    {
        Destroy(gameObject, lifeTime);  // Auto-destruction après quelques secondes
    }

    void Update()
    {
        // Fait avancer la balle tout droit
        transform.Translate(Vector2.up * speed * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // Si on touche un ennemi
        if (other.CompareTag("Enemy"))
        {
            other.GetComponent<Enemy>()?.TakeDamage(1); // Inflige 1 dégât
            Destroy(gameObject); // Détruit la balle
        }
    }
}
