using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMover : MonoBehaviour
{

    public Transform[] PatrolPoints ;
    private int CurrentPoint;

    public float Speed , WaitAtPoint ;
    private float waitCounter ;

    public float Jumpforce ;

    public Rigidbody2D Rb ;

    public Animator anim ;

    // Start is called before the first frame update
    void Start()
    {
        waitCounter = WaitAtPoint ;

        foreach(Transform pPoints in PatrolPoints){
            pPoints.SetParent(null);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(Mathf.Abs(transform.position.x - PatrolPoints[CurrentPoint].position.x) > 0.2 ){

            if(transform.position.x < PatrolPoints[CurrentPoint].position.x){

                Rb.velocity =new Vector2(Speed , Rb.velocity.y);
                transform.localScale = new Vector3(-1f,1f,1f);
            }
            else{
                Rb.velocity =new Vector2(-Speed , transform.position.y);
                transform.localScale = Vector3.one;
            }
            // if(transform.position.y < PatrolPoints[CurrentPoint].position.y-0.5f && Rb.velocity.y < 0.1f  ){
            //    Rb.velocity = new Vector2(Rb.velocity.x , Jumpforce);
            // }
        }
        else{
            Rb.velocity = new Vector2(0 , Rb.velocity.y);

            waitCounter -= Time.deltaTime;
            if(waitCounter <= 0){
                waitCounter = WaitAtPoint;
                CurrentPoint ++ ;
                if(CurrentPoint >= PatrolPoints.Length){
                    CurrentPoint =0;
                }
            }
        }

        anim.SetFloat("Speed" , Mathf.Abs(Rb.velocity.x));
    }
}
