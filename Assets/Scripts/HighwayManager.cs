using UnityEngine;
using System.Collections.Generic;

public class HighwayManager : MonoBehaviour
{
    public GameObject[] highwayTilePrefab;
    private Transform playerTransform;  
    private float spawnZ = 0f;
    private float tileLength = 50f;
    private int numberOfTiles = 10;
    private float safeZone = 60f;
    private List<GameObject> activeTiles = new List<GameObject>();

    void Start()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player")?.transform;

        if (playerTransform == null)
        {
            Debug.LogError("No GameObject with tag 'Player' found!");
            return;
        }

        for (int i = 0; i < numberOfTiles; i++)
        {
            if (i == 0)
                SpawnTile(0);
            else
                SpawnTile();
        }
    }

    void Update()
    {
        if (playerTransform.position.z - safeZone > (spawnZ - numberOfTiles * tileLength))
        {
            SpawnTile();
            DeleteTile();
        }
    }

    void SpawnTile(int prefabIndex = -1)
    {
        if (prefabIndex == -1)
            prefabIndex = Random.Range(0, highwayTilePrefab.Length);

        GameObject go = Instantiate(highwayTilePrefab[prefabIndex]) as GameObject;
        go.transform.SetParent(transform);
        go.transform.position = new Vector3(0, 0, spawnZ);
        spawnZ += tileLength;

        activeTiles.Add(go);
    }

    void DeleteTile()
    {
        if (activeTiles.Count > 0 && playerTransform.position.z - safeZone > activeTiles[0].transform.position.z + tileLength)
        {
            Destroy(activeTiles[0]);
            activeTiles.RemoveAt(0);
        }
    }
}
