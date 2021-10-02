using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GridSpace : MonoBehaviour
{
    public Button button;
    public Text button_text;
    private GameController game_controller;

    public void SetSpace() 
    {
        button_text.text = game_controller.GetPlayerSide();
        button.interactable = false;
        game_controller.EndTurn();
    }

    public void SetGameControllerReference(GameController controller)
    {
        game_controller = controller;
    }
}
