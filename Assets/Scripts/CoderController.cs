using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoderController : MonoBehaviour
{

    [SerializeField]
    private BoardController _goBoard;
    [SerializeField]
    private MastermindManager _gameManager;
    [SerializeField]
    private Button CheckButton;

    public delegate void AnswerEvent();
    public static AnswerEvent OnAnswer;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void OnEnable()
    {
        //BoardController.OnVerify += checkCode;//
        CheckButton.onClick.AddListener(checkCode);
    }
    public void OnDisable()
    {
        //BoardController.OnVerify -= checkCode;
        CheckButton.onClick.RemoveListener(checkCode);
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            Debug.Log("Start (CoderController)");
            _goBoard.SetupCode(ChooseCode(4));
        }
    }
    private int[] ChooseCode(int colorNumber)
    {
        Material[] materials = new Material[colorNumber];
        int[] materialsInd = new int[colorNumber];
        for (int i = 0; i < colorNumber; i++)
        {
            int colorChoose = Random.Range(0, colorNumber);
            materials[i] = _gameManager.Colors[colorChoose];
            materialsInd[i] = colorChoose;
        }
        return materialsInd;
    }
    public void checkCode()
    {
        Debug.Log("Verification de ligne");
        bool[] boolTab = new bool[_gameManager.CodeLength];
        int nbGoodColors = 0;
        int nbBadPos = 0;
        for (int i = 0; i < _gameManager.CodeLength; i++)
        {
            if (_goBoard.ActualRow.Pawns[i].Color.color == _goBoard.Code[i].color)
            {
                nbGoodColors++;
                boolTab[i] = true;
            }
            for (int j = 0; j < _gameManager.CodeLength; j++)
            {
                if (!boolTab[j] && _goBoard.ActualRow.Pawns[j].Color.color == _goBoard.Code[i].color)
                {
                    boolTab[i] = true;
                    nbBadPos++;
                }
            }
        }
        _goBoard.ActualRow.CorrectColors = nbGoodColors;
        _goBoard.ActualRow.UncorrectPos = nbBadPos;
        _goBoard.ActualRow.ChangeCluesColors(_gameManager.GoodColor, _gameManager.BadColor);
        //OnAnswer?.Invoke();
    }
   
}
