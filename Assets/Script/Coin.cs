using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public GameObject MainPlayer;
    public GameObject CoinGameObject;
    public AudioClip CoinAudioClip;
    public AudioSource AudioSource;

    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }

    void OnTriggerEnter2D(Collider2D collider2D)
    {
        if (collider2D.CompareTag("HeroPlayer"))
        {

            AudioSource s = GetComponent<AudioSource>();
            SoundScript.Insatnce.PlayCoinSound(s); 
            GetComponent<SpriteRenderer>().color = new Color(255,255,255,0);
            //AudioSource.clip = CoinAudioClip;
            // AudioSource.Play();
            //gameObject.SetActive(false);
            StartCoroutine("DestroyCoin");
        }
    }

    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

    IEnumerator DestroyCoin()
    {
        while (GetComponent<AudioSource>().isPlaying)
        {
            
            yield return null;
        }
        Destroy(gameObject);
    }
}