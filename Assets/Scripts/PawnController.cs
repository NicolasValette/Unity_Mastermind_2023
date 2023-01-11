using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PawnController : MonoBehaviour
{
    #region Serialized attributes
    //[SerializeField]
    //private Material[] _materials;           //List of all possible colors
    [SerializeField]
    private GameObject _MastermindManager;
    [SerializeField]
    private bool _isPickable = false;
    #endregion
 
    #region getters and setters
    private bool _isColored;
    public bool IsColored
    {
        get { return _isColored; }
        private set
        {
            if (!_isColored)
            {
                gameObject.transform.parent.gameObject.GetComponent<RowController>()?.IncrementColoredRow();
            }
            _isColored= value;
            
        }
    }
    public Material Color
    {
        get
        {
            return _color.material;
        }
    }
    public bool IsActive
    {
        get
        {
            return _collider.enabled;
        }
    }
    #endregion

    #region Unity components
    private Collider _collider;  
    private MastermindManager _gameManager;
    private MeshRenderer _color;
    #endregion

    private IPawnState state;
    private int _actualIndColor = 0;       //Indice of the actual color
    // Start is called before the first frame update
    void Start()
    {
        _color = GetComponent<MeshRenderer>();
        _collider = GetComponent<Collider>();
        if (!_isPickable)
        {
            _collider.enabled = false;
        }
        _gameManager = _MastermindManager.GetComponent<MastermindManager>();
        state = new NoDraggablePawnState();
    }
    // Update is called once per frame
    void Update()
    {
        Move();
    }

    public void ChangeColor()
    {
        _actualIndColor = _actualIndColor >= _gameManager.Colors.Length - 1 ? 0 : _actualIndColor + 1;
        _color.material = _gameManager.Colors[_actualIndColor];
        
        IsColored= true;
    }
    public void ChangeColor(Material color)
    {
        _color.material = color;
        IsColored = true;
    }
    public void ChangeColor(int colorInd)
    {
        _actualIndColor = colorInd;
        _color.material = _gameManager.Colors[_actualIndColor];
        IsColored = true;
    }
    public void setActive(bool activity)
    {
        _collider.enabled = activity;
        if (activity)
        {
            _color.material = _gameManager.ActivePawnColor;
        }
    }
    public void SwitchState()
    {
        if (state is DraggablePawnState)
        {
            state = new NoDraggablePawnState();
        }
        else
        {
            state = new DraggablePawnState();
        }
        Debug.Log("New State : " + state.ToString());
    }
    public GameObject Pick(RaycastHit hit)
    {
        SwitchState();
        Cursor.visible = false;
        return Instantiate(hit.transform.gameObject, Input.mousePosition, Quaternion.identity);
    }

    public void Move()
    {
        state.Move(transform);
    }
}
