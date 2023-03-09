using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    [SerializeField] float Speed ;
    [SerializeField] Rigidbody2D RB ;
    public Vector2 Dirc ;
    [SerializeField] GameObject impact;

    [SerializeField] int Damage = 1 ; 



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        RB.velocity = Dirc * Speed ;
        
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag == "Enemy"){

            other.gameObject.GetComponent<EnemyHealthController>().DamageEvent(1);
        }

        if(impact != null){
            Instantiate(impact , transform.position , Quaternion.identity);
        }               
         Destroy(gameObject);
    }
    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

 
   
}