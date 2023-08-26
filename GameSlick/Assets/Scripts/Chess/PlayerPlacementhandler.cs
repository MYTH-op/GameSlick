using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPlacementhandler : MonoBehaviour
{

    [SerializeField] public int row, column;


    // Start is called before the first frame update
    void Start()
    {
        transform.position = ChessBoardHandler.Instance.GetTile(row, column).transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }



}
