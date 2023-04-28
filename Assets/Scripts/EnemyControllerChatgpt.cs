using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    Animator anim;
    public float moveSpeed = 5f; // düþmanýn hareket hýzý
    public float attackRange = 10f; // saldýrý menzili
    public float attackCooldown = 2f; // saldýrý aralýðý
    public int attackDamage = 10; // saldýrý hasarý
    public Transform player; // oyuncu objesi

    private bool isAttacking = false; // saldýrý durumunu kontrol eden deðiþken
    private float attackTimer = 0f; // saldýrý zamanlayýcýsý

    void Awake()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        // oyuncuya doðru hareket et
        transform.LookAt(player);
        transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
        

        // düþmanýn oyuncuya yakýnlýðý
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);

        // saldýrý menzilinde ise ve saldýrý zamaný aralýðý geçmiþ ise saldýrý yap
        if (distanceToPlayer <= attackRange && !isAttacking && attackTimer <= 0f)
        {
            isAttacking = true;
            attackTimer = attackCooldown;
            anim.SetBool("attack1", true);

            // oyuncuya hasar ver
            player.GetComponent<player>().TakeDamage(attackDamage);
        }

        // saldýrý zamanlayýcýsýný güncelle
        if (isAttacking)
        {
            attackTimer -= Time.deltaTime;

            if (attackTimer <= 0f)
            {
                isAttacking = false;
            }
        }

        // düþmanýn hareket alanýný sýnýrlandýr
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

