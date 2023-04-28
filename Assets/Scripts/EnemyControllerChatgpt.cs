using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    Animator anim;
    public float moveSpeed = 5f; // d��man�n hareket h�z�
    public float attackRange = 10f; // sald�r� menzili
    public float attackCooldown = 2f; // sald�r� aral���
    public int attackDamage = 10; // sald�r� hasar�
    public Transform player; // oyuncu objesi

    private bool isAttacking = false; // sald�r� durumunu kontrol eden de�i�ken
    private float attackTimer = 0f; // sald�r� zamanlay�c�s�

    void Awake()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        // oyuncuya do�ru hareket et
        transform.LookAt(player);
        transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
        

        // d��man�n oyuncuya yak�nl���
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);

        // sald�r� menzilinde ise ve sald�r� zaman� aral��� ge�mi� ise sald�r� yap
        if (distanceToPlayer <= attackRange && !isAttacking && attackTimer <= 0f)
        {
            isAttacking = true;
            attackTimer = attackCooldown;
            anim.SetBool("attack1", true);

            // oyuncuya hasar ver
            player.GetComponent<player>().TakeDamage(attackDamage);
        }

        // sald�r� zamanlay�c�s�n� g�ncelle
        if (isAttacking)
        {
            attackTimer -= Time.deltaTime;

            if (attackTimer <= 0f)
            {
                isAttacking = false;
            }
        }

        // d��man�n hareket alan�n� s�n�rland�r
        if (transform.position.z < -10f)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, -10f);
        }
        else if (transform.position.z > 10f)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, 10f);
        }
    }
}

