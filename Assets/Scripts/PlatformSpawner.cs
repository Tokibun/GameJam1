using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSpawner : MonoBehaviour
{
    // Platform prefab
    public GameObject platformPrefab;
    public Transform sphereTransform;

    public float spawnHeight = 0.5f;
    public float spawnWidth = 3.0f;
    public int numPlatforms;

    public bool isSpawnTrigger = false;

    private Vector3 spawnArea;

    // Start is called before the first frame update
    void Start()
    {

        spawnArea = new Vector3(spawnWidth, spawnHeight, 1);
        SpawnPlatforms();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void SpawnPlatforms()
    {
        float previousZ = 5;
        for (int i = 0; i < numPlatforms; i++)
        {
            
            Vector2 spawnPositionXZ = Vector3.Scale(Random.insideUnitCircle, spawnArea);
            spawnPositionXZ.y += previousZ;

            Vector3 spawnPosition = new Vector3(spawnPositionXZ.x, 0.0f, spawnPositionXZ.y);
            previousZ += 3;

            RaycastHit hit;
            if (Physics.Raycast(transform.position + spawnPosition, Vector3.down, out hit))
            {
                if (!hit.collider.gameObject.CompareTag("Platform"))
                {
                    Instantiate(platformPrefab, hit.point, Quaternion.LookRotation(hit.normal), sphereTransform);
                }
            }
        }
    }
}