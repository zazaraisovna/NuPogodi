using UnityEngine;
using System.Collections;

public class RightDownButtonScript : MonoBehaviour {

    private GameData gameData;

    void Start()
    {
        gameData = GameData.Instance;
    }

    void Update () {

    }

    void OnMouseDown()
    {
        if (!gameData.isGameOver)
        {
            if (Input.GetMouseButtonDown(0))
            {
                gameData.isDownRight = true;

                gameData.isUpLeft = false;
                gameData.isDownLeft = false;
                gameData.isUpRight = false;

                gameData.isStatusChange = true;
            }
        }
    }
}
