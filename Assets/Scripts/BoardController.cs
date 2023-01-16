using System;
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
    [SerializeField]
    private MastermindManager _gameManager;
    [SerializeField]
    private Transform _playablePawnStack;
    [SerializeField]
    private Transform _buttonCheckPos;

    private int _activeRow = -1;

    public delegate void VerifyEvent();
    public static VerifyEvent OnVerify;
    public static Action<Vector3> OnButtonReplace;
    public Material[] Code
    {
        get
        {
            Material[] materials = new Material[_code.Length];
            for (int i = 0; i < _code.Length; i++)
            {
                materials[i] = _code[i].Color;
            }
            return materials;
        }
    }
    public RowController ActualRow { get { return _rows[_activeRow]; } }


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
    private void OnEnable()
    {
        MastermindManager.OnStart += ActivateNextRow;
        CoderController.OnAnswer += ActivateNextRow;
    }
    private void OnDisable()
    {
        MastermindManager.OnStart -= ActivateNextRow;
        CoderController.OnAnswer -= ActivateNextRow;
    }


    private void PrepareBoard()
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
        if (!_gameManager.IsGameEnd)
        {
            Debug.Log("Activate = " + _activeRow);
            if (_activeRow >= _gameManager.Try - 1)
            {
                _gameManager.Loose();
            }
            else
            {
                if (_activeRow == -1)                           //The first row of the game
                {
                    _activeRow++;
                    _rows[_activeRow].SwitchActive();
                }
                else
                {
                    _rows[_activeRow].SwitchActive();       // then, disable
                    _activeRow++;
                    _rows[_activeRow].SwitchActive();         // and activate the next row
                }
            }
            _playablePawnStack.position = new Vector3(_playablePawnStack.position.x, _playablePawnStack.position.y, _rows[_activeRow].gameObject.transform.position.z);
            _buttonCheckPos.position = new Vector3(_buttonCheckPos.position.x, _buttonCheckPos.position.y, _rows[_activeRow].gameObject.transform.position.z + 0.02f);
            OnButtonReplace?.Invoke(_buttonCheckPos.position);
        }
    }
    public bool IsColorInCode(Material color)
    {
        for (int i = 0; i < _code.Length; i++)
        {
            if (true) { }
        }
        return true;
    }
    //public bool VerifyRow (int rowToCheck)
    //{

    //int nbGoodAnswers = 0;              // the value to return
    //                                    /////////////////////////////////////////////////////////////////////////////////////////////////////////////// A TEST
    //for (int i = 0; i < _gameManager.CodeLength; i++)
    //{
    //    if (_rows[rowToCheck].Pawns[i].color == _goBoard.Code[i].color)
    //    {
    //        nbGoodAnswers++;
    //    }
    //}
    //// return nbGoodAnswers;              // the value to return
    //return true;
    //}
}
