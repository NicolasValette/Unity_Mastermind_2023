using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BoardController : MonoBehaviour
{
    [SerializeField]
    private RowController[] _rows;
    [SerializeField]
    private PawnController[] _code;
    public Material[] Code
    {
        get
        {
            Material[] materials = new Material[_code.Length];
            for (int i= 0;i< _code.Length; i++)
            {
                //materials[i] = _code[i].
            }
            return materials;
        }
    }
    private int _activeRow = -1;



    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            Debug.Log("Activate");
            ActivateNextRow();
        }


    }

    private void prepareBoard()
    {
    }
    public void SetupCode(Material[] colors)
    {
        
        for (int i = 0; i < colors.Length; i++)
        {
            
        }
    }
    public void SetupCode(int[] colors)
    {
        for (int i = 0; i < colors.Length; i++)
        {
            _code[i].ChangeColor(colors[i]);
        }
    }
    public void ActivateNextRow()
    {
        if (_activeRow == -1)                           //The first row of the game
        {
            _rows[++_activeRow].SwitchActive();
        }
        else
        {

            _rows[_activeRow++].SwitchActive();       // then, disable

            _rows[_activeRow].SwitchActive();         // and activate the next row
        }
    }
    public bool VerifyRow (int rowToCheck)
    {

        int nbGoodAnswers = 0;              // the value to return
                                            /////////////////////////////////////////////////////////////////////////////////////////////////////////////// A TEST
        for (int i = 0; i < _gameManager.CodeLength; i++)
        {
            if (_rows[rowToCheck].Pawns[i].color == _goBoard.Code[i].color)
            {
                nbGoodAnswers++;
            }
        }

        return nbGoodAnswers;              // the value to return


        return false;
    }
}
