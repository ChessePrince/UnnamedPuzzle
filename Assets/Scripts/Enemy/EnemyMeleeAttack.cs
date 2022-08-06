using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMeleeAttack : MonoBehaviour
{
    public GameObject prefabExplosion;
    CharacterSfx sfx;
    EnemyHealth enemyHealth;
    void Start()
    {
        sfx = GetComponentInChildren<CharacterSfx>();
        enemyHealth = GetComponent<EnemyHealth>();
    }
    private void Update()
    {

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Melee();
        }
        if(collision.gameObject.tag == "PinkGlow")
        {
            enemyHealth.TakeDamage(3);
        }
    }
    void Melee()
    {
        GameObject effect = Instantiate(prefabExplosion, transform.position, Quaternion.identity);
        Destroy(effect, 2f);
        //sfx.PlayShoot(0.05f, 0.3f);
        enemyHealth.TakeDamage(2);
    }
}
