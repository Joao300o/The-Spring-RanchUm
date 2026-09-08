using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using TMPro;

public class InventoryController : MonoBehaviour
{
    public Image[] sloatImage;
    public TextMeshProUGUI[] slotAmountText;   // um texto por slot, pra mostrar a quantidade
    public Objects[] slotItems;
    public int[] slotAmount;
    public InputAction giveWheat;
    public Objects wheatItem;

    private void OnEnable()
    {
        giveWheat.Enable();
        giveWheat.performed += GiveMeWheat;
    }

    private void OnDisable()
    {
        giveWheat.performed -= GiveMeWheat;
        giveWheat.Disable();
    }

    void Start()
    {

    }

    void Update()
    {

    }

    private void GiveMeWheat(InputAction.CallbackContext context)
    {
        for (int i = 0; i < slotItems.Length; i++)
        {
            if (slotItems[i] == wheatItem)
            {
                slotAmount[i]++;
                sloatImage[i].sprite = wheatItem.itemIcon;
                slotAmountText[i].text = slotAmount[i].ToString();   // atualiza o texto visualmente
                Debug.Log($"Coletou {wheatItem.itemName}! Quantidade atual: {slotAmount[i]}");
                break;
            }
        }
    }
}