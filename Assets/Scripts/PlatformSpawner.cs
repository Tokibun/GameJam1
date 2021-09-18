using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSpawner : MonoBehaviour
{
    // Platform prefab
    public GameObject platformPrefab;

    public float spawnRadius = 10.0f;
    public int numPlatforms = 10;


    // Start is called before the first frame update
    void Start()
    {
        SpawnPlatforms();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void SpawnPlatforms()
    {
        for (int i = 0; i < numPlatforms; i++)
        {
            Vector2 spawnPositionXZ = Random.insideUnitCircle * spawnRadius;
            Vector3 spawnPosition = new Vector3(spawnPositionXZ.x, 0.0f, spawnPositionXZ.y);

            RaycastHit hit;
            if (Physics.Raycast(transform.position + spawnPosition, Vector3.down, out hit))
            {
                if (!hit.collider.gameObject.CompareTag("Platform"))
                {
                    Instantiate(platformPrefab, hit.point, Quaternion.LookRotation(hit.normal));
                }
            }
        }
    }
}