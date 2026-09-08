using System.Data.SqlTypes;
using UnityEngine;
using UnityEngine.InputSystem;


public class InterfaceController : MonoBehaviour
{
    public GameObject inventoryPanel;
    public InputAction ocInv;
    public bool isInventoryOpen = false;

    private void OnEnable()
    {
        ocInv.Enable();
        ocInv.performed += Abriinventory;
    }
    private void OnDisable()
    {
        ocInv.Disable();
        ocInv.performed -= Abriinventory;
    }

    private void Abriinventory(InputAction.CallbackContext context)
    {
          isInventoryOpen = !isInventoryOpen;
        if (isInventoryOpen)
        {
            Cursor.lockState = CursorLockMode.None;
            inventoryPanel.SetActive(true);
        }
        if (!isInventoryOpen)
        {
            inventoryPanel.SetActive(false);        
        }

    }

}
