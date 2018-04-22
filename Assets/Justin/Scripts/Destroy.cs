using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy : MonoBehaviour
{
	private GameObject owner;
	[SerializeField] private float selfDestructTime = 3f;

	private void Awake ()
	{
		owner = this.gameObject;
		StartCoroutine(destroySelf());
	}

	IEnumerator destroySelf ()
	{
		yield return new WaitForSeconds(selfDestructTime);
		Destroy(owner);
	}
}