using UnityEngine.InputSystem;
using UnityEngine;
using static Controls;
using System;

[CreateAssetMenu(fileName = "NewInputReader", menuName = "Scriptable Objects/Input/InputReader")]
public class InputReader : ScriptableObject, IPlayerActionMapActions
{
    private Controls controls;
    private Vector2 move;

    public event Action<bool> PrimaryFireEvent;
    public event Action<Vector2> MoveEvent;
    public Vector2 AimPosition {  get; private set; }

    private void OnEnable()
    {
        if (controls == null)
        {
            controls = new();
            controls.PlayerActionMap.SetCallbacks(this);
        }
        controls.PlayerActionMap.Enable();
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        move = context.ReadValue<Vector2>();
        MoveEvent?.Invoke(move);
    }

    public void OnPrimaryFire(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            PrimaryFireEvent?.Invoke(true);
        }
        else if (context.canceled)
        {
            PrimaryFireEvent?.Invoke(false); 
        }
    }

    public void OnAiming(InputAction.CallbackContext context)
    {
        AimPosition = context.ReadValue<Vector2>();
    }
}
