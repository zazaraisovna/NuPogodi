using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UIScript : MonoBehaviour {
    public SpriteRenderer life1;
    public SpriteRenderer life2;
    public SpriteRenderer life3;

    private GameData gameData;
    Text text;

    void Awake()
    {
        text = GetComponent<Text>();
    }

    void Start()
    {
        gameData = GameData.Instance;
    }

    void Update()
    {
        text.text = gameData.egg_cnt.ToString("D4");

        if (gameData.lose_cnt > 0)
        {
            if (gameData.lose_cnt == 1)
            {
                life1.enabled = true;
            }
            else if (gameData.lose_cnt == 2)
            {
                life1.enabled = true;
                life2.enabled = true;
            }
            else if (gameData.lose_cnt == 3)
            {
                life1.enabled = true;
                life2.enabled = true;
                life3.enabled = true;
            }
        }
        else
        {
            life1.enabled = false;
            life2.enabled = false;
            life3.enabled = false;
        }
    }
}
