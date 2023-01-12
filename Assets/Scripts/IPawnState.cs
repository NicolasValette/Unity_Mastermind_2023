
using UnityEngine;

public interface IPawnState
{
    public void Move(Transform transform);
    public void Release(Transform transform, Vector3 positionToRelease);
    
}

