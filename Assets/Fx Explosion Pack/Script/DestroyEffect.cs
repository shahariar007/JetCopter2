using UnityEngine;
using System.Collections;

public class DestroyEffect : MonoBehaviour
{

    public ParticleSystem ExplosonParticleSystem;
	void Start ()
	{

	    StartCoroutine("DestroyExp");

	}

    IEnumerator DestroyExp()
    {
        while (ExplosonParticleSystem.isPlaying)
        {
            yield return null;
        }
        Destroy(gameObject);
    }
}
