using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField]
    private Camera Camera;

    [SerializeField]
    private float Offset = 3;

    private void LateUpdate()
    {
        var targetPosition =  Camera.transform.position;
        targetPosition.x = CharacterController.Instance.GetCharacterPosition().x + Offset;
        Camera.transform.position = targetPosition;
    }
}
