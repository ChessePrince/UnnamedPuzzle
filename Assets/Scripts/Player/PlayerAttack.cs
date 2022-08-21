using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] GameObject prefabGlow;
    [SerializeField] Transform goFirePoint;

    public float startTimeBtwShots;
    private float timeBtwShots;

    PlayerAnimation anim;
    CharacterSfx sfx;
    void Start()
    {
        timeBtwShots = startTimeBtwShots;
        anim = GetComponent<PlayerAnimation>();
        sfx = GetComponentInChildren<CharacterSfx>();
    }
    void Update()
    {
        if (!PauseControl.gameIsPaused)
        {
            CooldownAttack();
        }
    }
    public void Attack(Transform muzzle)
    {
        if (Input.GetMouseButtonDown(0))
        {
            Instantiate(prefabGlow, muzzle.position, muzzle.rotation);
            timeBtwShots = startTimeBtwShots;
            //anim.Squash();
            //sfx.PlayShoot(0.4f,0.6f);
        }
    }
    void CooldownAttack()
    {
        if (timeBtwShots <= 0)
        {
            Attack(goFirePoint);
        }
        else
        {
            timeBtwShots -= Time.deltaTime;
        }
    }
}
