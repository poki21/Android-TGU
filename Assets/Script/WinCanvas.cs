using UnityEngine;
using UnityEngine.UI;

public class WinCanvas : MonoBehaviour
{
    public Text Text;
    public Game Game;
    void Update()
    {
        Text.text = $"YOU WIN! \n NEXT ROUND ?";
        if (Game.LevelIndex == 2) Text.text = $"RESTART GAME?";
    }
}
