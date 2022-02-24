using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Globals : MonoBehaviour
{
    public static Globals Instance = null;

    [SerializeField] public int TERRAIN_LAYER_MASK = 1<<8;
    
    [SerializeField] public List<BuildingData> buildingDataArray;

    private void Awake() {
        if(Instance == null){
            Instance = this;
        }  
        else if(Instance != this){
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);
    }
}