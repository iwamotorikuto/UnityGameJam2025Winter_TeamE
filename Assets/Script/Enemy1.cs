using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1 : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;
    private int hp;
    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        hp = maxHealth;
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        //当たったのがプレイヤー
        if(other.gameObject.CompareTag("Bird4_Cyan"))
        {
            Damage(10);
        }
    }

    void Damage(int damage)
    {
        hp -= damage;
        if(hp <= 0)
        {
            hp = 0;
        }
    }
}
