using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float damage;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("Enemy"))
        {
            collision.transform.gameObject.GetComponent<EnemyController>().health -= damage;
            Destroy(this.gameObject);
        }       
    }   
}
