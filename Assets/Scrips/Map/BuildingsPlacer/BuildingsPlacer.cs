using System;
using UnityEngine;
using UnityEngine.Tilemaps;

public class BuildingsPlacer : MonoBehaviour
{
    private Preview preview;
    Camera mainCamera;
    [SerializeField] Tilemap tilemap;
    [SerializeField] private TileMapHolder tilemapHolder;

    private void Awake()
    {
        mainCamera = Camera.main;
    }

    void Start()
    {
        
    }

    public void spawnPreview(GameObject preview, GameObject buildType, Vector3 coords)
    {
        if (this.preview != null) { Destroy(this.preview.gameObject); }

        preview.GetComponent<Preview>().BuildPrefab = buildType;
        this.preview = Instantiate(preview, coords, Quaternion.identity).GetComponent<Preview>();
    }

    public void build()
    {
        Tower building =  preview.GetComponent<Preview>().BuildHere(() => true)?.GetComponent<Tower>();
        if (building == null) return;
        GameManager.Instance.InvokeGameEvent(GameEvents.PlayerBuiltStructure, building);
        Preview.Instance.CheckIsBuyAvailable();
    }

    public void movePreview() {
        Vector3 mouseCoords = mainCamera.ScreenToWorldPoint(Input.mousePosition);
        mouseCoords.z = 0;
        Vector3Int cellPos = tilemap.WorldToCell(mouseCoords);

        Func<bool> isBuildAvailable = () => {
            if (tilemapHolder.getCell(cellPos.x, cellPos.y).type == "Road_middle") return true;
            return false;
        };

        if (isBuildAvailable()) mouseCoords = tilemap.GetCellCenterWorld(cellPos);

        preview.moveToCursorPosition(mouseCoords, isBuildAvailable);
    }

    void Update()
    {
        if (preview == null) { return; }
        movePreview();



        if (Input.GetMouseButtonDown(1)) {
            Destroy(preview.gameObject);
            preview = null;
            return;
        }

        else if (Input.GetMouseButtonDown(0))
        {
            build();
        }
    }
}
