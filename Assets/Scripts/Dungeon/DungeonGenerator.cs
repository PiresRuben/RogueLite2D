using System.Collections.Generic;
using UnityEngine;

public class DungeonGenerator : MonoBehaviour
{
    public GameObject roomPrefab;
    public int roomCount = 10;
    private HashSet<Vector2Int> positions = new();

    void Start()
    {
        Vector2Int pos = Vector2Int.zero;
        positions.Add(pos);

        for (int i = 0; i < roomCount; i++)
        {
            pos += RandomDirection();
            positions.Add(pos);
        }

        foreach (var p in positions)
            Instantiate(roomPrefab, new Vector3(p.x * 16, p.y * 9, 0), Quaternion.identity);
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
