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
    ValidMoves validMovesScript = new ValidMoves();
    List<Vector2Int> PiecesPos = new List<Vector2Int>();

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

    internal void movePiece(GameObject pieceToMove, int row, int col)
    {

    }

    internal void SelectTile(int row, int col)
    {
        // get the tile
        selectedTile = ChessBoardHandler.Instance.GetTile(row, col);
        tiles tileScript = selectedTile.GetComponent<tiles>();


        // check if a piece is present on the tile
        if (tileScript.piece != null)
        {

            // check if a piece is already selected
            if(selectedPiece != null)
            {
                // if a piece is already selected, check if the piece on the tile is an enemy piece
                if (checkEnemy(tileScript.piece))
                {
                    // if the piece on the tile is an enemy piece, attack the piece


                }
                else
                {
                    // if the piece on the tile is not an enemy piece, select the piece


                }

            }
            else
            {
                // if a piece is not already selected, select the piece
                SelectPiece(tileScript.piece);
            }

        }
        else
        {
            // if a piece is not present on the tile, check if a piece is already selected

                // if a piece is already selected, move the piece to the tile

                // if a piece is not already selected, do nothing
        }

    }

    internal void SelectPiece(GameObject piece)
    {
        // Creating a list of all the pieces positions
        PlayerPlacementhandler[] pieceScripts = Object.FindObjectsOfType<PlayerPlacementhandler>();
        for (int i = 0; i < pieceScripts.Length; i++)
        {
            PiecesPos.Add(new Vector2Int(pieceScripts[i].row, pieceScripts[i].column));
        }

        Debug.Log(PiecesPos[1]);

        // Getting the valid moves for the piece and highlighting
        selectedPiece = piece;
        PlayerPlacementhandler pieceScript = selectedPiece.GetComponent<PlayerPlacementhandler>();
        
        List<Vector2Int> mov = validMovesScript.getValidMoves(selectedPiece.name, pieceScript.row, pieceScript.column, PiecesPos);

        validMoves = mov;

        Debug.Log(validMoves.Count);
        // highlight the valid moves
        ChessBoardHandler.Instance.ClearHighlights();

        for (int i = 0; i < validMoves.Count; i++)
        {
            ChessBoardHandler.Instance.Highlight(validMoves[i].x, validMoves[i].y);
        }        
    }


    internal void Attack(GameObject PieceToAttack)
    {

    }


    internal bool checkEnemy(GameObject pieceToCheck)
    {
        if (selectedPiece.tag == "white")
        {
            if (pieceToCheck.tag == "black")
            {
                return true;
            }
            return false;
        }
        else
        {
            if (pieceToCheck.tag == "white")
            {
                return true;
            }
            return false;
        }
    }

    internal void clearSelection()
    {
        selectedPiece = null;
        selectedTile = null;
        validMoves = null;
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
