using UnityEngine;

public class Collectable : MonoBehaviour
{
    public string collectableName;
    public int quantidade = 64;

    private FarmGrid farmGrid;
    public Vector2Int coordenada;
    private InventoryController inventoryController;

    void Start()
    {
        farmGrid = FindFirstObjectByType<FarmGrid>();
        inventoryController = FindFirstObjectByType<InventoryController>();
    }
    public void Coletar()
    {
        farmGrid.LimparCell(coordenada);
        inventoryController.GiveMeWheat();
        Destroy(gameObject);  

    }
}
