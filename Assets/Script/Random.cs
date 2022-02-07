using UnityEngine;
using Random = System.Random;

public class Randomizer : MonoBehaviour
{
    public Block Block;
    void Start()
    {
        Random random = new Random();
        Block.Value = random.Next(1, 25);
    }
}
