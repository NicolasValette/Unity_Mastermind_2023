using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RowController : MonoBehaviour
{
    [SerializeField]
    private PawnController[] _pawns;
    private int _nbCorrectColors = 0;
    private int _nbUncorrectPos;

    public bool IsActive { get; private set; } = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SwitchActive()
    {
        for (int i = 0; i < _pawns.Length; i++)
        {
            _pawns[i].setActive(!_pawns[i].IsActive);
        }
        IsActive = !IsActive;
    }
}
