using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChessBoardHandler : MonoBehaviour
{

    [SerializeField] private GameObject[] _rowsArray;
    [SerializeField] private GameObject _hightligther;

    private GameObject[,] _chessBoard;

    internal static ChessBoardHandler Instance;

    private void Awake()
    {
        Instance = this;
        GenerateArray();
    }

    

    // Start is called before the first frame update
    void Start()
    {
        //Highlight(3, 1);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void GenerateArray()
    {
        _chessBoard = new GameObject[8, 8];
        for (var i = 0; i < 8; i++)
        {
            for (var j = 0; j < 8; j++)
            {
                _chessBoard[i, j] = _rowsArray[i].transform.GetChild(j).gameObject;
            }
        }
    }

    internal GameObject GetTile(int i, int j)
    {
        try
        {
            return _chessBoard[i, j];
        }catch(Exception)
        {
            Debug.Log($"Invalid row or column row: {i} ,column: {j}");
            return null;
        }
    }

    internal void Highlight(int row, int col)
    {
        var tile = GetTile(row, col);
        if(tile != null)
        {
            Instantiate(_hightligther, tile.transform.position, Quaternion.identity, tile.transform);
        }
        else
        {
            Debug.Log($"Invalid row or column row: {row} ,column: {col}");
            return;
        }
    }

    internal void ClearHighlights()
    {
        for(var i = 0; i < 8; i++)
        {
            for(var j = 0; j < 8; j++)
            {
                var tile = GetTile(i, j);
                if(tile.transform.childCount > 0)
                {
                    foreach(Transform childTransform in tile.transform)
                    {
                        if(childTransform.gameObject.CompareTag("Highlight"))
                        {
                            Destroy(childTransform.gameObject);
                        }
                    }
                }
            }
        }
    }


}
