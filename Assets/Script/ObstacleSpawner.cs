using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    [SerializeField] GameObject[] Obstacles;
    [SerializeField] float secondSpawn = 2.5f;
    [SerializeField] float minTras;
    [SerializeField] float maxTras;
    private void Start()
    {
        StartCoroutine(ObstacleSpawn());
    }
    IEnumerator ObstacleSpawn()
    {
        while(true)
        {
            var wantedPos = Random.Range(minTras, maxTras);
            var spawnPos = new Vector3(transform.position.x, wantedPos);
            GameObject gameObject = Instantiate(Obstacles[Random.Range(0, Obstacles.Length)], spawnPos, Quaternion.identity);
            yield return new WaitForSeconds(secondSpawn);
            Destroy(gameObject, 5f);
        }
    }
}
