using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class DoorController : MonoBehaviour
{

    public Animator anim ;

    public float distanceFromDoor;

    private PlayerMovement play ;

    private bool PlayerExiting ;

    public Transform exitpoint ;

    public Transform SpawnPoint;

    public float speed ;

    public string LevelToLoad ;

    // Start is called before the first frame update
    void Start()
    {
        play = PlayerHealhComponent.instance.GetComponent<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Vector3.Distance(transform.position , play.transform.position) < distanceFromDoor){
            anim.SetBool("DoorOpen" , false );
        }
        else{
            anim.SetBool("DoorOpen" , true);
        }

        if(PlayerExiting){
            play.transform.position = Vector3.MoveTowards(play.transform.position , exitpoint.position , speed*Time.deltaTime);
        }
    }

    private void OnTriggerEnter2D(Collider2D other){
        
        if(other.gameObject.tag == play.tag){
            if(!PlayerExiting){
                play.canMove = false;
                StartCoroutine(UseDoor());
            }
        } 
    }

    IEnumerator UseDoor(){

        PlayerExiting = true ;
        play.anim.enabled = false ;

        Canvas_Contoller.instance.startFadingToBlack();

        yield return new WaitForSeconds(1.5f);

        play.canMove = true ;
        Respawn_Controller.instace.ChangeRespawn(exitpoint.position);
        play.anim.enabled = true ;
         Canvas_Contoller.instance.StartFadingFromBlack();
        SceneManager.LoadScene(LevelToLoad);
    }
    
}
