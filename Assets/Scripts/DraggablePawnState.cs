using UnityEngine;
using UnityEngine.UI;

public class DraggablePawnState : IPawnState
{
    public void Move(Transform transformToMove)
    {
        Debug.Log("Move");
        Ray rayToMouse = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(rayToMouse, out hit))
        {
           // Vector3 vect = new Vector3(hit.point.x, 0.015f, hit.point.y); 
            Vector3 vect = new Vector3(hit.point.x, hit.point.y, hit.point.z);
            Debug.Log("Hit : " + Input.mousePosition);
            transformToMove.position = vect;
        }
    }
}
