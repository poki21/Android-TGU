using UnityEngine;
using UnityEngine.UI;

public class LevelText : MonoBehaviour
{
    public Text Text;
    public Game Game; 
    void FixedUpdate()
    {
        Text.text = "Round " + (Game.LevelIndex + 1).ToString();
    }
}
