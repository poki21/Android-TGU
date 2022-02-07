using UnityEngine;

public class ButtonRestart : MonoBehaviour
{
    public Game Game;

    public void Restart()
    {
        Game.ReloadLevel();
    }
}
