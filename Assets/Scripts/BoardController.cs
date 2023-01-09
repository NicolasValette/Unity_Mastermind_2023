using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BoardController : MonoBehaviour
{
    private PawnController[] _code;
    private RowController[] _rows;
    private int _activeRow = 0;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void prepareBoard()
    {
        _code = new PawnController[5];
    }
    private void SetupCode(Color[] colors)
    {

    }
}
