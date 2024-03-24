using System;
using UnityEngine;
using UnityEngine.InputSystem;
using static Controls;

[CreateAssetMenu(menuName = "SO/Input/PlayInput")]
public class PlayInputSO : InputSO, IPlayActions
{
    public event Action<FireType> OnFireEvent = null;
    public event Action OnJumpEvent = null;

    public Vector2 MovementInput { get; private set; }
    public Vector2 MouseDelta { get; private set; }

    protected override void OnEnable()
    {
        base.OnEnable();

        PlayActions play = InputManager.controls.Play;
        play.SetCallbacks(this);
        InputManager.RegistInput(this, play.Get());
    }

    public void OnMovement(InputAction.CallbackContext context)
    {
        MovementInput = context.ReadValue<Vector2>();
    }

    public void OnMouseDelta(InputAction.CallbackContext context)
    {
        MouseDelta = context.ReadValue<Vector2>();
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        if(context.performed)
            OnJumpEvent?.Invoke();
    }

    public void OnFire(InputAction.CallbackContext context)
    {
        if(context.performed)
        {
            FireType fireType = FireType.None;
            if(context.control.name == "leftButton")
                fireType = FireType.Take;
            else if(context.control.name == "rightButton")
                fireType = FireType.Give;
            OnFireEvent?.Invoke(fireType);
        }
    }
}
