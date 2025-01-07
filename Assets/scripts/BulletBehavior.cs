using UnityEngine;

public class BulletBehavior : MonoBehaviour
{
    public float speed = 20f; // Speed of the bullet
    public float lifetime = 6f; // Time before the bullet is destroyed

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
     void OnCollisionEnter(Collision collision)
    {
        // Check if the collided object is tagged as "Enemy"
        if (collision.gameObject.CompareTag("enemy"))
        {
            // Destroy the enemy
            Destroy(collision.gameObject);

            // Destroy the bullet
            Destroy(gameObject);
        }
    }

}
