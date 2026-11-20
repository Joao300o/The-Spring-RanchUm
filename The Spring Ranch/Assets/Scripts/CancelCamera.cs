using UnityEngine;

public class CancelCamera : MonoBehaviour
{


    private void OnEnable()
    {
        PlayerMove playerMove = FindFirstObjectByType<PlayerMove>();
    }
    private void OnDisable()
    {
        
    }
}
