using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New ResourceDataList", menuName = "RTS/ResourceDataList")]
public class ResourceDataList : ScriptableObject {
    [SerializeField] private List<ResourceData> list;
    public List<ResourceData> List{get=>list;}
}