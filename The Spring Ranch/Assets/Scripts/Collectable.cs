
using UnityEngine;

public class Collectable : MonoBehaviour
{
    public string collectableName;
    public int quantidade = 64;

    private FarmGrid farmGrid;
    public Vector2Int coordenada;
    private InventoryController inventoryController;
          private bool ray;


    public float laserDistance = 100f;

    void Start()
    {
        farmGrid = FindFirstObjectByType<FarmGrid>();
        inventoryController = FindFirstObjectByType<InventoryController>();
    }

    void AtualizarCoordenada()
    {
        int x = Mathf.FloorToInt(transform.position.x / farmGrid.cellSize);
        int z = Mathf.FloorToInt(transform.position.z / farmGrid.cellSize);

        coordenada = new Vector2Int(x, z);
    }

    public void Coletar()
    {
        AtualizarCoordenada();

        Vector3 startPosition = transform.position;
        Vector3 laserDirection = Vector3.down;

        ray = Physics.Raycast(startPosition, laserDirection, out RaycastHit hitInfo, laserDistance);

        foreach (RaycastHit hit in Physics.RaycastAll(startPosition, laserDirection, laserDistance))
        {
            Debug.Log("Objeto encontrado: " + hit.collider.name);

            if (hit.collider.CompareTag("Plowed"))
            {
                Destroy(hit.collider.gameObject);
                Debug.Log("Terra arada destruída!");
            }
        }

        farmGrid.LimparCell(coordenada);

        inventoryController.GiveMeWheat();

        Destroy(gameObject);
    }
}
