using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tiles : MonoBehaviour
{

    [SerializeField] public int row, column;
    [SerializeField] public GameObject piece;
    tiles tile;
    ChessGameController cgc;

    // Start is called before the first frame update
    void Start()
    {
        tile = GetComponent<tiles>();
        cgc = FindObjectOfType<ChessGameController>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnMouseDown()
    {
        cgc.SelectTile(row, column);
    }

    internal void changePiece()
    {

    }

}
