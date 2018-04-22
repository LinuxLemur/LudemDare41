using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    public delegate void ChangePlayerHealthBar(int playerHealthAmount);
        
    public static event ChangePlayerHealthBar ChangePlayerHealthEvent;

    public static void ChangePlayerHealth(int healthAmount)
    {
        if (ChangePlayerHealthEvent != null) ChangePlayerHealthEvent(healthAmount);
    }
}