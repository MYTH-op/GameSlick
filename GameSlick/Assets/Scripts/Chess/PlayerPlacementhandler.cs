using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPlacementhandler : MonoBehaviour
{

    [SerializeField] public int row, column;
    PlayerPlacementhandler piece;
    ValidMoves validMoves = new ValidMoves();
    List<Vector2Int> PiecesPos = new List<Vector2Int>();
    ChessGameController cgc;

    private void Awake()
    {
        piece = GetComponent<PlayerPlacementhandler>();
        cgc = FindObjectOfType<ChessGameController>();
    }



    // Start is called before the first frame update
    void Start()
    {
        transform.position = ChessBoardHandler.Instance.GetTile(row, column).transform.position;
        GameObject tile = ChessBoardHandler.Instance.GetTile(row, column);
        tiles tileScript = tile.GetComponent<tiles>();
        tileScript.piece = gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //public void OnMouseDown()
    //{
    //    Debug.Log("clicked Piece");
    //    ChessBoardHandler.Instance.ClearHighlights();
    //    PlayerPlacementhandler[] pieceScripts = Object.FindObjectsOfType<PlayerPlacementhandler>();

    //    // Creating a list of all the pieces positions
    //    for (int i = 0; i < pieceScripts.Length; i++)
    //    {
    //        PiecesPos.Add(new Vector2Int(pieceScripts[i].row, pieceScripts[i].column));
    //    }
    //    //Debug.Log(PiecesPos[1]);
    //    // Getting the valid moves for the piece and highlighting
    //    List<Vector2Int> mov = validMoves.getValidMoves(transform.name, piece.row, piece.column, PiecesPos);
    //    //for (int i = 0; i < mov.Count; i++)
    //    //{
    //    //    ChessBoardHandler.Instance.Highlight(mov[i].x, mov[i].y);
    //    //}

    //    //cgc.SelectPiece(row, column, gameObject, mov);
    //}



}
