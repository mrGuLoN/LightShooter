using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyEmmitor : MonoBehaviour
{
    [SerializeField] private Rigidbody2D EnemyPrefab;
    public bool needEmmitor;
    void Start()
    {
        needEmmitor = false;
    }

   
    void Update()
    {
        if (needEmmitor == true)
        {
            needEmmitor = false;
            Rigidbody2D enemy = Instantiate(EnemyPrefab, transform.position, Quaternion.identity) as Rigidbody2D;
        }
    }
}
