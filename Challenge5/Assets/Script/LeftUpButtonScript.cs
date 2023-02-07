using UnityEngine;
using System.Collections;

public class LeftUpButtonScript : MonoBehaviour {

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
                gameData.isUpLeft = true;
                gameData.isDownLeft = false;
                gameData.isUpRight = false;
                gameData.isDownRight = false;

                gameData.isStatusChange = true;
            }
        }
    }
}
