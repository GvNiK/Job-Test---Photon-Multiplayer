using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] Transform player;
    public Vector3 offset;

    private void LateUpdate() 
    {
        transform.position = player.position + offset;    
    }
}