using UnityEngine;
using System.Collections;

public class GameData : Singleton<GameData> {
    const float START_SPEED = 0.8f;
    const float SPEED_STEP = 0.1f;
    const float MIN_SPEED = 0.1f;

    public bool isUpLeft = false;
    public bool isDownLeft = false;
    public bool isUpRight = true;
    public bool isDownRight = false;
    public bool isStatusChange = false;
    public bool isGameOver = false;
    public bool isNewGame = false;
    public bool isPaused = false;
    public float henCreater = 4f;

    public float speed = START_SPEED; 

    public int lose_cnt = 0;
    public int egg_cnt = 0;

    protected GameData()
    {

    }

    void Start () {
	}
	
	void Update () {
        if (lose_cnt >= 3)
            isGameOver = true;
        if (isNewGame)
        {
            NewGame();
            SetSpeed(START_SPEED);
        }
	}

    public void AddEgg()
    {
        egg_cnt += 1;
        if ((egg_cnt >= 10) && ((egg_cnt % 5) == 0))
            AddSpeed(SPEED_STEP);
    }

    public void LoseEgg()
    {
        lose_cnt += 1;
    }
    void SetSpeed(float _speed)
    {
        speed = _speed;
    }

    void AddSpeed(float range)
    {
        if (speed > MIN_SPEED)
            speed -= range;
        if (henCreater > MIN_SPEED)
            henCreater -= range;
        Debug.Log("LEVEL UP " + speed);
    }
    void NewGame()
    {
        lose_cnt = 0;
        egg_cnt = 0;
        isGameOver = false;
        isNewGame = false;
    }
}
