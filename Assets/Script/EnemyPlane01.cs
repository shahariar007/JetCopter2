using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPlane01 : MonoBehaviour
{
    public GameObject ExpGameObject;
    

    [HideInInspector]
    public Node[] _pathNodes;
    private int cNode;
    public float MoveSpeed;

    // Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
	{
	    if (_pathNodes.Length <= 0) return;
	    Vector3 cp = _pathNodes[cNode].transform.position;
	    if ((transform.position - cp).magnitude > .1f)
	    {

	        transform.position = Vector3.MoveTowards(transform.position, cp,
	            Time.deltaTime * MoveSpeed);
	        Vector3 moveDirection = transform.position - cp;

	        float angle = Mathf.Atan2(moveDirection.y, moveDirection.x) * Mathf.Rad2Deg - 90;
	        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.AngleAxis(angle, Vector3.forward), MoveSpeed * Time.deltaTime);
	        //Debug.Log("Angle" + Vector3.Angle(Player.transform.position, _currentPositionHolder));
	    }
        else if(cNode==_pathNodes.Length-1) Destroy(gameObject);
	    else
	    {
	        cNode++;
	        cNode = Mathf.Clamp(cNode, 0, _pathNodes.Length - 1);
            
	    }
    }

   void OnTriggerEnter2D(Collider2D collider2D)
    {
        
        if (collider2D.CompareTag("HeroPlayer"))
        {
            Destroy(gameObject);
            StartCoroutine(ExpDust(collider2D.gameObject));
        }
    }

    IEnumerator ExpDust(GameObject enemyGameObject)
    {
        Instantiate(ExpGameObject, enemyGameObject.transform.position, Quaternion.identity);
        //Instantiate(CoinGameObject, enemyGameObject.transform.position, Quaternion.identity);
        Destroy(enemyGameObject);
        yield return new WaitForSeconds(0.3f);
        Debug.Log("TTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTT ELSE");

    }

    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
