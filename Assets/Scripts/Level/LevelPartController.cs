using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelPartController : MonoBehaviour
{
    [SerializeField]
    private GameObject LevelPart;

    [SerializeField]
    private int Type;
    
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Player")
        {
            LevelGenerator.Instance.AddToPool(Type, LevelPart);
            LevelGenerator.Instance.CreateRandomPart();
        }
    }
}
