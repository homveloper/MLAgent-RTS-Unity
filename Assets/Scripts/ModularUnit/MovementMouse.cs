using ToToMo.Utiltiy;
using UnityEngine;

[RequireComponent(typeof(IMovePosition))]
public class MovementMouse : MonoBehaviour {
    private void Update() {
        if(Input.GetMouseButtonDown(1))
        {
            GetComponent<IMovePosition>().SetMovePosition(Functional.GetMouseWorldPosition());
        }
    }
}