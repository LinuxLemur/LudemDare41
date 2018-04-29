using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnOnEnter : MonoBehaviour
{
	[SerializeField] private GameObject DesignatedObject;
	[SerializeField] private int respawnHeight;
	private string _name;

	private void Awake ()
	{
		_name = DesignatedObject.tag;
	}

	private void OnTriggerEnter (Collider other)
	{
		if (other.gameObject.CompareTag (_name))
		{
			RespawnObject ();
		}
	}

	private void RespawnObject ()
	{
		DesignatedObject.transform.position = new Vector3 (0, respawnHeight, 0);
	}
}