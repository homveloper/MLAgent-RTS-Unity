using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ResourceUI : MonoBehaviour
{
    private ResourceDataList resourceDataList;
    private Dictionary<ResourceData, Transform> resourceTransformDict;
    private void Awake()
    {
        resourceTransformDict = new Dictionary<ResourceData, Transform>();
        resourceDataList = Resources.Load<ResourceDataList>(AssetPath.ResourceDataList);
        Transform resourceTemplate = transform.Find("ResourceTemplate");
        resourceTemplate.gameObject.SetActive(false);

        int idx = 0;
        foreach(ResourceData resourceData in resourceDataList.List)
        {
            Transform resourceTransform = Instantiate(resourceTemplate, transform);
            resourceTransform.gameObject.SetActive(true);

            resourceTransformDict[resourceData] = resourceTransform;
            
            float offsetAmount = -60f;
            resourceTransform.GetComponent<RectTransform>().anchoredPosition = new Vector2(offsetAmount * idx -40f, 0 );
            resourceTransform.Find("Image").GetComponent<Image>().sprite = resourceData.Sprite;
            idx++;
        }
    }

    private void Start() {
        ResourceManager.Instance.OnResourceAmountChanged += ResourceManager_OnResourceAmountChanged;
    }

    private void ResourceManager_OnResourceAmountChanged(object sender, System.EventArgs e)
    {
        UpdateResourceAmount();
    }

    private void UpdateResourceAmount()
    {
        foreach(ResourceData resourceData in resourceDataList.List)
        {
            int resourceAmount = ResourceManager.Instance.GetResourceAmount(resourceData);
            resourceTransformDict[resourceData].GetComponentInChildren<TextMeshProUGUI>().SetText(resourceAmount.ToString());
        }
    }
}