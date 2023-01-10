using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class MastermindManager : MonoBehaviour
{
    #region Serialized attributes
    [SerializeField]
    private Material[] _pawnMaterials;
    [SerializeField]
    private Material _goodAnswerMaterials;
    [SerializeField]
    private Material _badAnswerMaterials;

    [SerializeField]
    private Material _mActivePawnColor;
    #endregion

    #region Getters And Setters
    [SerializeField]
    private int _codeLength;
    public int CodeLength 
    {
        get { return _codeLength; }
         
    }
    
    public Material ActivePawnColor
    {
        get { return _mActivePawnColor; }
    }
    public Material GoodColor { get { return _goodAnswerMaterials; } }
    public Material BadColor { get { return _badAnswerMaterials; } }
    
    public Material [] Colors
    {
        get
        {
            return _pawnMaterials;
        }
    }
    public Material[] GetColors()
    {
        return _pawnMaterials;
    }
    #endregion
    #region Events
    public delegate void  StartEvent();
    public static event StartEvent OnStart;
    #endregion
    // Start is called before the first frame update
    void Start()
    {
        //_mActivePawnColor.
    }
    
    // Update is called once per frame
    void Update()
    {
        
    }


    public static void StartMasterMind()
    {
        OnStart?.Invoke();
    }
    public void Win()
    {

    }

    public void Loose()
    {

    }
}
