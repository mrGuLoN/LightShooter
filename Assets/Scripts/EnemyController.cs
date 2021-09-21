using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private float speed;
    public float damage;
    public float health;

    
    void Update()
    {
        if (health > 0)
        {
            transform.position = Vector2.MoveTowards(transform.position, new Vector2(transform.position.x, transform.position.y - 1), speed * Time.deltaTime);            
        }
        else
        {
            LifeWall.needToKillEnemy--;
            Destroy(this.gameObject);
        }
    }
}
