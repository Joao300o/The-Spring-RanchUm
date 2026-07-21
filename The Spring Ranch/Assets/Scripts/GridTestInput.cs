using UnityEngine;
using UnityEngine.InputSystem;

public class GridTestInput : MonoBehaviour
{
    public Camera mainCamera;
    public LayerMask groundLayer;

    private Vector3 lastValidPosition; // Armazena a última posição válida do mouse no mundo

    public Vector3 GetSelectedPosition()
    {
        Vector2 mousePos = Mouse.current.position.ReadValue(); // Pega a posição do mouse na tela

        Ray ray = mainCamera.ScreenPointToRay(mousePos); // Cria um raio a partir da posição do mouse na tela

        if (Physics.Raycast(ray, out RaycastHit hit, 100f, groundLayer)) // Verifica se o raio colidiu com o chão (groundLayer) dentro de 1 unidade de distância
        {
            lastValidPosition = hit.point; // Atualiza a última posição válida do mouse no mundo
        }

        return lastValidPosition; // Retorna a última posição válida do mouse no mundo, mesmo que o mouse esteja fora do chão
    }

    public bool GetTillInput() // Método para verificar se o botão direito do mouse foi pressionado
    {
        return Mouse.current.rightButton.wasPressedThisFrame; // Retorna true se o botão direito do mouse foi pressionado nesta frame
    }

    public bool GetPlacementInput() // Método para verificar se o botão esquerdo do mouse foi pressionado
    {
        return Mouse.current.leftButton.wasPressedThisFrame; //  Retorna true se o botão esquerdo do mouse foi pressionado nesta frame
    }
}