using System.Drawing;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TileMapHolder : MonoBehaviour
{
    public Vector3Int Size;

    private GridCell[,] grid;
    private Tilemap tilemap;

    private void Awake()
    {
        tilemap = GetComponentInChildren<Tilemap>();

        grid = new GridCell[Size.x, Size.y];
        tilemap.size = new Vector3Int(Size.x, Size.y, 0);

        Vector3 CellPosition;
        Vector3Int coordinate = new Vector3Int(0, 0, 0);
        for (int y = 0; y < tilemap.size.y; y++)  {
            for (int x = 0; x < tilemap.size.x; x++)
            {
                coordinate.x = x; coordinate.y = -y;
                CellPosition = tilemap.CellToWorld(coordinate);
                
                string CellType = tilemap.GetTile<Tile>(tilemap.WorldToCell(CellPosition)).name;
                
                grid[x, y] = new GridCell(CellType, CellPosition.x, CellPosition.y, false);
            }
        }
    }

    public void setCellOccupiedStatus(Vector3Int cellPos, bool isOccupied) {
        grid[cellPos.x, -cellPos.y].IsOccupied = isOccupied;
    }

    public GridCell getCell (Vector2Int cellPos) {
        return grid[cellPos.x, -cellPos.y];
    }

    public GridCell getCell(int x, int y)
    {
        return grid[x, -y];
    }

    public bool isAreaBounded(int x, int y)
    {
        bool available = x >= 0 && x <= grid.GetLength(0) - Size.x;
        if (available) { return y >= 0 && y <= grid.GetLength(1) - Size.y; }
        return available;
    }
}
