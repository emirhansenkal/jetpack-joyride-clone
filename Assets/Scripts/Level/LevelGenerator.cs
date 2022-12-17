using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class LevelGenerator : MonoBehaviour
{
    [SerializeField]
    private GameObject[] Parts;

    [SerializeField]
    private int PoolSize = 3;
    
    private Vector3 _lastPosition = Vector3.zero;

    private static LevelGenerator _instance;
    public static LevelGenerator Instance => _instance;

    private Dictionary<int, List<GameObject>> _pools = new Dictionary<int, List<GameObject>>();
    
    private void Awake()
    {
        _instance = this;

        for (int i = 0; i < Parts.Length; i++)
        {
            var pool = new List<GameObject>();

            for (int j = 0; j < PoolSize; j++)
            {
                var part = Instantiate(Parts[i], transform);
                part.SetActive(false);
                pool.Add(part);
            }
            
            _pools.Add(i, pool);
        }
        
        for (int i = 0; i < Parts.Length; i++)
        {
            CreatePart(i);
        }
    }

    public void CreateRandomPart()
    {
        var type = Random.Range(0, Parts.Length);
        CreatePart(type);
    }

    public void CreatePart(int type)
    {
        var part =  _pools[type][0];
        _pools[type].Remove(part);
        part.SetActive(true);
        _lastPosition.x += 17.92f;
        part.transform.position = _lastPosition;
    }

    public void AddToPool(int type, GameObject part)
    {
        _pools[type].Add(part);
        part.SetActive(false);
    }
    
}
