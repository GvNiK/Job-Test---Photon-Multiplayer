using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerInputCallbacks 
{
    public Action<Vector2> OnPlayerMoved = delegate { };
    public Action<bool> OnPlayerJumpPressed = delegate { };

}
