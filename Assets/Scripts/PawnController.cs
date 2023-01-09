using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PawnController : MonoBehaviour
{
    //[SerializeField]
    //private Material[] _materials;           //List of all possible colors
    [SerializeField] 
    private GameObject _MastermindManager;

    private MastermindManager _gameManager;
    private MeshRenderer _color;
    private Collider _collider;
    private int _actualIndColor = 0;       //Indice of the actual color

    public bool IsActive
    {
        get
        {
            return _collider.enabled;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        _color= GetComponent<MeshRenderer>();
        _collider = GetComponent<Collider>();
        _collider.enabled = false;
        _gameManager = _MastermindManager.GetComponent<MastermindManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeColor()
    {
        _actualIndColor = _actualIndColor >= _gameManager.Colors.Length -1 ? 0 : _actualIndColor +1;
        _color.material = _gameManager.Colors[_actualIndColor];
        Debug.Log("Couleur = " + _gameManager.Colors[_actualIndColor].color.ToString());
        Debug.Log("Couleur = " + _color.material.color.ToString());
    }
    public void ChangeColor(Material color)
    {
        //todo
    }
    public void ChangeColor(int colorInd)
    {
        _actualIndColor = colorInd;
        _color.material = _gameManager.Colors[_actualIndColor];
    }
    public void setActive(bool activity)
    {
        _collider.enabled = activity;
        if (activity)
        {
            _color.material = _gameManager.ActivePawnColor;
        }
    }

}
