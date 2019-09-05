using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletScript : MonoBehaviour
{
    public float BulletSpeed = 0f;
    public GameObject DustGameObject;
    private int heroPlaneInt = 0;
    private bool StartFlag = false;
    [HideInInspector] public Quaternion RefObject;

    // Use this for initialization
    void Start()
    {
        StartFlag = true;
    }

    // Update is called once per frame
    void Update()
    {
        
//            Vector3 v = GetComponent<Rigidbody2D>().position;
//            v.y -= BulletSpeed * Time.deltaTime;
//            transform.position = v;
       
        
    }

    void FixedUpdate()
    {
        if (StartFlag)
        {
            Vector3 dir = (RefObject * new Vector3(0, -1, 0));
            //dir.z = 0;
            Debug.Log("direction " + RefObject);
            dir *= BulletSpeed;
            GetComponent<Rigidbody2D>().velocity = dir;
            StartFlag = false;
        }

    }
    

    void OnTriggerEnter2D(Collider2D collider2D)
    {
        
        if (collider2D.tag == "HeroPlayer")
        {
          //  Debug.Log("AAAA"+heroPlaneInt);
           // heroPlaneInt++;
            Destroy(gameObject);
//            if (heroPlaneInt > 10)
//            {
                
                StartCoroutine(ExpDust(collider2D.gameObject));
               // heroPlaneInt = 0;
//            }
            

            //AudioSource.clip = CoinAudioClip;
            // AudioSource.Play();
        }
    }

    IEnumerator ExpDust(GameObject enemyGameObject)
    {
        Instantiate(DustGameObject, enemyGameObject.transform.position, Quaternion.identity);
        //Instantiate(CoinGameObject, enemyGameObject.transform.position, Quaternion.identity);
        Destroy(enemyGameObject);
        yield return new WaitForSeconds(0.1f);
        Debug.Log("TTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTT ELSE");

    }
    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}

