using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public Rigidbody2D RB ; 
    [SerializeField] float Speed ;
    [SerializeField] float JumpForce ;
    private bool isOnGround ;
    [SerializeField] Transform Groundpoint;
    [SerializeField] LayerMask groundLayer;

    public Animator anim;

    [SerializeField] BulletController Shot;
    [SerializeField] Transform shotpoint ;
    [SerializeField] bool DoubleJump;    
    [SerializeField] float dashspeed , dashtime;
    private float dashcounter ;
    
    [SerializeField] SpriteRenderer TheSR , afterImage ;
    [SerializeField] float AfterImagelifetime , TimeBimage;
    private float imageCounter;
    public Color AfterImageColor;
    [SerializeField] float WaitForDash ;
    private float Dashrecharege ;


    [SerializeField] GameObject  ball,standing ;
    public float waitforball ;
    private float ballcounter ;

    public Animator ballanim;
    


    public Transform bombpoint;
    public GameObject bomb ;


    private PlayerAblityTracker ablities ;

    public bool canMove = true;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        ablities = GetComponent<PlayerAblityTracker>();
    }

    // Update is called once per frame
    void Update()
    {

      if(canMove){
        running();
        Jump();
        Shoot();
        ballAction();
      }
      else{
        RB.velocity = Vector2.zero ;
      }
        
        if(standing.activeSelf){
            anim.SetBool("OnGround" , isOnGround );
            anim.SetFloat("Speed" ,Mathf.Abs(RB.velocity.x));
        }
        if(ball.activeSelf){

            ballanim.SetFloat("Speed" ,Mathf.Abs(RB.velocity.x));
        }
         

    }
    
    //for running left and right
    void running(){

        if(Dashrecharege > 0 ){
            Dashrecharege -= Time.deltaTime;
        }
        else
        {
            if(Input.GetButtonDown("Fire2") && standing.activeSelf && ablities.canDash)
            {
            dashcounter = dashtime ; 
             ShowAfterImage(); 
            }
        }
       
        if(dashcounter > 0)
        {
            dashcounter = dashcounter - Time.deltaTime;
            RB.velocity = new Vector2(dashspeed * transform.localScale.x , RB.velocity.y);
            imageCounter -= Time.deltaTime;
            if(imageCounter <= 0 ){
                ShowAfterImage();
            }
            Dashrecharege = WaitForDash ; 
        }
        else
        {
            RB.velocity = new Vector2(Input.GetAxisRaw("Horizontal") * Speed , RB.velocity.y );
            if(RB.velocity.x < 0){
                transform.localScale = new Vector3(-1f,1f,1f);
            }
            else if(RB.velocity.x > 0){
                transform.localScale =  Vector3.one;
             }
        }   
    }

    void Jump(){
        
        isOnGround = Physics2D.OverlapCircle(Groundpoint.position , .2f , groundLayer );
         if(Input.GetButtonDown("Jump") && (isOnGround || (DoubleJump && ablities.canDoubleJump)) ){

            if(isOnGround ){
                DoubleJump = true;
                
            }else{
                DoubleJump = false ;
                anim.SetTrigger("DoubleJump");
            }
            RB.velocity = new Vector2( RB.velocity.x , JumpForce );
        }
    }
    void Shoot(){

        
        if(Input.GetButtonDown("Fire1")){

            if(standing.activeSelf){
                Instantiate(Shot , shotpoint.position ,shotpoint.rotation ).Dirc = new Vector2(transform.localScale.x , 0f) ;
                anim.SetTrigger("Shoot");
            }
            else if(ball.activeSelf && ablities.canMine){
                Instantiate(bomb , bombpoint.position , bombpoint.rotation);
            }
        }
    }

    void ballAction(){
        if(Input.GetAxisRaw("Vertical") < -0.9f && !ball.activeSelf && ablities.canBall ){
                ballcounter -= Time.deltaTime ;
                if(ballcounter <= 0){
                    standing.SetActive(false);
                    ball.SetActive(true);
                }
            else{
                ballcounter = waitforball ;
            }
        }
        else if(ball.activeSelf && Input.GetAxisRaw("Vertical") > 0.9f  ){
            if(Input.GetAxisRaw("Vertical") > 0.9f){
                ballcounter -= Time.deltaTime ;
                if(ballcounter <= 0){
                    standing.SetActive(true);
                    ball.SetActive(false);
                }
            }
            else{
                ballcounter = waitforball ;
            }
        }
    }

    void ShowAfterImage(){
        SpriteRenderer Image =  Instantiate(afterImage , transform.position , transform.rotation);
        Image.sprite = TheSR.sprite ; 
        Image.transform.localScale =  transform.localScale ;
        Image.transform.position = TheSR.transform.position ;
        Image.color = AfterImageColor;
        Destroy(Image.gameObject , AfterImagelifetime);
    }

  

}
