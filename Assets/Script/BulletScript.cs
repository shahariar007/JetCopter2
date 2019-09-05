using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    public float BulletSpeed = 0f;
    public GameObject CoinGameObject;
    public GameObject DustGameObject;

    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 v = GetComponent<Rigidbody2D>().position;
        v.y += BulletSpeed * Time.deltaTime;
        transform.position = v;
    }

    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

    void OnTriggerEnter2D(Collider2D collider2D)
    {
        if (collider2D.tag == "EnemyPlane")
        {
            Destroy(gameObject);
            StartCoroutine(RandomCoin(collider2D.gameObject));

            //AudioSource.clip = CoinAudioClip;
            // AudioSource.Play();
        }
        else if (collider2D.tag == "GroundEnemy")
        {
            Destroy(gameObject);
            StartCoroutine(RandomCoin(collider2D.gameObject));

            //AudioSource.clip = CoinAudioClip;
            // AudioSource.Play();
        }
    }

    IEnumerator RandomCoin(GameObject enemyGameObject)
    {
        Instantiate(DustGameObject, enemyGameObject.transform.position-new Vector3(0,1.1f,0), Quaternion.identity);
        Instantiate(CoinGameObject, enemyGameObject.transform.position, Quaternion.identity);
        Destroy(enemyGameObject);
        yield return new WaitForSeconds(0.1f);
        Debug.Log("TTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTT ELSE");
    }
}