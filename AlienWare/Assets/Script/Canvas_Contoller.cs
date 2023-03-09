using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI ;

public class Canvas_Contoller : MonoBehaviour
{  

    public static Canvas_Contoller instance ;

    private void Awake(){
        if(instance == null){
            instance = this ;
            DontDestroyOnLoad(gameObject);
        }
        else{
            Destroy(gameObject);
        }
    }

    public Slider healthSlider;

    public Image FadeScreen;

    public float fadeSpeed = 2f;
 
    public bool FadeToBlack,FadeFromBlack;





    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(FadeToBlack){
            FadeScreen.color = new Color(FadeScreen.color.r , FadeScreen.color.g , FadeScreen.color.b , Mathf.MoveTowards(FadeScreen.color.a , 1f , fadeSpeed*Time.deltaTime));
            if(FadeScreen.color.a == 1f){
                FadeToBlack = false;
            }
        }
        else if(FadeFromBlack){
            FadeScreen.color = new Color(FadeScreen.color.r , FadeScreen.color.g , FadeScreen.color.b , Mathf.MoveTowards(FadeScreen.color.a , 0f , fadeSpeed*Time.deltaTime));
            if(FadeScreen.color.a == 0f){
                FadeFromBlack = false;
            }
        }
    }

    public void UpdateHealth(int currentHelath , int maxHealth){
        healthSlider.value = currentHelath ;
        healthSlider.maxValue = maxHealth ;
    }

    public void startFadingToBlack(){

        FadeToBlack = true ;
        FadeFromBlack = false ;
    }

    public void StartFadingFromBlack(){
        
        FadeToBlack = false ;
        FadeFromBlack = true ;
    }
}
