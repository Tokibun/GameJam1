using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSpawner : MonoBehaviour
{
    // Platform prefab
    public GameObject platformPrefab;
    public Transform sphereTransform;

    public float spawnHeight = 10.0f;
    public float spawnWidth = 10.0f;
    public int numPlatforms = 5;

    public bool isSpawnTrigger = false;


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
            Vector3 spawnArea = new Vector3(spawnWidth, spawnHeight, 1);
            Vector2 spawnPositionXZ = Vector3.Scale(Random.insideUnitSphere, spawnArea);
            Vector3 spawnPosition = new Vector3(spawnPositionXZ.x, 0.0f, spawnPositionXZ.y);

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