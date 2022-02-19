using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MLRTS.Unit;

public class Unit : MonoBehaviour {
    
    [SerializeField]
    private UnitData unitData;
    private SpriteRenderer selected;

    private IMovePosition movePosition;
    private IMoveVelocity moveVelocity;


    private void Awake()
    {
        selected = transform.Find("Selected").GetComponent<SpriteRenderer>();
        movePosition = GetComponent<IMovePosition>();
        SetSelectedVisible(false);
    }
    
    public void SetSelectedVisible(bool visible)
    {
        selected.enabled = visible;
    }

    public void MoveTo(Vector3 targetPosition){
        movePosition.Stop(false);
        movePosition.SetMovePosition(targetPosition);
    }

    public void Stop(){
        movePosition.Stop(true);
    }
}