using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using ToToMo.Utiltiy;

public class RTSController : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] 
    private Transform selectionArea;
    private Vector3 startPosition;
    private List<Unit> selectedUnitList;

    private BuildingManager buildingManager;

    private void Awake() {
        selectedUnitList = new List<Unit>();
        buildingManager = GetComponent<BuildingManager>();
        SetSelectionAreaActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(buildingManager.BuildingData) return;

        if (Input.GetMouseButtonDown(0)){
            SetSelectionAreaActive(true);
            startPosition = Functional.GetMouseWorldPosition();
        }

        if (Input.GetMouseButton(0))
        {
            Vector3 currentMousePosition = Functional.GetMouseWorldPosition();
            Vector3 lowerLeft = new Vector3(
                                    Mathf.Min(startPosition.x, currentMousePosition.x), 
                                    Mathf.Min(startPosition.y, currentMousePosition.y));
            
            Vector3 upperRight = new Vector3(
                        Mathf.Max(startPosition.x, currentMousePosition.x), 
                        Mathf.Max(startPosition.y, currentMousePosition.y));
                
            selectionArea.position = lowerLeft;
            selectionArea.localScale = upperRight - lowerLeft;
        }

        if (Input.GetMouseButtonUp(0))
        {
            SetSelectionAreaActive(false);
            Collider2D[] collider2Ds = Physics2D.OverlapAreaAll(startPosition, Functional.GetMouseWorldPosition());

            selectedUnitList.ForEach(unit => unit.SetSelectedVisible(false));
            selectedUnitList.Clear();

            foreach(Collider2D collider2D in collider2Ds)
            {
                Unit unit = null;
                bool hasComponent = collider2D.TryGetComponent<Unit>(out unit);
                if(hasComponent)
                {
                    selectedUnitList.Add(unit);
                    unit.SetSelectedVisible(true);
                }
            }
        }

        if(Input.GetMouseButtonDown(1))
        {
            Vector3 moveToPosition = Functional.GetMouseWorldPosition();

            foreach(Unit unit in selectedUnitList)
            {
                unit.MoveTo(moveToPosition);
            }
        }

        Stop();
    }

    private void Stop()
    {
        if(Input.GetKeyDown(KeyCode.S))
        {
            foreach(Unit unit in selectedUnitList)
            {
                // unit.MoveTo(unit.transform.position);
                unit.Stop();
            }
        }
    }

    private void SetSelectionAreaActive(bool active)
    {
        selectionArea.gameObject.SetActive(active);
    }
}
