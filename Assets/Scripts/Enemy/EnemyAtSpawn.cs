using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAtSpawn : MonoBehaviour
{
    [SerializeField] GameObject goParticleFx;

    private void OnEnable()
    {
        Instantiate(goParticleFx, transform.position, Quaternion.identity);
    }
}
