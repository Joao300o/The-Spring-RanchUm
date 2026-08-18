using UnityEngine;
using UnityEngine.InputSystem;  

public class FarmGrid : MonoBehaviour
{
  public float cellSize = 1f;
  public float plantingDistancie = 3f;

  public Transform playerTransform, gridSelector;

    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Mouse.current.position.ReadValue());

        if(Physics.Raycast(ray, out RaycastHit hit))
        {
            Vector3 mousePosition = hit.point;

            int gridX = Mathf.FloorToInt(mousePosition.x / cellSize);
            int gridZ = Mathf.FloorToInt(mousePosition.z / cellSize);

            Vector3 cellPosition = new Vector3(gridX * cellSize, 0, gridZ * cellSize);

            cellPosition += new Vector3(cellSize / 2, 0, cellSize / 2);
            gridSelector.position = cellPosition;

            float distancePlayer = Vector3.Distance(playerTransform.position, cellPosition);
        }
    }
}
