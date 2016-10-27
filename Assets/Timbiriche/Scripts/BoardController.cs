using UnityEngine;

public class BoardController : MonoBehaviour
{
    public int boardSize;
    public GameObject cellPrefab;

    void OnLevelWasLoaded()
    {
        GenerateBoard();
    }

    void GenerateBoard()
    {
        for (var row = 0; row < boardSize; row++)
        {
            for (var column = 0; column < boardSize; column++)
            {
                Instantiate(cellPrefab, new Vector3(row, column, 0), Quaternion.identity);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
    }
}