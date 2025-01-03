using System;
using UnityEngine;

public class PlateBehavior : MonoBehaviour
{

    public float speed = 1f;
    
    public float LeftBorder = -3f;
    
    public float RightBorder = 3f;
    Vector3 targetPosition = new Vector3(-3f,0.5f,6);
    
    void Update()
    {
        // Debug.Log(transform.position.x+" "+ LeftBorder);

        if (Mathf.Approximately(transform.position.x, LeftBorder))
        {
           targetPosition = new Vector3(RightBorder, transform.position.y, transform.position.z);
            Debug.Log("Left border touched");
        }
        else if (Mathf.Approximately(transform.position.x, RightBorder))
        {
            targetPosition = new Vector3(LeftBorder, transform.position.y, transform.position.z);
            Debug.Log("Right border touched");
        }
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
    }
}
