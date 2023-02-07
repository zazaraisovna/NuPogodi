using UnityEngine;
using System.Collections;

public class NewGameSript : MonoBehaviour {

    private GameData gameData;

    void Start()
    {
        gameData = GameData.Instance;
    }

    void OnMouseDown()
    {
        gameData.isNewGame = true;
    }
}
