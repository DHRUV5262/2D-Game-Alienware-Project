using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombController : MonoBehaviour
{
    public float TimetoExplode ;
    public GameObject explosion;
    // Start is called before the first frame update

    public float Blastrange;
    public LayerMask whatisDesructable;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        TimetoExplode -= Time.deltaTime;
        if(TimetoExplode <= 0){
            if(explosion != null){
                Instantiate(explosion , transform.position , transform.rotation);
            }
            Destroy(gameObject);
            Collider2D[] objectto = Physics2D.OverlapCircleAll(transform.position , Blastrange , whatisDesructable);
            if(objectto.Length > 0 ){
                foreach(Collider2D col in objectto){
                    Destroy(col.gameObject);
                }
            }
        }
        
    }
}
