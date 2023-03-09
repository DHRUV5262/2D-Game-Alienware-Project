using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI ;

public class PlayerHealhComponent : MonoBehaviour
{

    public static PlayerHealhComponent instance ;

    private void Awake(){
        if(instance == null){
            instance = this ;
            DontDestroyOnLoad(gameObject);
        }
        else{
            Destroy(gameObject);
        }
    }

    private Canvas_Contoller c ;

    //[HideInInspector]
    public int currentHealth = 10 ;
    public int maxHealth = 10;

    
    public float InviciablityLength ;
    private float InvicCurrent ;

    public float FlashLength ;
    private float FlashCounter ;

    public SpriteRenderer[] mesh ;

    public ParticleSystem deathEffect ;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth ;
        c = GameObject.FindGameObjectWithTag("Canvas").GetComponent<Canvas_Contoller>();
        c.UpdateHealth(currentHealth , maxHealth);
    }

    // Update is called once per frame
    void Update()
    {
        if(InvicCurrent > 0){

            InvicCurrent -= Time.deltaTime;

            FlashCounter -= Time.deltaTime ;

            if(FlashCounter <= 0){
                foreach(SpriteRenderer sr in mesh){
                        sr.enabled = !sr.enabled ;
                    }
                FlashCounter = FlashLength ;
            }
        }
        if(InvicCurrent <= 0){
            foreach(SpriteRenderer sr in mesh){
                 sr.enabled = true ;
            }
        }   
    }

    public void DamagePlayer(int DamageAmount){

        if(InvicCurrent <= 0){

             currentHealth -= DamageAmount ;
             if(currentHealth <= 0){
                currentHealth = 0 ;
                Respawn_Controller.instace.Respawn();
                Instantiate(deathEffect , transform.position , transform.rotation);
            }
            else
            {
                InvicCurrent = InviciablityLength ;
            }
            
            c.UpdateHealth(currentHealth,maxHealth);
        }
       

    }

    public void HealUp(){
        currentHealth = maxHealth ;
        c.UpdateHealth(currentHealth,maxHealth);
    }

    public void FillHealth(){
        currentHealth = maxHealth ;
        c.UpdateHealth(currentHealth , maxHealth);
    }
}
