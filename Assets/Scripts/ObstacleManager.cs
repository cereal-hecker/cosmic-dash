using UnityEngine;
using System.Collections.Generic;

public class ObstacleSpawner : MonoBehaviour
{
    public GameObject[] obstaclePrefabs; // Array of different obstacle prefabs
    public Transform[] lanePositions; // Array of transforms representing lanes
    public float laneLength = 50f; // Length of each lane
    public float spawnZOffset = 10f; // Offset to spawn the obstacles a little ahead of the player
    public int maxObstaclesPerLane = 3; // Max obstacles per lane

    public void SpawnObstaclesForAllLanes(float tileZPosition)
    {
        if (obstaclePrefabs.Length == 0 || lanePositions.Length == 0)
        {
            Debug.LogError("Obstacle prefabs or lane positions are not set!");
            return;
        }

        // Spawn obstacles for all lanes (visible lanes) when the tile is created
        foreach (var lane in lanePositions)
        {
            // Randomly spawn a few obstacles along the lane
            int obstacleCount = Random.Range(1, maxObstaclesPerLane + 1);

            // Spawn obstacles at random positions along the lane
            for (int i = 0; i < obstacleCount; i++)
            {
                // Choose a random obstacle prefab
                GameObject randomObstacle = obstaclePrefabs[Random.Range(0, obstaclePrefabs.Length)];

                // Randomize the Z position along the lane (within the lane length)
                float randomZOffset = Random.Range(-laneLength / 2f, laneLength / 2f); // Spread obstacles along the 50-unit lane

                // Calculate the spawn position in world space
                Vector3 spawnPosition = new Vector3(lane.position.x, lane.position.y, tileZPosition + randomZOffset + spawnZOffset);

                // Spawn the obstacle at the calculated position
                Instantiate(randomObstacle, spawnPosition, Quaternion.identity);
            }
        }
    }
}
