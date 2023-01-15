using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoderController : MonoBehaviour
{
    #region Serialized Attributes
    [SerializeField]
    private BoardController _goBoard;
    [SerializeField]
    private MastermindManager _gameManager;
    [SerializeField]
    private Button CheckButton;

    #endregion

    #region Events
    public delegate void AnswerEvent();
    public static event AnswerEvent OnAnswer;
    #endregion
    // Start is called before the first frame update
    void Start()
    {

    }
    public void OnEnable()
    {
        //BoardController.OnVerify += checkCode;//
        CheckButton.onClick.AddListener(CheckCode);
        MastermindManager.OnStart += StartGame;
        DecoderController.OnCheckDemand += CheckCode;
    }
    public void OnDisable()
    {
        //BoardController.OnVerify -= checkCode;
        CheckButton.onClick.RemoveListener(CheckCode);
        MastermindManager.OnStart -= StartGame;
        DecoderController.OnCheckDemand -= CheckCode;
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            Debug.Log("Start (CoderController)");
            _goBoard.SetupCode(ChooseCode());
        }
    }
    public void StartGame()
    {
        Debug.Log("Coder ; Start");
        _goBoard.SetupCode(ChooseCode());
    }
    private int[] ChooseCode()
    {

        Material[] materials = new Material[_gameManager.CodeLength];
        int[] materialsInd = new int[_gameManager.CodeLength];
        for (int i = 0; i < _gameManager.CodeLength; i++)
        {
            int colorChoose = Random.Range(0, _gameManager.CodeLength);
            materials[i] = _gameManager.Colors[colorChoose];
            materialsInd[i] = colorChoose;
        }

        return materialsInd;
    }
    private int[] triche()
    {
        Material[] materials = new Material[_gameManager.CodeLength];
        int[] materialsInd = new int[_gameManager.CodeLength];
        for (int i = 0; i < 4; i++)
        {

            materials[i] = _gameManager.Colors[i];
            materialsInd[i] = i;
        }
        return materialsInd;
    }
    public void CheckCode()
    {
        Debug.Log("Verification de ligne");
        bool[] goodColors = new bool[_gameManager.CodeLength];
        bool[] WrongPlacement = new bool[_gameManager.CodeLength];
        int nbGoodColors = 0;
        int nbBadPos = 0;
        for (int i = 0; i < _gameManager.CodeLength; i++)                               //Verification of good colors & positions
        {
            if (_goBoard.ActualRow.Pawns[i].Color.color == _goBoard.Code[i].color)
            {
                nbGoodColors++;
                goodColors[i] = true;
            }
        }
        if (nbGoodColors >= _gameManager.CodeLength)
        {
            _gameManager.Win();
        }
        else
        {
            for (int i = 0; i < _gameManager.CodeLength; i++) // on parcourt le code du joueur
            {
                if (!goodColors[i])
                {

                    for (int j = 0; j < _gameManager.CodeLength; j++) //on parcours le code a deviner
                    {
                        if (_goBoard.ActualRow.Pawns[i].Color.color == _goBoard.Code[j].color && !WrongPlacement[j] && !goodColors[j])
                        {
                            nbBadPos++;
                            WrongPlacement[j] = true;
                            break;
                        }
                    }
                }
            }
            _goBoard.ActualRow.CorrectColors = nbGoodColors;
            _goBoard.ActualRow.UncorrectPos = nbBadPos;
            _goBoard.ActualRow.ChangeCluesColors(_gameManager.GoodColor, _gameManager.BadColor);
            OnAnswer?.Invoke();
        }
    }
}
