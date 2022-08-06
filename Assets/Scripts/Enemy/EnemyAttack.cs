using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    float startTimeBtwShots = 0.5f;
    private float timeBtwShots;

    public GameObject prefabGlow;
    public Transform goFirePoint;
    public Transform goFirePoint2;

    EnemyAnimations anim;
    CharacterSfx sfx;

    private bool playerIsNear;
    public bool dual = false;

    void Start()
    {
        RandomizeValues();
        anim = GetComponent<EnemyAnimations>();
        playerIsNear = true; //change later
        sfx = GetComponentInChildren<CharacterSfx>();
    }
    private void Update()
    {
        if (!PauseControl.gameIsPaused && playerIsNear)
        {
            RangedAttack();
        }
    }
    void RangedAttack()
    {
        if (timeBtwShots <= 0)
        {
            Instantiate(prefabGlow, goFirePoint.position, goFirePoint.rotation);
            if(dual) Instantiate(prefabGlow, goFirePoint2.position, goFirePoint2.rotation);
            timeBtwShots = startTimeBtwShots;
            anim.Squash();
            sfx.PlayShoot(0.05f,0.3f);
        }
        else
        {
            timeBtwShots -= Time.deltaTime;
        }
    }
    void RandomizeValues()
    {
        startTimeBtwShots = Random.Range(0.5f, 2f);
        timeBtwShots = startTimeBtwShots;
    }
}
