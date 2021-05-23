using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public int gems;
    public int rareGems;
    public int hp;
    public int maxHP;
    public Text gemsScore;
    public Text rareGemsScore;
    public Texture2D heartsTexture;
    public float heartDrawWidth = 35.0f;
    public float heartDrawHeight = 35.0f;
    public float heartOffsetY = 20.0f;
    public float heartOffsetX = 40.0f;
    public float heartsSpacing = 45.0f;

    private float heartWidth = 17.0f;
    private float heartHeight = 17.0f;
    private Sprite[] heartsSprites = new Sprite[5];
    private Texture2D[] hearts = new Texture2D[5];

    private void Start()
    {
        for (int i = 0; i < 5; i++)
        {
            heartsSprites[i] = Sprite.Create(heartsTexture, new Rect(i * 17.0f, 0.0f, heartWidth, heartHeight), new Vector2(0.5f, 0.5f));
        }
        for (int i = 0; i < 5; i++)
        {
            hearts[i] = new Texture2D((int)heartsSprites[i].rect.width, (int)heartsSprites[i].rect.height);
            var pixels = heartsSprites[i].texture.GetPixels((int)heartsSprites[i].textureRect.x,
                                                            (int)heartsSprites[i].textureRect.y,
                                                            (int)heartsSprites[i].textureRect.width,
                                                            (int)heartsSprites[i].textureRect.height);
            hearts[i].SetPixels(pixels);
            hearts[i].Apply();
        }
        maxHP = 12;
        hp = 12;
        rareGems = 0;
        gems = 0;
    }

    public void Update()
    {
        gemsScore.text = gems.ToString();
        rareGemsScore.text = rareGems + " / 3";
    }

    private void OnGUI()
    {
        float space = 0;
        for (int i = 0, remainingHP = hp; i < maxHP / 4; i++)
        {
            if (remainingHP - 4 >= 0)
            {
                GUI.DrawTexture(new Rect(heartOffsetX + space, heartOffsetY, heartDrawWidth, heartDrawHeight), hearts[0]);
                remainingHP -= 4;
            }
            else
            {
                GUI.DrawTexture(new Rect(heartOffsetX + space, heartOffsetY, heartDrawWidth, heartDrawHeight), hearts[4 - remainingHP]);
                remainingHP = 0;
            }
            space += heartsSpacing;
        }

    }
}
