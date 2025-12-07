using System;
using UnityEngine;

public class ObstacleMovement : MonoBehaviour
{
    private float speed;

    // Start is called before the first frame update
    void Start()
    {
        speed = FindAnyObjectByType<EventManager>().obstacleSpeed;
    }
    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.back * speed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.gameObject.GetComponent<PlayerCollisionHandling>().WhenHit();
            Destroy(gameObject);
        }
        else 
            Destroy(gameObject);
        
    }
}
