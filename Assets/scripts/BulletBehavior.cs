using UnityEngine;

public class BulletBehavior : MonoBehaviour
{
    public float speed = 10f; // Speed of the bullet
    public float lifetime = 3f; // Time before the bullet is destroyed

    void Start()
    {
        // Destroy the bullet after a set lifetime
        Destroy(gameObject, lifetime);
    }

    void Update()
    {
        // Move the bullet forward
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    void OnTriggerEnter(Collider other)
    {
        // Optional: Handle collision with enemies or objects
        if (other.CompareTag("enemy"))
        {
            Destroy(other.gameObject); // Destroy enemy
            Destroy(gameObject); // Destroy the bullet
        }
    }
}
