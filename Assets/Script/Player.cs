using UnityEngine;
public class Player : MonoBehaviour
{
    public TailMovement TailMovement;
    public TextMesh Text;
    public Game Game;

    private void Update()
    {
        int Value = TailMovement.tailAmount.Count;
        Text.text = Value.ToString();
        if (TailMovement.tailAmount.Count < 1) Death();

        if (Input.GetKey("x")) TailMovement.AddTail();
    }

    public void Death()
    {
        Game.OnPlayerDeath();
        TailMovement.speed = 0;
    }
}
