 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    [SerializeField]
    private float speed = 5.0f;
    public GameObject laserPrefab;
    public bool isShieldIsActive = false;

    public GameObject explosion; 
    public float firerate=0.25f;
    public float canfire = 0.0f;
    public bool canTripleShot = false;
    //  private int powerupID; // 0 = triple shot , 1 =  speed boost , 2 = shield

    public bool speedboost = false;

    private UIManager uimanager;

    private GameManager gamemanager;

    [SerializeField]
    private GameObject[] engines;

    public GameObject shieldGameObject;

    private Spawn_Manager spawmmanager;
        
    private AudioSource audiosource;
    private int hitcount = 0;   

    public int lives = 3; 
    
	void Start ()
    {
        transform.position = new Vector3(0,0,0);
        speed = 10;
        uimanager = GameObject.Find("Canvas").GetComponent<UIManager>();
        if(uimanager != null)
        {
            uimanager.Updatelives(lives);
        }

        gamemanager = GameObject.Find("GameManager").GetComponent<GameManager>();
        spawmmanager = GameObject.Find("Spawn_Manager").GetComponent<Spawn_Manager>(); 

        if(spawmmanager != null)
        {
            spawmmanager.StartSpawnRoutines(); 

        }
        audiosource = GetComponent<AudioSource>();
        hitcount = 0;
	}
	
	// Update is called once per frame
	void Update () {
        // Debug.Log("Henil here..!!   ");
        Movement();

        //if space key is pressed
        //spawn laser at player position
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButton(0)  )
        {
            Shoot();
        }

    }

    private void Shoot()
    {   
        if (Time.time > canfire)
        {

            audiosource.Play();
            if(canTripleShot  == true)
            {

                //Left
                Instantiate(laserPrefab, transform.position + new Vector3(-0.55f, 0.3f, 0), Quaternion.identity);


                //Center
                Instantiate(laserPrefab, transform.position + new Vector3(0, 1.2f, 0), Quaternion.identity);

                //Right
                Instantiate(laserPrefab, transform.position + new Vector3(0.55f,0.3f, 0), Quaternion.identity);



            }
            else
            {
                Instantiate(laserPrefab, transform.position + new Vector3(0, 1.2f, 0), Quaternion.identity);

            }
            canfire = Time.time + firerate;


        }

    }

    private void Movement()
    {

        float verticalInput = Input.GetAxis("Vertical");
        float horizontalInput = Input.GetAxis("Horizontal");
       

            transform.Translate(Vector3.right * Time.deltaTime * speed * horizontalInput);
            transform.Translate(Vector3.up * Time.deltaTime * speed * verticalInput);



        if (speedboost == true)
        {
           
            transform.Translate(Vector3.right * Time.deltaTime * speed * 1.5f * horizontalInput);
            transform.Translate(Vector3.up * Time.deltaTime * speed * verticalInput);
        }

        
        if (transform.position.y > 0)
        {
            transform.position = new Vector3(transform.position.x, 0, 0);

        }
        else if (transform.position.y < -4.2f)
        {
            transform.position = new Vector3(transform.position.x, -4.2f, 0);
        }

        /*
        if(transform.position.x>8)
        {
            transform.position = new Vector3(8,transform.position.y,0);

        }
        else if (transform.position.x < - 8)
        {
            transform.position = new Vector3(-8,transform.position.y,0);
        }
        */

        if (transform.position.x > 9.5f)
        {
            transform.position = new Vector3(-9.5f, transform.position.y, 0);

        }
        else if (transform.position.x < -9.5f)
        {
            transform.position = new Vector3(9.5f, transform.position.y, 0);
        }



    }
    public void Damage()
    {
        if(isShieldIsActive == true)
        {
            
            isShieldIsActive = false;
            shieldGameObject.SetActive(false);      
            return;
        }

        hitcount++;

        if (hitcount == 1)
        {
            engines[0].SetActive(true);
        }
        else if (hitcount == 2)
        {
            engines[1].SetActive(true);
        } 

        lives--;
        uimanager.Updatelives(lives);
        if(lives < 1)
        {
            Instantiate(explosion,transform.position,Quaternion.identity);
            gamemanager.GameOver = true;
            uimanager.ShowTitleScreen();
            Destroy(this.gameObject);
        }


    }


    public void TripleShotPowerupOn()
    {
        canTripleShot = true;
        StartCoroutine(TripleShotPowerDownRoutine());


    }
   public IEnumerator TripleShotPowerDownRoutine()
    {
        yield return new WaitForSeconds(5.0f);

        canTripleShot = false;   
    }


    public void enableShield()
    {
        isShieldIsActive = true;
        shieldGameObject.SetActive(true);
    }

    public void Speedboost()
    {

        speedboost = true;
        StartCoroutine(SpeedBoostPowerdownRoutine());

    }

    public IEnumerator SpeedBoostPowerdownRoutine()
    {
        yield return new WaitForSeconds(5.0f);
        speedboost = false;
    }


}
 