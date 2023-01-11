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


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SwitchActive()
    {
        for (int i = 0; i < _pawns.Length; i++)
        {
            _pawns[i].setActive(!_pawns[i].IsActive);
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


}
