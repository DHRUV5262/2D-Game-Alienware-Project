using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthController : MonoBehaviour
{

    public int Total = 3 ;
    public GameObject deathEffect ;

    public void DamageEvent(int DamageAmount){

        Total = Total - DamageAmount ;
        if(Total <= 0){
            if(deathEffect){
                Instantiate(deathEffect, transform.position , transform.rotation);
            }
            Destroy(gameObject);
        }
    }
}
