using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using Object = UnityEngine.Object;

public class PathFollower : MonoBehaviour
{
    private Node[] _pathNodes;
    public GameObject Player;
    public float MoveSpeed = 1;
    public float Timer;
    private static Vector3 _currentPositionHolder;
    private int _currentNode = 0;
    public GameObject VisibilityGameObject;
    private bool p = true;


    public int EnemyCount = 10;


    // Use this for initialization
    void Start()
    {
        //_pathNodes = FindObjectsOfType<Node>();
        _pathNodes = GetComponentsInChildren<Node>();
        //Array.Reverse(_pathNodes);
        for (int i = 0; i <_pathNodes.Length; i++)
        {
            Debug.Log("CheckNode"+_pathNodes[i]);
        }
        CheckNode();
    }

    void CheckNode()
    {
        _currentPositionHolder = _pathNodes[_currentNode].transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (!VisibilityGameObject.GetComponent<SpriteRenderer>().isVisible)
        {
            return;
        }
        if (Player == null)
        {
          // Debug.Log("AAAAAA===Null", gameObject);
            return;
        }
        if (p)
        {
            StartCoroutine("GenerateEnemy");
            p = false;
        }
        //Debug.Log("_currentNode" + _currentNode);
        //Debug.Log("magnitude" + (Player.transform.position - _currentPositionHolder).magnitude);
        
    }

    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

    IEnumerator GenerateEnemy()
    {

        for (int i = 0; i < EnemyCount; i++)
        {
            GameObject enemy = Instantiate(Player, _pathNodes[_currentNode].transform.position,Quaternion.identity);
            enemy.GetComponent<EnemyPlane01>()._pathNodes = _pathNodes;

            yield return new WaitForSeconds(.5f);
        }
        
    }

    public void FollowPath(GameObject enemy,int cNode)
    {
        
    }
    
}