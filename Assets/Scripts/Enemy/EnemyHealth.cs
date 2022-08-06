using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    int health = 3;

    SpriteRenderer compRnd;
    public Material matWhite;
    Material matDefault;
    EnemyAnimations anim;
    CharacterSfx sfx;

    public bool melee = false;
    public GameObject prefabDeath;
    void Awake()
    {
        compRnd = GetComponent<SpriteRenderer>();
        //hitShader = Shader.Find("GUI/Text Shader");
        matDefault = compRnd.material;
        anim = GetComponent<EnemyAnimations>();
        sfx = GetComponentInChildren<CharacterSfx>();
    }
    public void TakeDamage(int amount)
    {
        //Instantiate(hurtSound, transform.position, Quaternion.identity);
        health -= amount;
        Debug.Log(health+" enemy hp");
        HitFeedback();
        if (!melee)
        {
            anim.Squash();
        }
        if (amount == 1)
        {
            sfx.PlayHurt();
        }
        if (health <= 0)
        {
            GameObject effect = Instantiate(prefabDeath, transform.position, Quaternion.identity);
            Destroy(effect, 2f);
            Destroy(this.gameObject);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "PinkGlow")
        {
            if (!melee)
                TakeDamage(1);
        }
    }
    void HitFeedback()
    {
        compRnd.material = matWhite;
        //compRnd.material.color = Color.white;

        StartCoroutine(BackToDefaultMaterial());
    }
    IEnumerator BackToDefaultMaterial()
    {
        while (Time.timeScale != 1.0f)
            yield return null;//wait for hit stop to end
        compRnd.material = matDefault;
        //compRnd.material.color = Color.white;
        //Instantiate(breakPrefab, transform.position, Quaternion.identity);
        //Destroy(gameObject);
    }
    void OnEnable()
    {
        EnemyManager.numberOfEnemies++;
    }
    void OnDisable()
    {
        EnemyManager.numberOfEnemies--;
    }
}
