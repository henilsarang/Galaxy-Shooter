using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour {

    [SerializeField]
    private float speed=5.0f;
    [SerializeField]    
    private GameObject _enemyExplosionPrefab;
    public UIManager ui_manager;
    private AudioSource audiosource;
    [SerializeField]
    private AudioClip clip;

	// Use this for initialization
	    void Start () {
        ui_manager = GameObject.Find("Canvas").GetComponent<UIManager>();

        audiosource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update () {

        //Move Down
        transform.Translate(Vector3.down * speed * Time.deltaTime);

        if (transform.position.y < -7)
        {
            float randomx = Random.Range(-7, 7);
            transform.position = new Vector3(randomx,7,0);
        }

	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Laser")
        {

            if(collision.transform.parent != null)
            {
                Destroy(collision.transform.parent);
            }
            Destroy(collision.gameObject);
            Instantiate(_enemyExplosionPrefab,transform.position,Quaternion.identity);
            ui_manager.UpdateScore();
            AudioSource.PlayClipAtPoint(clip,Camera.main.transform.position,1f);
            Destroy(this.gameObject);
        }
        else if(collision.tag == "Player")
        {
            Player player = collision.GetComponent<Player>();

            if (player != null)
            {
                player.Damage();
            }
            Instantiate(_enemyExplosionPrefab, transform.position, Quaternion.identity);
            AudioSource.PlayClipAtPoint(clip,Camera.main.transform.position,1f);

            Destroy(this.gameObject);
        }
    }
}
