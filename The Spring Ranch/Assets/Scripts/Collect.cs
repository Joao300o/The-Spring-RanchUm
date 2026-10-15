using UnityEngine;
using UnityEngine.InputSystem;

public class Collect : MonoBehaviour
{
    private void Update()
    {
        if (Mouse.current.leftButton.wasPressedThisFrame)
        {
            Ray ray = Camera.main.ScreenPointToRay(Mouse.current.position.ReadValue());

            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                Collectable collectable = hit.collider.GetComponent<Collectable>();
                if (collectable != null)
                {
                    collectable.Coletar();

                }
            }
        }
    }
}
