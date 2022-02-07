using UnityEngine;

public class Food : MonoBehaviour
{
    public int Value;
    public TextMesh Text;
    private void Awake()
    {
        Text.text = Value.ToString();
    }
}
