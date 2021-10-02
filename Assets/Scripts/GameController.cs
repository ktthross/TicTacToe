using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class PlayerColor
{
    public Color panel_color;
    public Color text_color;
}

[System.Serializable]
public class Player {
    public Image panel;
    public Text text;
    public Button button;
}

public class GameController : MonoBehaviour
{
    public Text[] button_list;
    public GameObject game_over_panel;
    public GameObject restart_button;
    public Text game_over_text;
    private string player_side;
    private int move_count;
    public Player player_x;
    public Player player_o;
    public PlayerColor active_player_color;
    public PlayerColor inactive_player_color;
    public GameObject start_info;


    private void Awake()
    {
        move_count = 0;
        SetGameControllerReferenceOnButtons();
        game_over_panel.SetActive(false);
        restart_button.SetActive(false);
    }

    void ChangeSides()
    {
        if (player_side == "X")
        {
            player_side = "O";
            SetPlayerColors(player_o, player_x);
        } else
        {
            player_side = "X";
            SetPlayerColors(player_x, player_o);
        }
    }

    public void EndTurn()
    {
        move_count++;

        if (button_list[0].text == player_side && button_list[1].text == player_side && button_list[2].text == player_side)
        {
            GameOver(player_side);
        } else if (button_list[3].text == player_side && button_list[4].text == player_side && button_list[5].text == player_side)
        {
            GameOver(player_side);
        } else if (button_list[6].text == player_side && button_list[7].text == player_side && button_list[8].text == player_side)
        {
            GameOver(player_side);
        } else if (button_list[0].text == player_side && button_list[3].text == player_side && button_list[6].text == player_side)
        {
            GameOver(player_side);
        } else if (button_list[1].text == player_side && button_list[4].text == player_side && button_list[7].text == player_side)
        {
            GameOver(player_side);
        } else if (button_list[2].text == player_side && button_list[5].text == player_side && button_list[8].text == player_side)
        {
            GameOver(player_side);
        } else if (button_list[0].text == player_side && button_list[4].text == player_side && button_list[8].text == player_side)
        {
            GameOver(player_side);
        } else if (button_list[2].text == player_side && button_list[4].text == player_side && button_list[6].text == player_side)
        {
            GameOver(player_side);
        } else if (move_count >= 9)
        {
            GameOver("draw");
        } else 
        {
            ChangeSides();
        }
    }

    void GameOver(string winning_player)
    {
        SetBoardInteractable(false);
        if (winning_player == "draw")
        {
            SetPlayerColorsInactive();
            game_over_text.text = "It's a draw!";
        } else
        {
            game_over_text.text = winning_player + " Wins!";
        }
        game_over_panel.SetActive(true);
        restart_button.SetActive(true);
    }

    public string GetPlayerSide()
    {
        return player_side;
    }

    public void RestartGame()
    {
        move_count = 0;
        game_over_panel.SetActive(false);
        restart_button.SetActive(false);
        start_info.SetActive(true);
        SetPlayerButtons(true);
        SetPlayerColorsInactive();
        for (int itr = 0; itr < button_list.Length; itr++)
        {
            button_list[itr].text = "";
        }
    }

    void SetBoardInteractable(bool state)
    {
        for (int itr = 0; itr < button_list.Length; itr++)
        {
            button_list[itr].GetComponentInParent<Button>().interactable = state;
        }

    }

    void SetGameControllerReferenceOnButtons()
    {
        for (int itr = 0; itr < button_list.Length; itr++)
        {
            button_list[itr].GetComponentInParent<GridSpace>().SetGameControllerReference(this);
        }
    }

    void SetPlayerButtons(bool toggle)
    {
        player_x.button.interactable = toggle;
        player_o.button.interactable = toggle;
    }

    void SetPlayerColors(Player new_player, Player old_player)
    {
        new_player.panel.color = active_player_color.panel_color;
        new_player.text.color = active_player_color.text_color;
        old_player.panel.color = inactive_player_color.panel_color;
        old_player.text.color = inactive_player_color.text_color;
    }

    void SetPlayerColorsInactive()
    {
        player_x.panel.color = inactive_player_color.panel_color;
        player_x.text.color = inactive_player_color.text_color;
        player_o.panel.color = inactive_player_color.panel_color;
        player_o.text.color = inactive_player_color.text_color;

    }

    public void SetStartingSide(string starting_side)
    {
        player_side = starting_side;
        if (player_side == "X")
        {
            SetPlayerColors(player_x, player_o);
        } else
        {
            SetPlayerColors(player_o, player_x);
        }
        StartGame();
    }

    void StartGame()
    {
        SetBoardInteractable(true);
        SetPlayerButtons(false);
        start_info.SetActive(false);
    }
}
