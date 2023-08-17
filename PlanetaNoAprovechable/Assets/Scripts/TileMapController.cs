using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TileMapController : MonoBehaviour
{

    public TileBase closedDoor;
    public TileBase openDoor;
    public GameObject door;

    Tilemap map;

    LevelManagement LM;

    void Start()
    {
        LM = door.GetComponent<LevelManagement>();
        map = GetComponent<Tilemap>();
    }

    // Update is called once per frame
    void Update()
    {
        if (LM.enemyCount == 0){
            map.SetTile(new Vector3Int(0, 6, 0), openDoor);
            map.SetTile(new Vector3Int(-1, 6, 0), openDoor);

            map.SetTile(new Vector3Int(28, 6, 0), openDoor);
            map.SetTile(new Vector3Int(27, 6, 0), openDoor);

            map.SetTile(new Vector3Int(56, 6, 0), openDoor);
            map.SetTile(new Vector3Int(55, 6, 0), openDoor);

            map.SetTile(new Vector3Int(84, 6, 0), openDoor);
            map.SetTile(new Vector3Int(83, 6, 0), openDoor);

            map.SetTile(new Vector3Int(112, 6, 0), openDoor);
            map.SetTile(new Vector3Int(111, 6, 0), openDoor);

            map.SetTile(new Vector3Int(0, -12, 0), openDoor);
            map.SetTile(new Vector3Int(-1, -12, 0), openDoor);

            map.SetTile(new Vector3Int(28, -12, 0), openDoor);
            map.SetTile(new Vector3Int(27, -12, 0), openDoor);

            map.SetTile(new Vector3Int(56, -12, 0), openDoor);
            map.SetTile(new Vector3Int(55, -12, 0), openDoor);

            map.SetTile(new Vector3Int(84, -12, 0), openDoor);
            map.SetTile(new Vector3Int(83, -12, 0), openDoor);

            map.SetTile(new Vector3Int(112, -12, 0), openDoor);
            map.SetTile(new Vector3Int(111, -12, 0), openDoor);
        }
        else{
            map.SetTile(new Vector3Int(0, 6, 0), closedDoor);
            map.SetTile(new Vector3Int(-1, 6, 0), closedDoor);

            map.SetTile(new Vector3Int(28, 6, 0), closedDoor);
            map.SetTile(new Vector3Int(27, 6, 0), closedDoor);

            map.SetTile(new Vector3Int(56, 6, 0), closedDoor);
            map.SetTile(new Vector3Int(55, 6, 0), closedDoor);

            map.SetTile(new Vector3Int(84, 6, 0), closedDoor);
            map.SetTile(new Vector3Int(83, 6, 0), closedDoor);

            map.SetTile(new Vector3Int(112, 6, 0), closedDoor);
            map.SetTile(new Vector3Int(111, 6, 0), closedDoor);

            map.SetTile(new Vector3Int(0, -12, 0), closedDoor);
            map.SetTile(new Vector3Int(-1, -12, 0), closedDoor);

            map.SetTile(new Vector3Int(28, -12, 0), closedDoor);
            map.SetTile(new Vector3Int(27, -12, 0), closedDoor);

            map.SetTile(new Vector3Int(56, -12, 0), closedDoor);
            map.SetTile(new Vector3Int(55, -12, 0), closedDoor);

            map.SetTile(new Vector3Int(84, -12, 0), closedDoor);
            map.SetTile(new Vector3Int(83, -12, 0), closedDoor);

            map.SetTile(new Vector3Int(112, -12, 0), closedDoor);
            map.SetTile(new Vector3Int(111, -12, 0), closedDoor);
        }
    }
}
