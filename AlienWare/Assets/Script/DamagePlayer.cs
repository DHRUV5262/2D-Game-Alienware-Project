using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamagePlayer : MonoBehaviour
{


    public int Damage = 1 ;

    public bool DestroyObjects ;
    public GameObject Explode ;


    private void OnCollisionEnter2D(Collision2D other){
        if(other.gameObject.tag == "Player"){
            DealDamage() ;
        }
    }

    private void OnTriggerEnter2D(Collider2D other){
        if(other.tag == "Player"){
            DealDamage() ;
        }
    }

    private void DealDamage(){
        PlayerHealhComponent.instance.DamagePlayer(Damage);

        if(DestroyObjects){
            if(Explode != null){
                Instantiate(Explode , transform.position , transform.rotation);
            }
            Destroy(gameObject);
        }
    }

}
