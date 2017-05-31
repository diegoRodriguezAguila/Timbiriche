using System;
using System.Collections.Generic;
using UnityEngine;

public class BoardController : MonoBehaviour
{
    public int boardSize;
    public GameObject cellPrefab;
    private List<GameObject> board;
    private int totalTiles;
    private float scaleFactor;
    private Vector3 scale;

    private void Start()
    {
        if (boardSize % 2 == 0)
            throw new ArgumentException("boardSize must be odd");
        totalTiles = boardSize * boardSize / 2 + 1;
        board = new List<GameObject>(totalTiles);
        float width = Screen.width;
        float reqWidth = boardSize * 32 + 20;
        float factor = width / reqWidth;
        scaleFactor = factor > 1.2f ? 1.2f : factor;
        scale = new Vector3(scaleFactor, scaleFactor, 1f);
        GenerateBoard();
    }


    private void GenerateBoard()
    {
        int posLimit = boardSize / 2;
        int negLimit = -1 * (boardSize / 2);
        int rowCount = 1;
        int startPos = 0;
        bool underLimit = true;
        for (int y = posLimit; y >= negLimit; y--)
        {
            GenerateRow(startPos, rowCount, y);
            if (underLimit && rowCount == boardSize)
                underLimit = false;
            if (underLimit)
            {
                rowCount += 2;
                startPos--;
            }
            else
            {
                rowCount -= 2;
                startPos++;
            }
        }
    }

    private void GenerateRow(int startPos, int limit, int y)
    {
        for (int i = 0; i < limit; i++)
        {
            var tile = (GameObject)Instantiate(cellPrefab, new Vector3((startPos + i) * scaleFactor,
                y * scaleFactor, 0), Quaternion.identity);
            tile.transform.localScale = scale;
            board.Add(tile);
        }
    }

    // Update is called once per frame
    private void Update()
    {
    }
}