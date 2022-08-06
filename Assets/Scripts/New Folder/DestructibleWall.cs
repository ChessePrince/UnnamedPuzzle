using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestructibleWall : MonoBehaviour
{
    SpriteRenderer compRnd;
    public Sprite greenWall;
    int health;
    public GameObject ExpSpawn;
    public GameObject ExpDeath;
    public bool wallToGreen;
    public Material matWhite;
    Material matDefault;

    private void Start()
    {
        compRnd = GetComponent<SpriteRenderer>();
        health = 2;
        wallToGreen = false;
        matDefault = compRnd.material;
    }
    void ChangeSprite()
    {
        compRnd.sprite = greenWall;
    }
    void WallDestroyed()
    {
        Instantiate(ExpDeath, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "PinkGlow" && wallToGreen)
        {
            health--;
            compRnd.material = matWhite;

            StartCoroutine(BackToDefaultMaterial());
            if (health <= 0)
                WallDestroyed();
        }
    }
    IEnumerator BackToDefaultMaterial()
    {
        while (Time.timeScale != 1.0f)
            yield return null;//wait for hit stop to end
        compRnd.material = matDefault;
    }
    public void MakeWallGreen()
    {
        compRnd.sprite = greenWall;
        Instantiate(ExpSpawn, transform.position, Quaternion.identity);
        wallToGreen = true;
    }
}
