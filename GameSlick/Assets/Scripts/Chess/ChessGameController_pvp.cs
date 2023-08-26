using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ChessGameController : MonoBehaviour
{

    [SerializeField] private GameObject[] pieces;

    public TextMeshProUGUI whiteTurnText, blackTurnText;

    private bool isWhiteTurn;

    
    public GameObject selectedPiece;
    public GameObject selectedTile;

    public List<Vector2Int> validMoves;


    // Start is called before the first frame update
    void Start()
    {
        isWhiteTurn = true;
    }

    // Update is called once per frame
    void Update()
    {
        whiteTurnText.enabled = true;

    }

    internal void movePiece()
    {

    }

    internal void SelectTile(int row, int col)
    {
        selectedTile = ChessBoardHandler.Instance.GetTile(row, col);
    }

    internal void SelectPiece(int row, int col, GameObject piece, List<Vector2Int> valMoves)
    {
        if (selectedPiece == null)
        {
            selectedPiece = piece;
            validMoves = valMoves;
        }
        else
        {
            if(selectedPiece == piece)
            {
                selectedPiece = null;
                validMoves = null;
            }
            else if (isAttack(selectedPiece, piece))
            {

                // has a bug test it before fixing it
                Destroy(piece);
                selectedPiece.transform.position = ChessBoardHandler.Instance.GetTile(row, col).transform.position;
                ChessBoardHandler.Instance.GetTile(row, col).GetComponent<tiles>().piece = selectedPiece;
            }
        }

    }


    private bool isAttack(GameObject selectedPiece, GameObject nextPiece)
    {
        return true;
    }

    private bool isPieceOnTile(int row, int col, List<Vector2Int> piecesPos)
    {
        if(piecesPos.Contains(new Vector2Int(row, col)))
        {
            return true;
        }
        return false;
    }

}
