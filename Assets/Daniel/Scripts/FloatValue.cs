using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "FloatValue", menuName = "FloatValue")]
public class FloatValue : ScriptableObject
{
    [SerializeField] private float value;
}
