using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MastermindManager : MonoBehaviour
{

    [SerializeField]
    private Material[] _pawnMaterials;
    [SerializeField]
    private Material _goodAnswerMaterials;
    [SerializeField]
    private Material _badAnswerMaterials;

    [SerializeField]
    private Material _mActivePawnColor;

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

    // Start is called before the first frame update
    void Start()
    {
        //_mActivePawnColor.
    }
    public Material[] GetColors ()
    {
        return _pawnMaterials;
    }
    // Update is called once per frame
    void Update()
    {
        
    }

    public void Win()
    {

    }

    public void Loose()
    {

    }
}
