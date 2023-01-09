using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MastermindManager : MonoBehaviour
{

    [SerializeField]
    private Material[] _materials;

    [SerializeField]
    private Material _mActivePawnColor;

    
    
    public Material [] Colors
    {
        get
        {
            return _materials;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
    }
    public Material[] GetColors ()
    {
        return _materials;
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
