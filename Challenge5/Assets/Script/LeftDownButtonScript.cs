using UnityEngine;
using System.Collections;

public class LeftDownButtonScript : MonoBehaviour {

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
                gameData.isDownLeft = true;

                gameData.isUpLeft = false;
                gameData.isUpRight = false;
                gameData.isDownRight = false;

                gameData.isStatusChange = true;
            }
        }
    }
}
