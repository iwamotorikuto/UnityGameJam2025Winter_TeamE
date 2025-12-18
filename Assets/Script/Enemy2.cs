using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy2 : MonoBehaviour
{
    public Image healthImage;
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
        if (Input.GetMouseButtonDown(0))
        {
            damage(10);
        }
        if (Input.GetMouseButtonDown(1))
        {
            heal(5);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        //当たったのがプレイヤー
        if (other.gameObject.CompareTag("Bird4_Cyan"))
        {

            damage(10);
        }
    }

    //void Damage(int damage)
    //{
    //    hp -= damage;
    //    if(hp <= 0)
    //    {
    //        hp = 0;
    //    }
    //}

    public void damage(int damage)
    {
        hp -= damage;
        healthImage.fillAmount = (float)hp / maxHealth;
    }

    public void heal(int heal)
    {
        hp += heal;
        healthImage.fillAmount = (float)hp / maxHealth;
    }
}
