using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LifeWall : MonoBehaviour
{
    [SerializeField] private EnemyEmmitorsController enemyEmmitorsController;
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject win, loose;
    [SerializeField] private Text healthText;

    public static int needToKillEnemy;

    private float health;
    void Start()
    {
        health = player.GetComponent<PlayerController>().health;
        needToKillEnemy = enemyEmmitorsController._numberEnemy;
        win.SetActive(false);
        loose.SetActive(false);      
    }

    // Update is called once per frame
    void Update()
    { 
        if (health <= 0)
        {
            Destroy(player.gameObject);
            loose.SetActive(true);
            healthText.text = "Cry";
        }
        else if (needToKillEnemy <= 0)
        {
            win.SetActive(true);
            healthText.text = "Good";
        }
        else
        {
            healthText.text = health.ToString();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            health -= collision.GetComponent<EnemyController>().damage;
            collision.GetComponent<EnemyController>().health = 0;
        }
    }
}
