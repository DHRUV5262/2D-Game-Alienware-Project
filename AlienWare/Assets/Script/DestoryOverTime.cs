using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestoryOverTime : MonoBehaviour
{

    public float lifetime ;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject , lifetime);
    }


}
