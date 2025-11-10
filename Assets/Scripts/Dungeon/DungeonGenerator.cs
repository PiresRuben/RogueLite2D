using System.Collections.Generic;
using UnityEngine;

public class DungeonGenerator : MonoBehaviour
{
    [Header("Prefabs")]
    public GameObject roomPrefab;
    public GameObject playerPrefab;
    public GameObject enemyPrefab;

    [Header("Options")]
    public int roomCount = 10;
    public int enemiesPerRoomMin = 0;
    public int enemiesPerRoomMax = 3;

    private HashSet<Vector2Int> positions = new();

    void Start()
    {
        if (roomPrefab == null)
        {
            Debug.LogError("DungeonGenerator : roomPrefab manquant !");
            return;
        }

        GenerateDungeon();
    }

    void GenerateDungeon()
    {
        positions.Clear();

        Vector2Int pos = Vector2Int.zero;
        positions.Add(pos);

        for (int i = 0; i < roomCount; i++)
        {
            pos += RandomDirection();
            positions.Add(pos);
        }

/*        bool playerSpawned = false;*/

        foreach (var p in positions)
        {
            Vector3 worldPos = new Vector3(p.x * 16, p.y * 9, 0);
            GameObject room = Instantiate(roomPrefab, worldPos, Quaternion.identity);

            // Spawn du joueur dans la première salle
/*            if (!playerSpawned && playerPrefab != null)
            {
                Instantiate(playerPrefab, worldPos, Quaternion.identity);
                playerSpawned = true;
            }*/

            // Spawn d'ennemis aléatoires
            if (enemyPrefab != null)
            {
                int enemyCount = Random.Range(enemiesPerRoomMin, enemiesPerRoomMax + 1);
                for (int i = 0; i < enemyCount; i++)
                {
                    Vector2 offset = Random.insideUnitCircle * 3f;
                    Vector3 enemyPos = worldPos + (Vector3)offset;
                    Instantiate(enemyPrefab, enemyPos, Quaternion.identity);
                }
            }
        }
    }

    Vector2Int RandomDirection()
    {
        int r = Random.Range(0, 4);
        return r switch
        {
            0 => Vector2Int.up,
            1 => Vector2Int.down,
            2 => Vector2Int.left,
            _ => Vector2Int.right,
        };
    }
}