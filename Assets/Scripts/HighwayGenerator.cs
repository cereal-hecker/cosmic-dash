using UnityEngine;
using System.Collections.Generic;

public class HighwayGenerator : MonoBehaviour
{
    public List<GameObject> highwayPieces;  // List of the individual prefabs for each highway piece
    public Transform player;               // Reference to the player character
    public float tileLength = 50f;         // Total length of a single highway tile (ensure it matches the combined prefab length)
    public int tilesOnScreen = 5;          // Number of tiles to keep on screen at a time

    private float spawnZ = 0;              // Z position to spawn the next tile
    private List<GameObject> activeTiles = new List<GameObject>(); // Keep track of active tiles

    void Start()
    {
        // Start by spawning one initial tile to initialize the endless process
        SpawnTile(); 
    }

    void Update()
    {
        // Check if the player is far enough to need a new tile
        if (player.position.z > spawnZ - (tilesOnScreen * tileLength))
        {
            SpawnTile();
            DeleteTile(); // Remove the oldest tile
        }
    }

    void SpawnTile()
    {
        // Create a parent object to hold the highway pieces
        GameObject parentTile = new GameObject("HighwayTile");
        parentTile.transform.position = new Vector3(0, 0, spawnZ);

        // Loop through each prefab in the highwayPieces list and instantiate it
        foreach (GameObject piece in highwayPieces)
        {
            GameObject instance = Instantiate(piece, parentTile.transform);
            instance.transform.localPosition = Vector3.zero; // Align pieces correctly (adjust if needed)
        }

        // Add the new tile to the active tiles list
        activeTiles.Add(parentTile);
        spawnZ += tileLength; // Move the spawn position forward
    }

    void DeleteTile()
    {
        // Only delete if there are more tiles than the allowed number
        if (activeTiles.Count > tilesOnScreen)
        {
            // Destroy the oldest tile
            Destroy(activeTiles[0]);
            activeTiles.RemoveAt(0);
        }
    }
}
