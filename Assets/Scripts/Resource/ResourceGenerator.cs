using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceGenerator : MonoBehaviour
{
    [SerializeField] private float duration;
    private float currentTime;
    private BuildingData buildingData;

    private void Awake()
    {
        buildingData = GetComponent<BuildingDataHolder>().buildingData;
        duration = buildingData.ResourceGeneratorData.duration;
        currentTime = duration;
    }

    private void Update()
    { 
        currentTime -= Time.deltaTime;

        if (currentTime <= 0f)
        {
            currentTime = duration;
            TestMsg();
            ResourceManager.Instance.AddResource(buildingData.ResourceGeneratorData.resourceData, 1);
        }
    }

    private void TestMsg()
    {
        Debug.Log("Do it" + buildingData.ResourceGeneratorData.resourceData.Name);
    }
}
