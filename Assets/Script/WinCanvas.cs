using UnityEngine;
using UnityEngine.UI;

public class WinCanvas : MonoBehaviour
{
    public Text Text;
    public Game Game;
    void Update()
    {
        Text.text = $"GREAT! \n YOU PASSED LEVEL {Game.LevelIndex + 1}! \n NEXT LEVEL?";
        if (Game.LevelIndex == 2) Text.text = $"YOU ARE AWESOME! \n THANKS FOR PLAYING! \n RESTART GAME?";
    }
}
