using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DecoderController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Ray rayToMouse = Camera.main.ScreenPointToRay(Input.mousePosition);
        Debug.DrawRay(rayToMouse.origin, rayToMouse.direction * 20f, Color.red);
        RaycastHit hit;
        if (Physics.Raycast(rayToMouse, out hit))
        {
            if (hit.transform.gameObject.GetComponent<PawnController>() != null && Input.GetMouseButtonDown(0))
            {
                hit.transform.gameObject.GetComponent<PawnController>().ChangeColor();
            }
        }
    }
}
