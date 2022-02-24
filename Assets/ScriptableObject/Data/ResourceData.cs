using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(menuName ="RTS/ResourceData", fileName ="New ResourceData")]
public class ResourceData :ScriptableObject
{
    [SerializeField] private string nameString;
    [SerializeField] private Sprite sprite;
    public string Name{get=>nameString;}
    public Sprite Sprite{get=>sprite;}
}
