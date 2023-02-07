using UnityEngine;
using System.Collections;

public class RightUpButtonScript : MonoBehaviour {
    private GameData gameData;

    void Start()
    {
        gameData = GameData.Instance;
    }

    void OnMouseDown()
    {
        if (!gameData.isGameOver)
        {
            if (Input.GetMouseButtonDown(0))
            {
                gameData.isUpRight = true;

                gameData.isUpLeft = false;
                gameData.isDownLeft = false;
                gameData.isDownRight = false;

                gameData.isStatusChange = true;
            }
        }
    }
}