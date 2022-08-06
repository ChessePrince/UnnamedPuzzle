using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimations : MonoBehaviour
{
    Animator anim;
    public string squash;
    public string idle;
    void Start()
    {
        anim = GetComponent<Animator>();
    }
    public void Squash()
    {
        anim.Play(squash);
    }
    public void Idle()
    {
        if (!this.anim.GetCurrentAnimatorStateInfo(0).IsName("MothIdle"))
        {
            anim.Play(idle);
        }
    }
}
