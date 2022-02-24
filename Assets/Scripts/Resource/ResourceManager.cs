using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceManager : MonoBehaviour
{
    public static ResourceManager Instance {get; private set;}
    private Dictionary<ResourceData, int> resourceAmountDict;

    public event EventHandler OnResourceAmountChanged;

    private void Awake() {

        if(Instance == null)
        {
            Instance = this;
        }

        resourceAmountDict = new Dictionary<ResourceData, int>();
        ResourceDataList resourceDataList = Resources.Load<ResourceDataList>(AssetPath.ResourceDataList);

        foreach(ResourceData resourceData in resourceDataList.List)
        {
            resourceAmountDict[resourceData] = 0;
        }

        TestLogResourceAmount();
    }

    private void Update() {
        TestAmountChange();
    }

    private void TestAmountChange()
    {
        if(Input.GetKeyDown(KeyCode.R))
        {
            ResourceDataList resourceDataList = Resources.Load<ResourceDataList>(AssetPath.ResourceDataList);
            TestLogResourceAmount();
        }
    }

    internal int GetResourceAmount(ResourceData resourceData)
    {
        return resourceAmountDict[resourceData];
    }

    private void TestLogResourceAmount(){
        foreach(ResourceData resourceData in resourceAmountDict.Keys){
            Debug.Log(resourceData.name + ": " + resourceAmountDict[resourceData]);
        }
    }

    public void AddResource(ResourceData  resourceData, int amount)
    {
        resourceAmountDict[resourceData] += amount;
        OnResourceAmountChanged?.Invoke(this, EventArgs.Empty);
    }
}