using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flyer_Controller : MonoBehaviour
{

    public float RangeToChase ;
    bool IsChasing ;

    public float Speed , TurnSpeed ;
   Transform Player ;

   public Animator anim ;

    // Start is called before the first frame update
    void Start()
    {
        Player  = PlayerHealhComponent.instance.transform ;
    }

    // Update is called once per frame
    void Update()
    {
        if(!IsChasing){
            if(Vector3.Distance(transform.position , Player.position) <= RangeToChase){
                IsChasing = true ;
                anim.SetBool("IsChasing" , IsChasing);
            }
        }
        else{
            if(Player.gameObject.activeSelf){
                Vector3 direction = transform.position - Player.position;
                float angle = Mathf.Atan2(direction.y , direction.x) * Mathf.Rad2Deg ;
                Quaternion target = Quaternion.AngleAxis(angle , Vector3.forward);
                transform.rotation = Quaternion.Slerp(transform.rotation , target , TurnSpeed * Time.deltaTime);
                //transform.position = Vector3.MoveTowards(transform.position , Player.position , Speed * Time.deltaTime);
                transform.position += -transform.right * Speed *Time.deltaTime ;
            }
        }
    }
}
