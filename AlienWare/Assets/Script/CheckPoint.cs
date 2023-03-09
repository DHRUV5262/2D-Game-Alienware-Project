using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other){
        if(other.tag == "Player"){
            Respawn_Controller.instace.ChangeRespawn(transform.position);
        }
    }
}
