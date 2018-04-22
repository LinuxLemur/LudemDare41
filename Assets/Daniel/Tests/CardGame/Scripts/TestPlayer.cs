using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestPlayer : MonoBehaviour
{
    [SerializeField] private PlayerSystem _playerstats;


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.B))
        {
            _playerstats.Health -= 10;
        }
    }
}