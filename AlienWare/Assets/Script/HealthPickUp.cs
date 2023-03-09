using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickUp : MonoBehaviour
{

    public ParticleSystem healup;
    private void OnTriggerEnter2D(Collider2D other){
        if(other.tag == "Player"){
            PlayerHealhComponent.instance.HealUp();
            Instantiate(healup , transform.position , transform.rotation);
            Destroy(gameObject);
        }

    }
}
