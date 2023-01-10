using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    private Button check;
    // Start is called before the first frame update
    void Start()
    {
       
    }
    public void OnEnable()
    {
        check.onClick.AddListener(CheckButton);
    }
    public void OnDisable()
    {
        check.onClick.RemoveListener(CheckButton);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void CheckButton  ()
    {
        Debug.Log("bouton");
    }
}
