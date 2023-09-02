using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ValidMoves
{
    public List<Vector2Int> getValidMoves(string type, int row, int col, List<Vector2Int> piecesPos)
    {
        List<Vector2Int> validMoves = new List<Vector2Int>();
        Vector2Int currentPos = new Vector2Int(row, col);

        // check for the type of piece and get the valid moves
        switch (type)
        {
            case "Pawn_b":
                validMoves = ValidMovesForPawn(new Vector2Int(row, col), piecesPos,true);
                break;

            case "Pawn_w":
                validMoves = ValidMovesForPawn(new Vector2Int(row, col), piecesPos, false);
                break;

            case "rook_w":
            case "rook_b":
                validMoves = ValidMovesForRook(new Vector2Int(row, col), piecesPos);
                break;

            case "knight_w":
            case "knight_b":
                validMoves = ValidMovesForKnight(new Vector2Int(row, col), piecesPos);
                break;

            case "bishop_b":
            case "bishop_w":
                validMoves = ValidMovesForBishop(new Vector2Int(row, col), piecesPos);
                break;

            case "queen_w":
            case "queen_b":
                List<Vector2Int> rookMoves = ValidMovesForRook(new Vector2Int(row, col), piecesPos);
                List<Vector2Int> bishopMoves = ValidMovesForBishop(new Vector2Int(row, col), piecesPos);
                validMoves.AddRange(rookMoves);
                validMoves.AddRange(bishopMoves);
                break;

            case "king_b":
            case "king_w":
                validMoves = ValidMovesForKing(new Vector2Int(row, col), piecesPos);
                break;
        }


        return validMoves;
    }

    private List<Vector2Int> ValidMovesForPawn(Vector2Int currentPos, List<Vector2Int> piecesPos, bool black)
    {
        List<Vector2Int> validMoves = new List<Vector2Int>();
        List<Vector2Int> moves = new List<Vector2Int>();


        // add all the possible moves for pawn
        if (black)
        {

        //    List<Vector2Int> possibleMoves = new List<Vector2Int>
        //    {
        //        new Vector2Int(currentPos.x + 1, currentPos.y),
        //        new Vector2Int(currentPos.x + 2, currentPos.y),
        //        new Vector2Int(currentPos.x + 1, currentPos.y - 1),
        //        new Vector2Int(currentPos.x + 1, currentPos.y + 1),
        //};


            Vector2Int oneForward = new Vector2Int(currentPos.x + 1, currentPos.y);
            if (inBoundaries(oneForward) && !checkForFriendlyPieceOnMoves(oneForward, piecesPos) && !checkForEnemyPieceOnMoves(oneForward, piecesPos))
            {
                moves.Add(oneForward);
                Vector2Int twoForward = new Vector2Int(currentPos.x + 2, currentPos.y);
                if (inStartingPos(currentPos))
                {
                    if (inBoundaries(twoForward) && !checkForFriendlyPieceOnMoves(twoForward, piecesPos) && !checkForEnemyPieceOnMoves(twoForward, piecesPos))
                    {
                        moves.Add(twoForward);
                    }

                }
            }
            
            //Vector2Int twoForward = new Vector2Int(currentPos.x + 2, currentPos.y);
            //if (inStartingPos(currentPos))
            //{
            //    if (inBoundaries(twoForward) && !checkForFriendlyPieceOnMoves(twoForward, piecesPos) && !checkForEnemyPieceOnMoves(twoForward, piecesPos))
            //    {
            //        moves.Add(twoForward);
            //    }
                
            //}

            // move for attack
            Vector2Int attackLeft = new Vector2Int(currentPos.x + 1, currentPos.y - 1);
            if (inBoundaries(attackLeft) && !checkForFriendlyPieceOnMoves(attackLeft, piecesPos))
            {
                moves.Add(attackLeft);
            }
            Vector2Int attackRight = new Vector2Int(currentPos.x + 1, currentPos.y + 1);
            if (inBoundaries(attackRight) && !checkForFriendlyPieceOnMoves(attackRight, piecesPos))
            {
                moves.Add(attackRight);
            }

        }
        else
        {
            Vector2Int oneForward = new Vector2Int(currentPos.x - 1, currentPos.y);
            if (inBoundaries(oneForward) && !checkForFriendlyPieceOnMoves(oneForward, piecesPos) && !checkForEnemyPieceOnMoves(oneForward, piecesPos))
            {
                moves.Add(oneForward);
                Vector2Int twoForward = new Vector2Int(currentPos.x - 2, currentPos.y);
                if (inStartingPos(currentPos))
                {
                    if (inBoundaries(twoForward) && !checkForFriendlyPieceOnMoves(twoForward, piecesPos) && !checkForEnemyPieceOnMoves(twoForward, piecesPos))
                    {
                        moves.Add(twoForward);
                    }
                }
            }

            //Vector2Int twoForward = new Vector2Int(currentPos.x - 2, currentPos.y);
            //if (inStartingPos(currentPos))
            //{
            //    if (inBoundaries(twoForward) && !checkForFriendlyPieceOnMoves(twoForward, piecesPos) && !checkForEnemyPieceOnMoves(twoForward, piecesPos))
            //    {
            //        moves.Add(twoForward);
            //    }
            //}

            // move for attack
            Vector2Int attackLeft = new Vector2Int(currentPos.x - 1, currentPos.y - 1);
            if (inBoundaries(attackLeft) && !checkForFriendlyPieceOnMoves(attackLeft, piecesPos))
            {
                moves.Add(attackLeft);
            }

            Vector2Int attackRight = new Vector2Int(currentPos.x - 1, currentPos.y + 1);
            if (inBoundaries(attackRight) && !checkForFriendlyPieceOnMoves(attackRight, piecesPos))
            {
                moves.Add(attackRight);
            }

        }

        // check if the added moves are valid
        for (int i = 0; i < moves.Count; i++)
        {
            if (checkForFriendlyPieceOnMoves(moves[i], piecesPos))
            {
                continue;
            }
            else
            {
                validMoves.Add(moves[i]);
            }
        }

        return validMoves;

    }


    private List<Vector2Int> ValidMovesForRook(Vector2Int currentPos, List<Vector2Int> piecesPos)
    {
        List<Vector2Int> validMoves = new List<Vector2Int>();
        int i;

        // moves in column upward
        for (i = currentPos.x + 1; i <= 7; i++)
        {

            Vector2Int move = new Vector2Int(i, currentPos.y);
            if (!inBoundaries(move) || checkForFriendlyPieceOnMoves(move, piecesPos))
            {
                break;
            }
            else if (checkForEnemyPieceOnMoves(move, piecesPos))
            {
                validMoves.Add(move);
                break;
            }
            else
            {
                validMoves.Add(move);
            }
        }

        // moves in column downward
        for (i = currentPos.x - 1; i >= 0; i--)
        {

            Vector2Int move = new Vector2Int(i, currentPos.y);
            if (!inBoundaries(move) || checkForFriendlyPieceOnMoves(move, piecesPos))
            {
                break;
            }
            else if (checkForEnemyPieceOnMoves(move, piecesPos))
            {
                validMoves.Add(move);
                break;
            }
            else
            {
                validMoves.Add(move);
            }
        }


        // moves in row towards right
        for (i = currentPos.y + 1; i <= 7; i++)
        {
            Vector2Int move = new Vector2Int(currentPos.x, i);
            if (!inBoundaries(move) || checkForFriendlyPieceOnMoves(move, piecesPos))
            {
                break;
            }
            else if (checkForEnemyPieceOnMoves(move, piecesPos))
            {
                validMoves.Add(move);
                break;
            }
            else
            {
                validMoves.Add(move);
            }
        }

        // moves in a row towards left
        for (i = currentPos.y - 1; i >= 0; i--)
        {
            Vector2Int move = new Vector2Int(currentPos.x, i);
            if (!inBoundaries(move) || checkForFriendlyPieceOnMoves(move, piecesPos))
            {
                break;
            }
            else if (checkForEnemyPieceOnMoves(move, piecesPos))
            {
                validMoves.Add(move);
                break;
            }
            else
            {
                validMoves.Add(move);
            }
        }

        return validMoves;
    }


    private List<Vector2Int> ValidMovesForKnight(Vector2Int currentPos, List<Vector2Int> piecesPos)
    {
        List<Vector2Int> validMoves = new List<Vector2Int>();
        List<Vector2Int> moves = new List<Vector2Int>();

        // add all the possible moves for knight
        List<Vector2Int> possibleMoves = new List<Vector2Int> {
            new Vector2Int(currentPos.x + 2, currentPos.y + 1),
            new Vector2Int(currentPos.x + 2, currentPos.y - 1),
            new Vector2Int(currentPos.x - 2, currentPos.y + 1),
            new Vector2Int(currentPos.x - 2, currentPos.y - 1),
            new Vector2Int(currentPos.x + 1, currentPos.y + 2),
            new Vector2Int(currentPos.x + 1, currentPos.y - 2),
            new Vector2Int(currentPos.x - 1, currentPos.y + 2),
            new Vector2Int(currentPos.x - 1, currentPos.y - 2)
        };

        // check if the added moves are valid
        foreach (Vector2Int move in possibleMoves)
        {
            if (!inBoundaries(move) || checkForFriendlyPieceOnMoves(move, piecesPos))
            {
                continue;
            }
            else if (checkForEnemyPieceOnMoves(move, piecesPos))
            {
                validMoves.Add(move);
                //continue;
            }
            else
            {
                validMoves.Add(move);
            }

            //if (inBoundaries(move) && !checkForFriendlyPieceOnMoves(move, piecesPos))
            //{
            //    validMoves.Add(move);
            //}
        }

        return validMoves;
    }

    private List<Vector2Int> ValidMovesForBishop(Vector2Int currentPos, List<Vector2Int> piecesPos)
    {
        List<Vector2Int> validMoves = new List<Vector2Int>();

        // moves in diagonal towards right and up
        for (int i = currentPos.x + 1, j = currentPos.y + 1; i <= 7 && j <= 7; i++, j++)
        {
            Vector2Int move = new Vector2Int(i, j);
            if (!inBoundaries(move) || checkForFriendlyPieceOnMoves(move, piecesPos))
            {
                break;
            }
            else if(checkForEnemyPieceOnMoves(move, piecesPos))
            {
                validMoves.Add(move);
                break;
            }
            else
            {
                validMoves.Add(move);
            }
        }


        // moves in diagonal towards right and down
        for (int i = currentPos.x + 1, j = currentPos.y - 1; i <= 7 && j >= 0; i++, j--)
        {
            Vector2Int move = new Vector2Int(i, j);
            if (!inBoundaries(move) || checkForFriendlyPieceOnMoves(move, piecesPos))
            {
                break;
            }
            else if (checkForEnemyPieceOnMoves(move, piecesPos))
            {
                validMoves.Add(move);
                break;
            }
            else
            {
                validMoves.Add(move);
            }
        }


        // moves in diagonal towards left and up
        for (int i = currentPos.x - 1, j = currentPos.y + 1; i >= 0 && j <= 7; i--, j++)
        {
            Vector2Int move = new Vector2Int(i, j);
            if (!inBoundaries(move) || checkForFriendlyPieceOnMoves(move, piecesPos))
            {
                break;
            }
            else if (checkForEnemyPieceOnMoves(move, piecesPos))
            {
                validMoves.Add(move);
                break;
            }
            else
            {
                validMoves.Add(move);
            }
        }


        // moves in diagonal towards left and down
        for (int i = currentPos.x - 1, j = currentPos.y - 1; i >= 0 && j >= 0; i--, j--)
        {
            Vector2Int move = new Vector2Int(i, j);
            if (!inBoundaries(move) || checkForFriendlyPieceOnMoves(move, piecesPos))
            {
                break;
            }
            else if (checkForEnemyPieceOnMoves(move, piecesPos))
            {
                validMoves.Add(move);
                break;
            }
            else
            {
                validMoves.Add(move);
            }
        }
        return validMoves;
    }


    private List<Vector2Int> ValidMovesForKing(Vector2Int currentPos, List<Vector2Int> piecesPos)
    {
        List<Vector2Int> validMoves = new List<Vector2Int>();

        List<Vector2Int> possibleMoves = new List<Vector2Int>
        {
            new Vector2Int(currentPos.x + 1, currentPos.y),
            new Vector2Int(currentPos.x + 1, currentPos.y + 1),
            new Vector2Int(currentPos.x + 1, currentPos.y - 1),
            new Vector2Int(currentPos.x - 1, currentPos.y),
            new Vector2Int(currentPos.x - 1, currentPos.y + 1),
            new Vector2Int(currentPos.x - 1, currentPos.y - 1),
            new Vector2Int(currentPos.x, currentPos.y + 1),
            new Vector2Int(currentPos.x, currentPos.y - 1)
        };

        foreach (Vector2Int move in possibleMoves)
        {

            if (!inBoundaries(move) || checkForFriendlyPieceOnMoves(move, piecesPos))
            {
                continue;
            }
            else if (checkForEnemyPieceOnMoves(move, piecesPos))
            {
                validMoves.Add(move);
                continue;
            }
            else
            {
                validMoves.Add(move);
            }

            //if (inBoundaries(move) && !checkForFriendlyPieceOnMoves(move, piecesPos))
            //{
            //    validMoves.Add(move);
            //}
        }

        return validMoves;
    }


    private bool inBoundaries(Vector2Int pos)
    {
        return pos.y >= 0 && pos.y < 8 && pos.x >= 0 && pos.x < 8;
    }


    private bool inStartingPos(Vector2Int pos)
    {
        return pos.x == 1 || pos.x == 6;
    }

    private bool checkForFriendlyPieceOnMoves(Vector2Int movePos, List<Vector2Int> PiecesPos)
    {
        for (int i = 0; i < PiecesPos.Count; i++)
        {
            if (PiecesPos[i] == movePos)
            {
                GameObject pieceTile = ChessBoardHandler.Instance.GetTile(PiecesPos[i].x, PiecesPos[i].y);
                GameObject piece = pieceTile.gameObject.GetComponent<tiles>().piece;
                if (piece.tag == ChessGameController.Instance.selectedPiece.tag)
                {
                    return true;
                }
            }
        }
        return false;
    }

    private bool checkForEnemyPieceOnMoves(Vector2Int movePos, List<Vector2Int> PiecesPos)
    {
        for (int i = 0; i < PiecesPos.Count; i++)
        {
            if (PiecesPos[i] == movePos)
            {
                GameObject pieceTile = ChessBoardHandler.Instance.GetTile(PiecesPos[i].x, PiecesPos[i].y);
                GameObject piece = pieceTile.gameObject.GetComponent<tiles>().piece;
                if (piece.tag != ChessGameController.Instance.selectedPiece.tag)
                {
                    return true;
                }
            }
        }
        return false;
    }


}