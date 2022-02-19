using UnityEngine;

public interface IMovePosition
{
    public void SetMovePosition(Vector3 movePosition);
    public void Stop(bool isStopped);
}