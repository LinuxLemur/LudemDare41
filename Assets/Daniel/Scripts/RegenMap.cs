using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RegenMap : MonoBehaviour
{

    public MapGenerator mapgen;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.V))
        {
            mapgen.GenerateMap();
        }
    }
}
