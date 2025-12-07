using UnityEngine;
using System.Collections;

public class ObstacleSpawner : MonoBehaviour
{
    public GameObject[] obstacles;
    public Transform[] positions = new Transform[3];
    public bool isPlaying = true;
    public bool easyMode = true;
    
    void Start()
    {
        StartCoroutine(SpawnObstacle());
    }
    
    private IEnumerator SpawnObstacle()
    {
        while (isPlaying)
        {
            
            int obstacleIndex = Random.Range(0, obstacles.Length);
            Instantiate(obstacles[obstacleIndex], positions[Random.Range(0, positions.Length)].position, Quaternion.identity);
            if (easyMode)
                yield return new WaitForSeconds(Random.Range(0.2f, 1f));
            else
                yield return new WaitForSeconds(0.2F);
        }
    }
}
