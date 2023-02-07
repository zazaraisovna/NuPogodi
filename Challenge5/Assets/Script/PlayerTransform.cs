using UnityEngine;
using System.Collections;

public class PlayerTransform : MonoBehaviour {
    public SpriteRenderer LeftVolkSR;
    public SpriteRenderer RightVolkSR;

    public SpriteRenderer LeftUpBasketSR;
    public SpriteRenderer LeftDownBasketSR;
    public SpriteRenderer RightUpBasketSR;
    public SpriteRenderer RightDownBasketSR;

    public SpriteRenderer LeftUpHenSR;
    public SpriteRenderer LeftDownHenSR;
    public SpriteRenderer RightUpHenSR;
    public SpriteRenderer RightDownHenSR;

    float HenCreateTimer = 0f;
    float HenLifeTimer = 0f;
    bool isHen = false;

    private GameData gameData;

    GameObject[] EggsGameObjects;

    void Start()
    {
        gameData = GameData.Instance;

        EggsGameObjects = new GameObject[4];
        EggsGameObjects[0] = (GameObject)Resources.Load("Prefab/Eggs", typeof(GameObject)); //Left Up
        EggsGameObjects[1] = (GameObject)Resources.Load("Prefab/Eggs", typeof(GameObject)); // Left Down
        EggsGameObjects[2] = (GameObject)Resources.Load("Prefab/Eggs", typeof(GameObject)); // Right Up
        EggsGameObjects[3] = (GameObject)Resources.Load("Prefab/Eggs", typeof(GameObject)); // Right Down


    }

    void Update () {
        if (!gameData.isPaused)
        {
            if (!gameData.isGameOver)
            {
                HenCreateTimer += Time.deltaTime;
                if (isHen)
                {
                    HenLifeTimer += Time.deltaTime;
                    if (HenLifeTimer >= 2f)
                    {
                        LeftUpHenSR.enabled = false;
                        LeftDownHenSR.enabled = false;
                        RightUpHenSR.enabled = false;
                        RightDownHenSR.enabled = false;

                        HenLifeTimer = 0f;
                        isHen = false;
                    }
                }

                if (HenCreateTimer >= gameData.henCreater)
                {
                    HenCreate();
                }

                StatusChange();
            }
        }
    }

    void StatusChange()
    {

        if (gameData.isStatusChange)
        {
            if (gameData.isUpLeft)
            {
                LeftVolkSR.enabled = true;
                RightVolkSR.enabled = false;

                LeftUpBasketSR.enabled = true;
                LeftDownBasketSR.enabled = false;
                RightUpBasketSR.enabled = false;
                RightDownBasketSR.enabled = false;
                gameData.isStatusChange = false;
            }
            else if (gameData.isDownLeft)
            {
                LeftVolkSR.enabled = true;
                RightVolkSR.enabled = false;

                LeftUpBasketSR.enabled = false;
                LeftDownBasketSR.enabled = true;
                RightUpBasketSR.enabled = false;
                RightDownBasketSR.enabled = false;

                gameData.isStatusChange = false;
            }
            else if (gameData.isUpRight)
            {
                LeftVolkSR.enabled = false;
                RightVolkSR.enabled = true;

                LeftUpBasketSR.enabled = false;
                LeftDownBasketSR.enabled = false;
                RightUpBasketSR.enabled = true;
                RightDownBasketSR.enabled = false;

                gameData.isStatusChange = false;
            }
            else if (gameData.isDownRight)
            {
                LeftVolkSR.enabled = false;
                RightVolkSR.enabled = true;

                LeftUpBasketSR.enabled = false;
                LeftDownBasketSR.enabled = false;
                RightUpBasketSR.enabled = false;
                RightDownBasketSR.enabled = true;

                gameData.isStatusChange = false;
            }
        }
    }
    void HenCreate()
    {
        int cs = Random.Range(0, 4);
        switch (cs)
        {
            case 0:
                LeftUpHenSR.enabled = true;
  //              gameData.isUpLeftHen = true;
                GenerateEgg(0);
                break;
            case 1:
                LeftDownHenSR.enabled = true;
            //    gameData.isDownLeftHen = true;
                GenerateEgg(1);
                break;
            case 2:
                RightUpHenSR.enabled = true;
              //  gameData.isUpRightHen = true;
                GenerateEgg(2);
                break;
            case 3:
                RightDownHenSR.enabled = true;
             //   gameData.isDownRightHen = true;
                GenerateEgg(3);
                break;

        }
        HenCreateTimer = 0f;
        isHen = true;
    }

    void GenerateEgg(int cs)
    {
        switch (cs)
        {
            case 0:
                if (EggsGameObjects[0] != null)
                {
                    GameObject GO;
                    GO = (GameObject)Instantiate(EggsGameObjects[0]);
                    GO.transform.position = new Vector2(-3.11f, 0.77f);
                }
                break;
            case 1:
                if (EggsGameObjects[1] != null)
                {
                    GameObject GO;
                    GO = (GameObject)Instantiate(EggsGameObjects[1]);
                    GO.transform.position = new Vector2(-3.11f, -0.69f);
                }
                break;
            case 2:
                if (EggsGameObjects[2] != null)
                {
                    GameObject GO;
                    GO = (GameObject)Instantiate(EggsGameObjects[2]);
                    GO.transform.position = new Vector2(3.1f, 0.77f);
                    GO.transform.localScale = new Vector3(-0.87f, 0.87f, 1);
                }
                break;
            case 3:
                if (EggsGameObjects[3] != null)
                {
                    GameObject GO;
                    GO = (GameObject)Instantiate(EggsGameObjects[3]);
                    GO.transform.position = new Vector2(3.1f, -0.69f);
                    GO.transform.localScale = new Vector3(-0.87f, 0.87f, 1);
                }
                break;
        }
    }
    
}
