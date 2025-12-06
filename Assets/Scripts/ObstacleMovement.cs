using System;
using UnityEngine;

public class ObstacleMovement : MonoBehaviour
{
    public float speed;

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
            Debug.Log("Player Hit");
            Destroy(gameObject);
        }
        else if (other.gameObject.CompareTag("Limit"))
        {
            Debug.Log("Limit Hit");
            Destroy(gameObject);
        }
    }
}
