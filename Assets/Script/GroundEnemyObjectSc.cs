using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;

public class GroundEnemyObjectSc : MonoBehaviour
{
    private bool Flag = true;
    public GameObject Enemybullet;
    public int NoOfBullet = 1;
    public float SpeedBullet = 0.01f;
    public GameObject PlayerGameObject;
    private bool StartFlag = false;

    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (Flag && StartFlag)
        {
            StartCoroutine(BulletFire());

        }
        if (PlayerGameObject == null)
        {
            return;
        }
        Vector3 moveDirection = transform.position - PlayerGameObject.transform.position;
        //Debug.Log("Angle" + moveDirection);
        float angle = Mathf.Atan2(moveDirection.y, moveDirection.x) * Mathf.Rad2Deg - 90;
//        transform.rotation = Quaternion.Lerp(PlayerGameObject.transform.rotation, Quaternion.AngleAxis(angle, Vector3.forward), 50 * Time.deltaTime);
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

    }

    void OnBecameVisible()
    {
        StartFlag = true;
    }

    IEnumerator BulletFire()
    {
        Flag = false;
        float x = -(Enemybullet.GetComponent<SpriteRenderer>().bounds.size.x / 2) * (Mathf.Clamp(NoOfBullet, 1, 6) - 1);
        Vector2 offset = transform.TransformPoint(GetComponent<BoxCollider2D>().offset);
        Vector2 size = GetComponent<BoxCollider2D>().size;

        //Debug.Log("offset "+offset);
        for (int i = 0; i < Mathf.Clamp(NoOfBullet, 1, 6); i++)
        {
            Vector3 pos = offset;
            //pos.y -= ((size.y / 2));
            x += Enemybullet.GetComponent<SpriteRenderer>().bounds.size.x;
            //pos.x +=;
            //Debug.Log("pos2 " + pos+"x="+x);
            GameObject o = Instantiate(Enemybullet, pos, Quaternion.identity);
            o.GetComponent<EnemyBulletScript>().RefObject = transform.rotation;
        }
        yield return new WaitForSeconds(SpeedBullet);
        Flag = true;
    }

   

}