using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AbilityUnlock : MonoBehaviour
{
    public bool DoubleJumpUnlock , DashUnlock , ballUnlock , MineUnlock ;


    public PlayerAblityTracker power;

    public GameObject AbilityEffect ;

    public string UnlockMesseage ;

    public TMP_Text unlockText;

    private void OnCollisionEnter2D(Collision2D other)
    {
          if(other.gameObject.tag == "Player"){
                
                if(DoubleJumpUnlock){
                    power.canDoubleJump = true;
                }
                if(DashUnlock){
                    power.canDash = true ;
                }
                if(ballUnlock){
                    power.canBall = true ;
                }
                if(MineUnlock){
                    power.canMine = true;
                }
               
                Instantiate(AbilityEffect , transform.position , transform.rotation);

                unlockText.transform.parent.SetParent(null);  
                unlockText.transform.position = transform.position;  
                unlockText.text = UnlockMesseage;
                unlockText.gameObject.SetActive(true);
                Destroy(unlockText.gameObject , 3f);


               Destroy(gameObject);
          }
    }
}
