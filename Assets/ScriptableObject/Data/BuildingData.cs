using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


[CreateAssetMenu(menuName ="RTS/BuildingData", fileName ="New BuildingData")]
public class BuildingData : ScriptableObject
{
    [SerializeField] private int health;
    [SerializeField] private GameObject prefab;
    [SerializeField] private Sprite sprite;
    [SerializeField] private ResourceGeneratorData resourceGeneratorData;
    public int Health{get=>health;}
    public GameObject Building{get=>prefab;}
    public Sprite Sprite{get=>sprite;}
    public ResourceGeneratorData ResourceGeneratorData{get=>resourceGeneratorData;}
}