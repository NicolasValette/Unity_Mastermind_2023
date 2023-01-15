using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using System;

public class DecoderController : MonoBehaviour
{

    private GameObject PawnToMove = null;
    private bool _canCheck = false;
    // Start is called before the first frame update
    public static Action OnCheckDemand;
    void Start()
    {

    }

    private void OnEnable()
    {
        RowController.OnValid += CanCheck;
        CoderController.OnAnswer += CanCheck;
    }
    private void OnDisable()
    {
        RowController.OnValid -= CanCheck;
        CoderController.OnAnswer -= CanCheck;
    }
    // Update is called once per frame
    void Update()
    {
        if (_canCheck && Input.GetKeyDown(KeyCode.Return))
        {
            OnCheckDemand.Invoke();
        }
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
                    PawnController pawnCont = hit.transform.gameObject.GetComponent<PawnController>();
                    if (pawnCont != null && pawnCont.IsPickable)
                    {
                        PawnToMove = pawnCont.Pick(hit);
                        if (pawnCont.IsSlot)
                        {
                            Destroy(hit.transform.gameObject);
                        }
                    }
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
            PawnToMove = null;
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

    public void CanCheck()
    {
        _canCheck = !_canCheck;
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
