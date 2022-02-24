using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuildingSelectUI : MonoBehaviour
{
    [SerializeField] private BuildingManager buildingManager;
    private BuildingDataList buildingDataList;
    
    private Dictionary<BuildingData, Transform> buildingButtonDict;

    private void Awake() {
        Transform button_buildingTemplate = transform.Find("Button_BuildingTemplate");
        button_buildingTemplate.gameObject.SetActive(false);

        buildingButtonDict = new Dictionary<BuildingData, Transform>();

        buildingDataList = Resources.Load<BuildingDataList>(AssetPath.BuildingDataList);

        int idx = 0;
        foreach(BuildingData buildingData in buildingDataList.List)
       {
            Transform button_buildingTransform = Instantiate(button_buildingTemplate, transform);
            button_buildingTransform.gameObject.SetActive(true);

            button_buildingTransform.GetComponent<RectTransform>().anchoredPosition = new Vector2(60 + idx * 80, 60);
            button_buildingTransform.Find("Image").GetComponent<Image>().sprite = buildingData.Sprite;

            button_buildingTransform.GetComponent<Button>().onClick.AddListener(()=>{
                buildingManager.BuildingData = buildingData;
                UpdateSelected();
            });

            buildingButtonDict[buildingData] = button_buildingTransform;
            idx++;
        }
    }

    private void Start() {
        UpdateSelected();
    }

    private void UpdateSelected()
    {
        foreach(BuildingData buildingData in buildingButtonDict.Keys){
            buildingButtonDict[buildingData].Find("Selected").gameObject.SetActive(false);
        }

        BuildingData activeBuilding = buildingManager.BuildingData;
        buildingButtonDict[activeBuilding].Find("Selected").gameObject.SetActive(true);
    }
}
