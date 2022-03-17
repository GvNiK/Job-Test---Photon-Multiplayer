using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputs : PlayerControls.IPlayerActions
{
    private PlayerControls playerControls;
    private PlayerInputCallbacks callbacks;
    public Vector2 movement;
    public bool jumpPressed;

    public PlayerInputs(PlayerControls playerControls, PlayerInputCallbacks callbacks)
    {
        this.playerControls = playerControls;
        this.callbacks = callbacks;

        playerControls.Player.SetCallbacks(this);
    }

    public void Enable() 
    {
        playerControls.Player.Enable();
    }

    public void Disable() 
    {
        playerControls.Player.Disable();    
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        movement = context.ReadValue<Vector2>();
        callbacks.OnPlayerMoved.Invoke(movement);    
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        switch(context.phase)
        {
            case InputActionPhase.Performed:
                jumpPressed = context.ReadValueAsButton();
                callbacks.OnPlayerJumpPressed.Invoke(jumpPressed);
            break;

            //**** IMP *****//
            /* runSpeed is alsways set to "True" whenever we press the Shift key for the first time.
            So we have to manually set it "False", whenever we release the button.
            */
            case InputActionPhase.Canceled:
            case InputActionPhase.Disabled:
                jumpPressed = false;
                callbacks.OnPlayerJumpPressed.Invoke(jumpPressed);
            break;
        }
    }
}
