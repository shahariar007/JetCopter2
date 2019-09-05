using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.WSA;


public class SoundScript : MonoBehaviour {
	// Use this for initialization

    public AudioClip GunFire;
    public AudioClip BulletHit;
    public AudioClip CoinCollect;
    public AudioClip GunShotSound;

    public static SoundScript Insatnce
    {
        get { return FindObjectOfType<SoundScript>(); }
    }

	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void HeroPlaneBulletFire01()
    {
        
    }

    public void PlayCoinSound(AudioSource source)
    {
        source.clip = CoinCollect;
        source.Play();
    }

    public void PlayGunSound(AudioSource source)
    {
        source.clip = GunShotSound;
        source.Play();
    }
}
