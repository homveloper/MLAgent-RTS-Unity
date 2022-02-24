using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuildingSelectUI : MonoBehaviour
{

    // 마우스 스프라이트 및 버튼
    [SerializeField] private Sprite cursorSprite;
    private Transform cursorButton;

    [SerializeField] private BuildingManager buildingManager;
    private BuildingDataList buildingDataList;
    private Dictionary<BuildingData, Transform> buildingButtonDict;

    private void Awake() {
        Transform button_buildingTemplate = transform.Find("Button_BuildingTemplate");
        button_buildingTemplate.gameObject.SetActive(false);
        buildingButtonDict = new Dictionary<BuildingData, Transform>();
        buildingDataList = Resources.Load<BuildingDataList>(AssetPath.BuildingDataList);


        // 마우스 버튼 추가
        int idx = 0;
        cursorButton = Instantiate(button_buildingTemplate, transform);
        cursorButton.gameObject.SetActive(true);

        cursorButton.GetComponent<RectTransform>().anchoredPosition = new Vector2(60 + idx * 80, 60);
        cursorButton.Find("Image").GetComponent<Image>().sprite = cursorSprite;

        cursorButton.GetComponent<Button>().onClick.AddListener(()=>{
            buildingManager.BuildingData = null;
            UpdateSelected();
        });

        // 건물 버튼 추가
        idx++;
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
        // Building Select 버튼 하이라이트 비활성화
        cursorButton.Find("Selected").gameObject.SetActive(false);
        foreach(BuildingData buildingData in buildingButtonDict.Keys){
            buildingButtonDict[buildingData].Find("Selected").gameObject.SetActive(false);
        }

        // Building Select 버튼 하이라이트 활성화
        BuildingData activeBuilding = buildingManager.BuildingData;
        if(activeBuilding != null)
            buildingButtonDict[activeBuilding].Find("Selected").gameObject.SetActive(true);
        else{
            cursorButton.Find("Selected").gameObject.SetActive(true);
        }
    }
}
