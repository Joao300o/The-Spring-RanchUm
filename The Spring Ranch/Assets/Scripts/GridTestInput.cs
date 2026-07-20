using UnityEngine;
using UnityEngine.InputSystem;

public class GridTestInput : MonoBehaviour
{
    public Transform plantPoint;

    public Vector3 GetSelectedPosition()
    {
        return plantPoint.position;
    }

    public bool GetTillInput()
    {
        return Mouse.current.rightButton.wasPressedThisFrame;
    }

    public bool GetPlacementInput()
    {
        return Mouse.current.leftButton.wasPressedThisFrame;
    }
}