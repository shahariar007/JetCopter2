using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Random = UnityEngine.Random;

public class PlayerMoveWithCamera : MonoBehaviour
{
    public float Speed;

    public Camera Camera;

    private float _x;

    private float _y;

    private Vector3 _offset;
    private Vector3 _pos;

    private bool _isMoving;

    public GameObject Bullet;
    public GameObject CoinGameObject;

    private bool Flag = true;
    public int NoOfBullet = 1;
    public float MoveSpeed = 55f;
    public float MoveTime = 0.3f;
    private bool FlagCoin = true;
    public AudioSource AudioSource;


    // Use this for initialization
    void Start()
    {
        _x = GetComponent<SpriteRenderer>().bounds.size.x / 2;
        _y = GetComponent<SpriteRenderer>().bounds.size.y / 2;
        //Debug.Log("CoinGameObject=" + CoinGameObject.GetComponent<SpriteRenderer>().size);

    }

    // Update is called once per frame
    void Update()
    {
        if (Application.platform == RuntimePlatform.Android)
        {
            if (Input.GetKey(KeyCode.Escape))
            {
                SceneManager.LoadScene("StartScreen");
                return;
            }
        }
        if (gameObject == null)
        {
          return;
        }
        

        if (Input.GetMouseButtonDown(0))
        {
            _isMoving = true;
        }
        if (Input.GetMouseButtonUp(0))
        {
            _isMoving = false;
        }
        if (_isMoving)
        {
            Vector3 p = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            float step = MoveSpeed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, p, step);
            //transform.position = p;
            _offset = -Camera.transform.position + transform.position;

            //Debug.Log("Test=" + p);
        }
        Vector3 maxPos = Camera.ViewportToWorldPoint(new Vector3(1, 1, 0));
        Vector3 minPos = Camera.ViewportToWorldPoint(new Vector3(0, 0, 0));
//        if (FlagCoin)
//        {
//            StartCoroutine(RandomCoin(minPos, maxPos));
//        }

        //Debug.Log("MouseViewPort" + "Max=" + maxPos + "Min=" + minPos);
        if (!_isMoving)
        {
            _pos = Camera.transform.position;
            _pos.x += _offset.x;
            _pos.y += _offset.y;
        }
        else
        {
            _pos = transform.position;
        }
        _pos.z = 0;
        _pos.x = Mathf.Clamp(_pos.x, minPos.x + _x, maxPos.x - _x);
        _pos.y = Mathf.Clamp(_pos.y, minPos.y + _y, maxPos.y - _y);
        transform.position = _pos;

        if (Flag)
        {
            StartCoroutine(BulletFire());
        }
        
    }

    IEnumerator BulletFire()
    {
        Flag = false;
        float x = -(Bullet.GetComponent<SpriteRenderer>().bounds.size.x / 2) * (Mathf.Clamp(NoOfBullet, 1, 6) - 1);
        Vector2 offset = transform.TransformPoint(GetComponent<BoxCollider2D>().offset);
        Vector2 size = GetComponent<BoxCollider2D>().size;
        //Debug.Log("offset "+offset);
        for (int i = 0; i < Mathf.Clamp(NoOfBullet, 1, 6); i++)
        {
            Vector3 pos = offset;
            pos.y += size.y / 2;
            pos.x += x;
            x += Bullet.GetComponent<SpriteRenderer>().bounds.size.x;
            //pos.x +=;
            //Debug.Log("pos2 " + pos+"x="+x);
            Instantiate(Bullet, pos, Quaternion.identity);
        }
        AudioSource s = GetComponent<AudioSource>();
        SoundScript.Insatnce.PlayGunSound(s);
        yield return new WaitForSeconds(MoveTime);
        Flag = true;
    }

    IEnumerator RandomCoin(Vector3 min, Vector3 max)
    {
        FlagCoin = false;
        float dSize = CoinGameObject.GetComponent<SpriteRenderer>().size.x;
        float eSize = CoinGameObject.GetComponent<SpriteRenderer>().size.y;
        Vector3 d = new Vector3((Random.Range(min.x, max.x)),(Random.Range(min.y,max.y)),0);
        Instantiate(CoinGameObject, d, Quaternion.identity);
        yield return new WaitForSeconds(5);
        FlagCoin = true;
    }

    
}