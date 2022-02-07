using UnityEngine;

public class NextLevelButton : MonoBehaviour
{
    public Game Game;
    public GameObject WinCanvas;

    public void NextLevel()
    {
        Game.OnPlayerWon();
        WinCanvas.SetActive(false);
    }
}
