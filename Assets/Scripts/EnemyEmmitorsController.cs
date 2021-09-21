using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyEmmitorsController : MonoBehaviour
{
    [SerializeField] private float minTimeOut, maxTimeOut;
    [SerializeField] private int minEnemy, maxEnemy;
    [SerializeField] private EnemyEmmitor[] enemyEmmitor;
    public int _numberEnemy;

    private float _timeOut;
    private float _cureTimeOut;   
    private int _numberEmmitor;
    private int i;

    void Awake()
    {
        _numberEnemy = Random.Range(minEnemy, maxEnemy + 1);
        _timeOut = Random.Range(minTimeOut, maxTimeOut);
        _cureTimeOut = _timeOut;
        i = 0;
    }

   
    void Update()
    {
        if (_cureTimeOut >= _timeOut && i < _numberEnemy)
        {
            i++;
            _numberEmmitor = Random.Range(0, enemyEmmitor.Length);
            enemyEmmitor[_numberEmmitor].GetComponent<EnemyEmmitor>().needEmmitor = true;
            _cureTimeOut = 0;
        }
        else
        {
            _cureTimeOut += Time.deltaTime;
        }
    }
}
