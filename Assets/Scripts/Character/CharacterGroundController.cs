using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterGroundController : MonoBehaviour
{
    [SerializeField]
    private Character Character;

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Ground")
        {
            Character.Walk();
        }
    }
}
