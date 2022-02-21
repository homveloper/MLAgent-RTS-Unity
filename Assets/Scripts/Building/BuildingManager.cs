using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using ToToMo.Utiltiy;

public class BuildingManager : MonoBehaviour
{
    [SerializeField] private BuildingData buildingData; 

    private void Update() {
        if(Input.GetMouseButtonDown(0) && !EventSystem.current.IsPointerOverGameObject()){
            Vector3 mousePosition = Functional.GetMouseWorldPosition();
            if(IsValidBuildPosition(buildingData, mousePosition)){
                Instantiate(buildingData.Building, mousePosition, Quaternion.identity);
            }
        }
    }

    public BuildingData BuildingData
    {
        set=>buildingData = value;
        get=>buildingData;
    }

    private bool IsValidBuildPosition(BuildingData buildingData, Vector3 position){
        BoxCollider2D boxCollider2D = buildingData.Building.GetComponent<BoxCollider2D>();
        return Physics2D.OverlapBox(position + (Vector3)boxCollider2D.offset, boxCollider2D.size, 0) == null;
    }
}