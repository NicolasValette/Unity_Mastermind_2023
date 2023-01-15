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
    private GameObject _mastermindManager;
    [SerializeField]
    private bool _isPickable = false;
    [SerializeField]
    private bool _isPawnSlot = false;
    #endregion

    #region getters and setters
    public bool IsSlot { get { return _isPawnSlot; } }
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
            _isColored = value;

        }
    }
    public Material Color
    {
        get
        {
            return _color.material;
        }
    }
    private bool _isActive;
    public bool IsActive
    {
        get
        {
            return _collider.enabled;
        }
    }
    public string State
    {
        get
        {
            return _state.ToString();
        }
    }
    public bool IsPickable {  get {  return _isPickable; } }
    public int PositionInd { get; set; }
    #endregion

    #region Unity components
    private Collider _collider;
    private MastermindManager _gameManager;
    private MeshRenderer _color;
    #endregion

    public bool stateDrag = false;
    private IPawnState _state;
    private int _actualIndColor = 0;       //Indice of the actual color
    private Vector3 _initialPosition;
    // Start is called before the first frame update
    void Start()
    {
        //_color = GetComponent<MeshRenderer>();
        //_collider = GetComponent<Collider>();
        //if (!_isPickable)
        //{
        //    _collider.enabled = false;
        //}
        //_gameManager = _MastermindManager.GetComponent<MastermindManager>();
        //_state = new NoDraggablePawnState();
    }
    private void OnEnable()
    {
        _color = GetComponent<MeshRenderer>();
        _collider = GetComponent<Collider>();
        if (!_isPickable)
        {
            _collider.enabled = false;
            
        }
        _gameManager = _mastermindManager.GetComponent<MastermindManager>();
        _state = new NoDraggablePawnState();
        _initialPosition = transform.position;
        _isActive = false;
    }
    // Update is called once per frame
    void Update()
    {
        Move();
    }

    public void Initialisation (MastermindManager mastermind)
    {
        _gameManager = mastermind;
    }
    public void ChangeColor()
    {
        _actualIndColor = _actualIndColor >= _gameManager.Colors.Length - 1 ? 0 : _actualIndColor + 1;
        _color.material = _gameManager.Colors[_actualIndColor];
        IsColored = true;
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
    public void SetActive(bool activity)
    {
        _collider.enabled = activity;
        _isActive= activity;
        if (activity)
        {
            _color.material = _gameManager.ActivePawnColor;
        }
    }
    public void SwitchState()
    {
        stateDrag = !stateDrag;
        if (_state is DraggablePawnState)
        {
            _state = new NoDraggablePawnState();
        }
        else
        {
            _state = new DraggablePawnState();
        }
        Debug.Log($"New State {gameObject.name} : {_state}");
    }
    public GameObject DuplicatePawn(Vector3 pos, Quaternion rot)
    {
        GameObject newPawn = Instantiate(gameObject, pos, rot);

        newPawn.GetComponent<PawnController>().Initialisation(_gameManager);
        newPawn.GetComponent<PawnController>().SwitchState();
        return newPawn;
    }
    public GameObject Pick(RaycastHit hit)
    {
       
        Cursor.visible = false;
        GameObject newPawn = DuplicatePawn(Input.mousePosition, Quaternion.identity);
        if (hit.transform.gameObject.GetComponent<PawnController>().IsSlot )
        {
            hit.transform.parent.GetComponent<RowController>().ReactivateSlot(hit.transform.GetComponent<PawnController>().PositionInd);
         
            Destroy(hit.transform.gameObject);
        }
        Debug.Log($"new Pawn instanciate name : {newPawn.name}, state : {newPawn.GetComponent<PawnController>().State}");
        
        //newPawn.GetComponent<PawnController>()._collider.enabled = false;
        newPawn.layer = LayerMask.NameToLayer("Ignore Raycast");
        return newPawn;
    }
    public void Drop()
    {
        RaycastHit hit;
        Ray rayToMouse = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(rayToMouse, out hit))
        { 
            if (hit.transform.gameObject.GetComponent<PawnController>() != null && hit.transform.gameObject.GetComponent<PawnController>()._isPawnSlot)
            {
                Debug.Log("Place");
                hit.transform.gameObject.SetActive(false);
                hit.transform.parent.GetComponent<RowController>()?.ChangePawn(hit.transform.gameObject.GetComponent<PawnController>().PositionInd, transform.gameObject);
                _state.Release(transform, hit.transform.position);
                gameObject.layer = 0;
                _isPawnSlot = true;
            }
            else
            {
                Debug.Log("Drop");
                _state.Release(transform, _initialPosition); 
                Destroy(transform.gameObject);
            }
            SwitchState();
            Cursor.visible = true;
        }
    }
    public void Move()
    {
        //Debug.Log("State Move : " + gameObject.name + " State : " + _state);
        if (stateDrag)
        {
            _state.Move(transform);
        }
    }
}
