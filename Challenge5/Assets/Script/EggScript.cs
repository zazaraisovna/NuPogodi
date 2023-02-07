using UnityEngine;
using System.Collections;

public class EggScript : MonoBehaviour
{
    enum EggSprite { first, second, third, fourth, fifth };
    [SerializeField] SpriteRenderer[] activeSprite;

    public bool isUpLeft = false;
    public bool isDownLeft = false;
    public bool isUpRight = false;
    public bool isDownRight = false;

    
    EggSprite eggType = EggSprite.first;
    private GameData gameData;
    private float lifeTime = 0f;

    void Start()
    {
        gameData = GameData.Instance;

        isUpLeft = (gameObject.transform.position.x == -3.11f && gameObject.transform.position.y == 0.77f);
        isDownLeft = (gameObject.transform.position.x == -3.11f && gameObject.transform.position.y == -0.69f);

        isUpRight = (gameObject.transform.position.x == 3.1f && gameObject.transform.position.y == 0.77f);
        isDownRight = (gameObject.transform.position.x == 3.1f && gameObject.transform.position.y == -0.69f);
    }

    void Update()
    {
        if(!gameData.isPaused){ 
            if (!gameData.isGameOver)
            {
                for (int i = 0; i < 5; i++)
                {
                    if (eggType == (EggSprite)i)
                        lifeTime += Time.deltaTime;
                    if ((eggType == (EggSprite)i) && (lifeTime >= gameData.speed) && (eggType != (EggSprite)4))
                    {
                        eggType += 1;
                        lifeTime = 0;
                    }
                }
                
                if ((lifeTime >= gameData.speed) && (eggType == (EggSprite)4))
                {
                    eggType = EggSprite.fifth;
                    if ((gameData.isUpLeft && isUpLeft) || (gameData.isDownLeft && isDownLeft) || (gameData.isUpRight && isUpRight) || (gameData.isDownRight && isDownRight))
                    {
                        gameData.AddEgg();
                    }
                    else
                    {
                        gameData.LoseEgg();
                        if (isUpLeft || isDownLeft)
                            GenerateChick(0);
                        else if (isUpRight || isDownRight)
                            GenerateChick(1);
                    }
                    lifeTime = 0;
                    Destroy(gameObject);
                }
                SetSprite(eggType);
            }
            else if(gameData.isGameOver)
             Destroy(gameObject);
        }
    }

    void SetSprite(EggSprite type)
    {
        for (int i = 0; i < activeSprite.Length; i++)
        {
            activeSprite[i].enabled = (type == (EggSprite)i);
        }
    }
    void GenerateChick(int cs)
    {
        GameObject ChickGameObject;
        ChickGameObject = (GameObject)Resources.Load("Prefab/Fall", typeof(GameObject));
        GameObject GO;
        GO = Instantiate(ChickGameObject);
        if (ChickGameObject != null)
        {
            switch (cs)
            {
                case 0:
                    GO.transform.position = new Vector2(-3.1f, -2.05f);
                    break;
                case 1:
                    GO.transform.position = new Vector2(3.11f, -2.05f);
                    GO.transform.localScale = new Vector3(-0.87f, 0.87f, 0f);
                    break;
            }
        }
    }

}