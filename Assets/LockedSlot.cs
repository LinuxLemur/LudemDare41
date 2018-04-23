using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockedSlot : MonoBehaviour
{
	public bool isslotlocked = false;

	public void slotlocked ()
	{
		Debug.Log("Locked");
		isslotlocked = true;
	}
}