using System.Collections;
using System.Collections.Generic;
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

    }
    public void OnDisable()
    {
        //_check.onClick.RemoveListener(CheckButton);
        _start.onClick.RemoveListener(StartButton);
        MastermindManager.OnStart -= StartGame;
        RowController.OnValid -= CheckButton;
        CoderController.OnAnswer -= CheckButton;
    }

    // Update is called once per frame
    void Update()
    {
        
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

}
