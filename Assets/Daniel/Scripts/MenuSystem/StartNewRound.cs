using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartNewRound : MonoBehaviour
{
    [SerializeField] private WaveSpawner WaveSpawner;
    [SerializeField] private CardManager cardmanager;
    
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            WaveSpawner.gameObject.SetActive(true);
            cardmanager.ResetDeck();
            this.gameObject.SetActive(false);
        }
    }
}
