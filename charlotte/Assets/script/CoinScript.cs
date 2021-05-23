using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinScript : MonoBehaviour
{
    public GameObject gameController;

    private GameController controllerScript;

    private void Start()
    {
        controllerScript = gameController.GetComponent<GameController>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            if(gameObject.name == "Rare_Gem")
                controllerScript.rareGems++;
            else if (gameObject.name == "Gem_High")
                controllerScript.gems += 50;
            else if (gameObject.name == "Gem_Low")
                controllerScript.gems += 10;
            Destroy(gameObject);
        }
    }
}
