using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Powerup : MonoBehaviour {

    private float speed = 3.0f;
    public int powerupID;
    [SerializeField]
    private AudioClip clip;



	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        transform.Translate(Vector3.down * speed * Time.deltaTime);

        if (transform.position.y < -7)
        {
            Destroy(this.gameObject);
        }    
		
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            //access the player
            Player player = collision.GetComponent<Player>();
            AudioSource.PlayClipAtPoint(clip, Camera.main.transform.position, 1f);  

            if (player != null)
            {
                //enable triple shot
                if (powerupID == 0)
                {
                    player.TripleShotPowerupOn();
                }
                else if (powerupID == 1)
                {

                    player.Speedboost();
                }
                else if(powerupID == 2) 
                {
                    player.enableShield();
                }
            }



            StartCoroutine(player.TripleShotPowerDownRoutine());
            StartCoroutine(player.SpeedBoostPowerdownRoutine());
            //destory the player
            Destroy(this.gameObject);
        }

    }
}
