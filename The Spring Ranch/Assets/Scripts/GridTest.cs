using UnityEngine;
using System.Collections.Generic;

public class GridTest : MonoBehaviour
{
    public GameObject cube, blockPrefab, tilledSoilPrefab;
    public Grid grid;
    public GridTestInput gridInput;

    public enum TileState { Empty, Tilled, Planted }

    // Guarda o estado de cada célula do grid
    private Dictionary<Vector3Int, TileState> tileStates = new Dictionary<Vector3Int, TileState>();

    void Update()
    {
        Vector3 selectedPosition = gridInput.GetSelectedPosition();
        Vector3Int cellPosition = grid.WorldToCell(selectedPosition);

        // Move o indicador pro centro da célula selecionada
        cube.transform.position = grid.GetCellCenterWorld(cellPosition);

        if (gridInput.GetTillInput())
        {
            TryTill(cellPosition);
        }

        if (gridInput.GetPlacementInput())
        {
            TryPlant(cellPosition);
        }
    }

    TileState GetState(Vector3Int cellPosition)
    {
        if (tileStates.TryGetValue(cellPosition, out TileState state))
            return state;
        return TileState.Empty;
    }

    void TryTill(Vector3Int cellPosition)
    {
        if (GetState(cellPosition) != TileState.Empty)
        {
            Debug.Log("Essa célula já foi arada ou plantada.");
            return;
        }

        Vector3 worldPos = grid.GetCellCenterWorld(cellPosition);
        Instantiate(tilledSoilPrefab, worldPos, Quaternion.identity);
        tileStates[cellPosition] = TileState.Tilled;
    }

    void TryPlant(Vector3Int cellPosition)
    {
        if (GetState(cellPosition) != TileState.Tilled)
        {
            Debug.Log("Precisa arar a terra antes de plantar!");
            return;
        }

        Vector3 worldPos = grid.GetCellCenterWorld(cellPosition);
        Instantiate(blockPrefab, worldPos, Quaternion.identity);
        tileStates[cellPosition] = TileState.Planted;
    }
}