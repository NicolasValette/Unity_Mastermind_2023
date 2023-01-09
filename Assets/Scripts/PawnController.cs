using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PawnController : MonoBehaviour
{
    [SerializeField]
    private Material[] _materials;           //List of all possible colors

    private MeshRenderer _color;
    private int _actualIndColor = 0;       //Indice of the actual color
    // Start is called before the first frame update
    void Start()
    {
        _color= GetComponent<MeshRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            ChangeColor();
        }
        
    }

    public void ChangeColor()
    {
        _actualIndColor = _actualIndColor >= _materials.Length -1 ? 0 : _actualIndColor +1;
        _color.material = _materials[_actualIndColor];
    }
}
