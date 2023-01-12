using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DecoderController : MonoBehaviour
{

    private GameObject PawnToMove = null;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //drag & drop

        if (Input.GetMouseButtonDown(0))
        {
            Ray rayToMouse = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(rayToMouse, out hit))
            {
                Debug.Log("Raycast");
                if (PawnToMove == null)
                {
                    PawnToMove = hit.transform.gameObject.GetComponent<PawnController>()?.Pick(hit);
                }
            }
        }
        else if (Input.GetMouseButtonUp(0) && PawnToMove != null)
        {
            Debug.Log("ButtonUp");
            //Ray rayToMouse = Camera.main.ScreenPointToRay(Input.mousePosition);
            //RaycastHit hit;
            //if (Physics.Raycast(rayToMouse, out hit))
            //{
            //    Debug.Log("Drop");
            //    if (PawnToMove != null)
            //    {
            //        PawnToMove.GetComponent<PawnController>().Drop();
            //    }
            //}

            PawnToMove.GetComponent<PawnController>().Drop();
        }



        //Change color on click
        //Ray rayToMouse = Camera.main.ScreenPointToRay(Input.mousePosition);
        //Debug.DrawRay(rayToMouse.origin, rayToMouse.direction * 20f, Color.red);
        //RaycastHit hit;
        //if (Physics.Raycast(rayToMouse, out hit))
        //{
        //    if (hit.transform.gameObject.GetComponent<PawnController>() != null && Input.GetMouseButtonDown(0))
        //    {
        //        hit.transform.gameObject.GetComponent<PawnController>().ChangeColor();
        //    }
        //}
    }

    public bool SelectPawnToPlace(RaycastHit hit)
    {
       
        if (hit.transform.gameObject.GetComponent<PawnController>() != null && Input.GetMouseButtonDown(0))
        {
            Debug.Log("Click");
            Cursor.visible = false;
            PawnToMove = Instantiate(hit.transform.gameObject, Input.mousePosition, Quaternion.identity);
            return true;
        }
        return false;
    }
}
