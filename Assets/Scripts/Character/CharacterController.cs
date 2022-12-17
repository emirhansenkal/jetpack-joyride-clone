using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    //Singleton
    private static CharacterController _instance;

    public static CharacterController Instance => _instance;
    
    private Character _character;

    private void Awake()
    {
        _instance = this;
    }

    public Vector3 GetCharacterPosition()
    {
        return _character.transform.position;
    }

    public void Register(Character character)
    {
        _character = character;
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            _character.Fly();
        }else if (Input.GetKeyUp(KeyCode.Space))
        {
            _character.StopFlying();
        }
        
        _character.MoveForward();
    }
}
