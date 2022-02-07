using UnityEngine;

public class Block : MonoBehaviour
{
    public int Value;
    public TextMesh Text;
    public int minValue;
    public int maxValue;
    private void Start()
    {
        Value = Random.Range(minValue, maxValue);
}

    private void Update()
    {
        Text.text = Value.ToString();
    }
}
