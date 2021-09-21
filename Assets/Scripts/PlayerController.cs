using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float bulletInSec;
    [SerializeField] private float speedBullet;
    [SerializeField] private float damageBullet;
    [SerializeField] private float distanceShoot;
    [SerializeField] private float speedPlayer;
    public float health;
    [SerializeField] private Rigidbody2D bulletPrefab;
    [SerializeField] private Transform firePoint;

    private Camera _cam;
    private float _inputX;
    private Vector2 _min;
    private Vector2 _max;
    private GameObject _targetMonster;
    private Vector2 _direction, _currentDirection;
    private float _timeOut;
    private float _cureTimeOut;
    void Start()
    {
       _cam = Camera.main;
       _min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));
       _max = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));

        _timeOut = 1 / bulletInSec;
        _cureTimeOut = _timeOut;
    }

    
    void Update()
    {
        _inputX = Input.GetAxis("Horizontal");

        if (_targetMonster == null)
        {
            transform.LookAt(new Vector3(transform.position.x, transform.position.y, transform.position.z + 1));
            SearchEnemy();
        }
        else 
        {
            LookAtEnemy(_targetMonster);     
            if (_cureTimeOut >= _timeOut) //¬фдерживаю паузу между выстрелами
            {
                Fire();
                _cureTimeOut = 0;
            }
            else 
            {
                _cureTimeOut += Time.deltaTime;
            }
        }
        Movement();
       
    }

    private void Movement()
    {
        if (transform.position.x > _min.x && _inputX < 0)
        {
            transform.position = Vector2.MoveTowards(transform.position, new Vector2(transform.position.x + _inputX, transform.position.y), speedPlayer * Time.deltaTime);
        }
        else if(transform.position.x < _max.x && _inputX > 0)
        {
            transform.position = Vector2.MoveTowards(transform.position, new Vector2(transform.position.x + _inputX, transform.position.y), speedPlayer * Time.deltaTime);
        }
    }
    private void LookAtEnemy(GameObject enemy)
    {        
        _direction = enemy.transform.position - this.transform.position;
        _direction.Normalize();
        _currentDirection = Vector2.Lerp(_currentDirection, _direction, Time.deltaTime*100);
        this.transform.up = _currentDirection;
    }

    private void Fire()
    {       
        Rigidbody2D bullet = Instantiate(bulletPrefab, firePoint.position, Quaternion.identity) as Rigidbody2D;
        bullet.velocity = firePoint.up * speedBullet;
        bullet.GetComponent<Bullet>().damage = damageBullet;
    }

    private void SearchEnemy()
    {
        RaycastHit2D search = Physics2D.Raycast(transform.position, Vector2.up, distanceShoot) ;
        if (search.collider != null && search.collider.transform.CompareTag("Enemy"))
        {
            _targetMonster = search.transform.gameObject;          
        }
    }
}
