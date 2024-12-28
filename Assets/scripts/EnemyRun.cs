using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float speed = 3f; // Movement speed toward X = 0

    void Update()
    {
        // Calculate the direction toward X = 0
        Vector3 targetPosition = new Vector3(transform.position.x, transform.position.y, -3);

        // Move the enemy toward the target position
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
    
        if (Mathf.Approximately(transform.position.z, -3))
    {
        Destroy(gameObject);
    }
    }
}

