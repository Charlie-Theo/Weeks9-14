using Unity.Cinemachine;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Tilemaps;

public class TileMapStuff : MonoBehaviour
{
    public Tilemap tilemap;
    public Transform highlight;

    public Tile flower;
    public CinemachineImpulseSource impulseSource;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());
        Vector3Int cellPos = tilemap.WorldToCell(mousePos);
        Vector3 pos = tilemap.GetCellCenterWorld(cellPos);

        //Debug.Log(mousePos + " is at cell: " + cellPos);
        highlight.position = pos;

        if (Mouse.current.leftButton.wasPressedThisFrame)
        {
            Debug.Log(tilemap.GetTile(cellPos));
            tilemap.SetTile(cellPos, flower);
            impulseSource.GenerateImpulse();
        }
    }
}
