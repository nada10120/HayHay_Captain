using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartsScript : MonoBehaviour
{

    public GameObject gameController;

    private GameController controllerScript;

    private void Start()
    {
        controllerScript = gameController.GetComponent<GameController>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            controllerScript.hp = Mathf.Min(controllerScript.maxHP, controllerScript.hp + 4);
            Destroy(gameObject);
        }
    }
}
