using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour {

    public float speed;


    
    // Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        //i move up at 10 speeed 

        transform.Translate(Vector3.up * 10 * Time.deltaTime);


       // StartCoroutine("");


        if(transform.position.y >= 6)

        {
            if(transform.parent != null)
            {
                Destroy(transform.parent.gameObject);  
            }

            Destroy(this.gameObject);
        }

            
	}
}
