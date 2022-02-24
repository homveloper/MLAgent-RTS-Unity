using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New BuildingDataList", menuName = "RTS/BuildingDataList")]
public class BuildingDataList : ScriptableObject {
    [SerializeField] private List<BuildingData> list;

    public List<BuildingData> List{get=>list;}
}