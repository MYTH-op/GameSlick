using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

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

    internal void movePiece(GameObject pieceToMove, int rowToMove, int colToMove)
    {
        Debug.Log($"Piece moved to {rowToMove}, {colToMove}");
        // get the current tile of the piece
        GameObject currentTile = ChessBoardHandler.Instance.GetTile(pieceToMove.GetComponent<PlayerPlacementhandler>().row, pieceToMove.GetComponent<PlayerPlacementhandler>().column);
        tiles currentTileScript = currentTile.GetComponent<tiles>();

        // get the tile to move to
        GameObject tileToMove = ChessBoardHandler.Instance.GetTile(rowToMove, colToMove);
        tiles tileToMoveScript = tileToMove.GetComponent<tiles>();

        // move the piece to the tile
        pieceToMove.GetComponent<PlayerPlacementhandler>().row = rowToMove;
        pieceToMove.GetComponent<PlayerPlacementhandler>().column = colToMove;
        pieceToMove.transform.position = tileToMove.transform.position;
        currentTileScript.piece = null;
        tileToMoveScript.piece = pieceToMove;
        clearSelection();

    }

    internal void SelectTile(int row, int col)
    {
        // clear any highlights on the board
        ChessBoardHandler.Instance.ClearHighlights();

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
                    // if the piece on the tile is an enemy piece
                        // check if the attack move is in valid moves
                        
                        // if the attack move is in valid moves, attack the piece
                        
                        // if the attack move is not in valid moves, do nothing


                }
                else
                {
                    // if the piece on the tile is not an enemy piece, select the piece
                    SelectPiece(tileScript.piece);

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
            if (selectedPiece != null)
            {
                // if a piece is already selected, move the piece to the tile
                PlayerPlacementhandler pieceScript = selectedPiece.GetComponent<PlayerPlacementhandler>();
                List<Vector2Int> mov = validMovesScript.getValidMoves(selectedPiece.name, pieceScript.row, pieceScript.column, PiecesPos);
                if (mov.Count > 0)
                {
                    Debug.Log("Ready to move the piece");
                    if (mov.Contains(new Vector2Int(row, col)))
                    {
                        Debug.Log($"Moving piece to {row}, {col}");
                        // if the move is valid, move the piece
                        movePiece(selectedPiece, row, col);
                    }
                    else
                    {
                        // if the move is not valid, do nothing
                        // clear the selection
                        clearSelection();
                    }
                }
                else
                {
                    clearSelection();
                }
            }
            else
            {
                // if a piece is not already selected, do nothing
            }
        }

    }

    internal void SelectPiece(GameObject piece)
    {
        // Getting a list of all the pieces positions
        PiecesPos = getPiecePositions();

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

    internal List<Vector2Int> getPiecePositions()
    {
        List<Vector2Int> piecePositions = new List<Vector2Int>();
        PlayerPlacementhandler[] pieceScripts = Object.FindObjectsOfType<PlayerPlacementhandler>();
        for (int i = 0; i < pieceScripts.Length; i++)
        {
            piecePositions.Add(new Vector2Int(pieceScripts[i].row, pieceScripts[i].column));
        }
        return piecePositions;
    }


    internal void Attack(GameObject PieceToAttack)
    {
        PlayerPlacementhandler pieceToAttackScript = PieceToAttack.GetComponent<PlayerPlacementhandler>();
        selectedPiece.GetComponent<PlayerPlacementhandler>().row = pieceToAttackScript.row;
        selectedPiece.GetComponent<PlayerPlacementhandler>().column = pieceToAttackScript.column;
        selectedPiece.transform.position = PieceToAttack.transform.position;
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



    public void Exit()
    {
        SceneManager.LoadScene("MainScene");
    }

}
