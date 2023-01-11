using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    private Button _check;
    [SerializeField]
    private Button _start;
    [SerializeField]
    private Image _fadeScreen;
    [SerializeField]
    private TMP_Text _gameOverText;
    [SerializeField]
    private TMP_Text _gameWinText;

    private bool _isGameEnd = false;
    private float _fadeProgress = 0f;
    // Start is called before the first frame update
    void Start()
    {
       
    }
    public void OnEnable()
    {
       // _check.onClick.AddListener(CheckButton);
        _start.onClick.AddListener(StartButton);
        MastermindManager.OnStart += StartGame;
        RowController.OnValid += CheckButton;
        CoderController.OnAnswer += CheckButton;
        MastermindManager.OnGameOver += GameOver;
        MastermindManager.OnGameWin += GameWin;

    }
    public void OnDisable()
    {
        //_check.onClick.RemoveListener(CheckButton);
        _start.onClick.RemoveListener(StartButton);
        MastermindManager.OnStart -= StartGame;
        RowController.OnValid -= CheckButton;
        CoderController.OnAnswer -= CheckButton;
        MastermindManager.OnGameOver -= GameOver;
        MastermindManager.OnGameWin += GameWin;
    }

    // Update is called once per frame
    void Update()
    {
        if (_isGameEnd)
        {
            _fadeProgress += Time.deltaTime;
            Color color = _fadeScreen.color;
            color.a = Mathf.Lerp(0f, 1f, _fadeProgress);
            _fadeScreen.color = color;
        }
    }
   
    public void StartButton()
    {
        MastermindManager.StartMasterMind();
    }
    public void StartGame()
    {
        Debug.Log("UI : Start");
        _start.gameObject.SetActive(false);
        _fadeScreen.enabled = false;
    }
    public void CheckButton()
    {
        Debug.Log("UI ; CheckButton");
        _check.gameObject.SetActive(!_check.gameObject.activeSelf);
    }
    public void GameOver()
    {
        Debug.Log("Perdu");
        _fadeScreen.enabled = true;
        _isGameEnd= true;
        _gameOverText.gameObject.SetActive(true);
    }
    public void GameWin()
    {
        Debug.Log("Perdu");
        _fadeScreen.enabled = true;
        _isGameEnd = true;
        _gameWinText.gameObject.SetActive(true);

    }
}
