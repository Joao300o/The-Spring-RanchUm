using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target; // o Player
    public Vector3 offset = new Vector3(0, 10, -10); // distância da câmera em relação ao player
    public float smoothSpeed = 5f; // velocidade de suavização do movimento da câmera

    void LateUpdate()
    {
        Vector3 desiredPosition = target.position + offset; // posição desejada da câmera
        transform.position = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed * Time.deltaTime); // suaviza o movimento da câmera
    }
}