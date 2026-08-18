using UnityEngine;

public class FarmGrid : MonoBehaviour
{
  public float cellSize = 1f;
  public float plantingDistancie = 3f;

  public Transform playerTransform;

    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if(Physics.Raycast(ray, out RaycastHit hit))
        {
            Vector3 mousePosition = hit.point;

            int gridX = Mathf.FloorToInt(mousePosition.x / cellSize);)
            int gridZ = Mathf.FloorToInt(mousePosition.z / cellSize);

            Vector3 cellPosition = new Vector3(grid)
        })
    }
}
