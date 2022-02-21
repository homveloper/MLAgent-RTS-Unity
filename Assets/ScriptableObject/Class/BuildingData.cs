using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


[CreateAssetMenu(menuName ="RTS/BuildingData", fileName ="New BuildingData")]
public class BuildingData : ScriptableObject
{
    [SerializeField] private string code;
    [SerializeField] private int health;
    [SerializeField] private GameObject prefab;
    [SerializeField] private Sprite sprite;

    public string Code{get=>code;}
    public int Health{get=>health;}
    public GameObject Building{get=>prefab;}

    public Sprite Sprite{get=>sprite;}
}