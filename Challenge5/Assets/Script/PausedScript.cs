using UnityEngine;
using System.Collections;

public class PausedScript : MonoBehaviour {
    private GameData gameData;

    void Start()
    {
        gameData = GameData.Instance;
    }

    void OnMouseDown()
    {
        gameData.isPaused= !gameData.isPaused;
    }
}
