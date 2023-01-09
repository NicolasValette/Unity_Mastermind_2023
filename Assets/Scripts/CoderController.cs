using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoderController : MonoBehaviour
{

    [SerializeField]
    private BoardController _goBoard;
    [SerializeField]
    private MastermindManager _gameManager;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            Debug.Log("Start (CoderController)");
            _goBoard.SetupCode(ChooseCode(4));
        }
    }
    private int[] ChooseCode(int colorNumber)
    {
        Material[] materials = new Material[colorNumber];
        int[] materialsInd = new int[colorNumber];
        for (int i = 0; i < colorNumber; i++)
        {
            int colorChoose = Random.Range(0, colorNumber);
            materials[i] = _gameManager.Colors[colorChoose];
            materialsInd[i] = colorChoose;
        }
        return materialsInd;
    }

}
