using UnityEngine;
using System.Collections;

public class ChickenScript : MonoBehaviour
{
    float LifeTime1 = 0;
    float LifeTime2 = 0;
    float LifeTime3 = 0;
    float LifeTime4 = 0;
    float LifeTime5 = 0;

    float lifetime = 0.5f;

    bool isChick1 = true;
    bool isChick2 = false;
    bool isChicl3 = false;
    bool isChick4 = false;
    bool isChick5 = false;

    public SpriteRenderer chick1_sr;
    public SpriteRenderer chick2_sr;
    public SpriteRenderer chick3_sr;
    public SpriteRenderer chick4_sr;
    public SpriteRenderer chick5_sr;

    private GameData gameData;

    void Start()
    {
        gameData = GameData.Instance;
    }

    void Update()
    {
        if (!gameData.isPaused)
        {
            if (isChick1)
                LifeTime1 += Time.deltaTime;
            if (isChick2)
                LifeTime2 += Time.deltaTime;
            if (isChicl3)
                LifeTime3 += Time.deltaTime;
            if (isChick4)
                LifeTime4 += Time.deltaTime;
            if (isChick5)
                LifeTime5 += Time.deltaTime;

            if (isChick1 && LifeTime1 >= lifetime)
            {
                isChick1 = false;
                isChick2 = true;
            }
            if (isChick2 && LifeTime2 >= lifetime)
            {
                isChick2 = false;
                isChicl3 = true;
            }
            if (isChicl3 && LifeTime3 >= lifetime)
            {
                isChicl3 = false;
                isChick4 = true;
            }
            if (isChick4 && LifeTime4 >= lifetime)
            {
                isChick4 = false;
                isChick5 = true;
            }
            if (isChick5 && LifeTime5 >= lifetime)
            {
                isChick5 = false;
                Destroy(gameObject);
            }

            chick1_sr.enabled = isChick1;
            chick2_sr.enabled = isChick2;
            chick3_sr.enabled = isChicl3;
            chick4_sr.enabled = isChick4;
            chick5_sr.enabled = isChick5;
        }
    }
}