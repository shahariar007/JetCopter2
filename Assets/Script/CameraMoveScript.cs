using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMoveScript : MonoBehaviour
{
    
    public float Speed;
    public GameObject Refob;


    // Use this for initialization
    void Start()
    {
        float w = Refob.GetComponent<SpriteRenderer>().bounds.size.x;
        float r = Screen.height / (float)Screen.width;
        float os = r * (w/2);
        Camera.main.orthographicSize = os;

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 p = transform.position;
        p.y += Speed * Time.deltaTime;
        transform.position = p;
    }
}