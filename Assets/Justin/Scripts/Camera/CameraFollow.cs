using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Justin
{
	public class CameraFollow : MonoBehaviour
	{
		private Transform _target;
		[Header ("Camera Controls")]
		[SerializeField] private float height;
		[SerializeField] private float distance;
		[SerializeField] private float heightDamping;

		private void Awake ()
		{
			_target = GameObject.FindGameObjectWithTag ("Player").transform;
		}

		private void Update ()
		{
			if (_target)
			{
				float wantedHeight = _target.position.y + height;
				float currentHeight = transform.position.y;

				currentHeight = Mathf.Lerp (currentHeight, wantedHeight, heightDamping * Time.deltaTime);

				Vector3 pos = _target.position;
				pos -= Vector3.forward * distance;
				pos.y = currentHeight;

				Vector3.Lerp (transform.position, pos, Time.deltaTime);
				transform.position = pos;
			}

		
		}
	}
}