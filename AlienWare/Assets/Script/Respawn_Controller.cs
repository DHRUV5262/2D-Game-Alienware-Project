using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Respawn_Controller : MonoBehaviour
{

    public static Respawn_Controller instace ;

    private void Awake(){
        if(instace == null){
            instace = this ;
            DontDestroyOnLoad(gameObject);
        }
        else{
            Destroy(gameObject);
        }
    }

    private Vector3 respawnPoint ;

    public float WaitTillRespawn ;

    private GameObject thePlayer ;


    // Start is called before the first frame update
    void Start()
    {
        thePlayer = PlayerHealhComponent.instance.gameObject ;
        respawnPoint = thePlayer.transform.position ;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeRespawn(Vector3 posi){
        respawnPoint = posi ;
    }

    public void Respawn(){
        StartCoroutine(RespawnCo());
    }

    IEnumerator RespawnCo(){
        thePlayer.SetActive(false);
        yield return new WaitForSeconds(WaitTillRespawn);

        SceneManager.LoadScene(SceneManager.GetActiveScene().name);

        thePlayer.transform.position = respawnPoint ;
        thePlayer.SetActive(true);
    }

}
