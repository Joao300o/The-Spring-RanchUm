using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections.Generic;

public class FarmGrid : MonoBehaviour
{
    public enum CellState
    {
        Empty,
        Plowed,
        Planted
    }

    public float cellSize = 1f;
    public float plantingDistancie = 3f;

    public Transform playerTransform, gridSelector;

    public Renderer gridRenderer;

    public GameObject plowedPrefab;

    List<Vector2Int> occupiedCells = new List<Vector2Int>();
    Dictionary<Vector2Int, CellState> cells = new Dictionary<Vector2Int, CellState>();
    void Start()
    {
        Material material = gridRenderer.material;

        material.SetFloat("_Surface", 1f);
        material.SetFloat("_Blend", 0f);
        material.SetFloat("_AlphaClip", 0f);

        material.SetOverrideTag("RenderType", "Transparent");
        material.SetInt("_SrcBlend", (int)UnityEngine.Rendering.BlendMode.SrcAlpha);
        material.SetInt("_DstBlend", (int)UnityEngine.Rendering.BlendMode.OneMinusSrcAlpha);
        material.SetInt("_ZWrite", 0);

        material.renderQueue = (int)UnityEngine.Rendering.RenderQueue.Transparent;

        material.color = new Color(0, 1, 0, 0.1f);
    }


    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Mouse.current.position.ReadValue());

        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            Vector3 mousePosition = hit.point;

            int gridX = Mathf.FloorToInt(mousePosition.x / cellSize);
            int gridZ = Mathf.FloorToInt(mousePosition.z / cellSize);

            Vector2Int currentCell = new Vector2Int(gridX, gridZ);

            Vector3 cellPosition = new Vector3(gridX * cellSize, 0, gridZ * cellSize);

            cellPosition += new Vector3(cellSize / 2, 0, cellSize / 2);
            gridSelector.position = cellPosition;

            float distancePlayer = Vector3.Distance(playerTransform.position, cellPosition);

            if (distancePlayer <= plantingDistancie)
            {

                gridRenderer.material.color = new Color(0, 1, 0, 0.1f);
                if (Mouse.current.leftButton.wasPressedThisFrame)
                {
                    if (!cells.ContainsKey(currentCell))
                    {
                        Vector3 plowedPosition = cellPosition;
                        plowedPosition.y = -0.498f;

                        cells[currentCell] = CellState.Plowed;
                        Instantiate(plowedPrefab, plowedPosition, Quaternion.identity);
                        Debug.Log("Plowed");
                    }
                }

            }
            else
            {
                gridRenderer.material.color = new Color(1, 0, 0, 0.1f);
            }

            if (cells.ContainsKey(currentCell))
            {
                Debug.Log("Estado" + cells[currentCell]);
            }
        }
    }
}
