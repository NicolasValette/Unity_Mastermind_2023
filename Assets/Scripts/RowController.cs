using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RowController : MonoBehaviour
{
    [SerializeField]
    private PawnController[] _pawns;
    [SerializeField]
    private PawnController[] _clues;
    [SerializeField]
    private MastermindManager _gameManager;
    private int nbColoredPawn = 0;
    public int CorrectColors { get; set; } = 0;
    public int UncorrectPos { get; set; } = 0;
    public bool isValid { get; private set; }

    public bool IsActive { get; private set; } = false;
    public PawnController[] Pawns { get { return _pawns; } }
    public PawnController[] Clues { get { return _clues; } }

    public delegate void ValideRowEvent();
    public static event ValideRowEvent OnValid;

    private bool[] _coloredPawn;
    private PawnController[] _initialPawns;


    // Start is called before the first frame update
    void Start()
    {
        _initialPawns = new PawnController[_pawns.Length];
        _coloredPawn = new bool[_gameManager.CodeLength];
        for (int i = 0; i < _gameManager.CodeLength; i++)
        {
            _initialPawns[i] = _pawns[i];
            _pawns[i].PositionInd = i;
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SwitchActive()
    {
        for (int i = 0; i < _pawns.Length; i++)
        {
            _pawns[i].SetActive(!_pawns[i].IsActive);
        }
        IsActive = !IsActive;
    }
    public void ChangeCluesColors(Material goodColor, Material badColor)
    {
        int i = 0;
        Debug.Log("Clue  : good : " + CorrectColors + " Dab pos : " + UncorrectPos);
        for (i = 0; i < CorrectColors; i++)
        {
            Clues[i].ChangeColor(goodColor);
        }
        for (; i < UncorrectPos + CorrectColors; i++)
        {
            Clues[i].ChangeColor(badColor);
        }
    }
    public void IncrementColoredRow()
    {
        Debug.Log("1");
        nbColoredPawn++;
        if (nbColoredPawn == _gameManager.CodeLength)
        {
            isValid = true;
            OnValid?.Invoke();
        }
    }
    public void ReactivateSlot(int ind)
    {
        _initialPawns[ind].gameObject.SetActive(true);
        _initialPawns[ind].SetActive(true);
        _coloredPawn[ind] = false;
    }
    public void ChangePawn(int place, GameObject pawn)
    {
        _coloredPawn[place] = true;
        pawn.transform.SetParent(transform);
        Pawns[place] = pawn.GetComponent<PawnController>();
        pawn.GetComponent<PawnController>().PositionInd= place;
        int nbColored = 0;
        for (int i=0; i < _gameManager.CodeLength; i++)
        {
            if (_coloredPawn[i])
            {
                nbColored++;
            }
        }
        if (nbColored >= _gameManager.CodeLength && !isValid)
        {
            isValid= true;
            OnValid?.Invoke();
        }
    }


}
