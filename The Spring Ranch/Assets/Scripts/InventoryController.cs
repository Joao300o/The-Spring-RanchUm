using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InventoryController : MonoBehaviour
{
    public Image[] sloatImage;
    public TextMeshProUGUI[] slotAmountText;   // um texto por slot, pra mostrar a quantidade
    public Objects[] slotItems;
    public int[] slotAmount;
    public Objects wheatItem;



    public void GiveMeWheat()
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