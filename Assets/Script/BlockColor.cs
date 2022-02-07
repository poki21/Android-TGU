using UnityEngine;

public class BlockColor : MonoBehaviour
{
    public GameObject _block;
    public Material material;
    Gradient gradient = new Gradient();
    public Block TriggerZone;
    int value;
    void Start()
    {
        CreateGradient();
        SetColor(gradient);
    }

    private void SetColor(Gradient _gradient)
    {
        gameObject.GetComponent<Renderer>().material.color = _gradient.Evaluate((float)TriggerZone.GetComponent<Block>().Value / 30f);
    }

    void CreateGradient()
    {
        GradientColorKey[] gck = new GradientColorKey[2];
        GradientAlphaKey[] gak = new GradientAlphaKey[2];
        gck[0].color = Color.red;
        gck[0].time = 1.0F;

        gck[1].color = Color.green;
        gck[1].time = -1.0F;

        gak[0].alpha = 0.0F;
        gak[0].time = 1.0F;

        gak[1].alpha = 0.0F;
        gak[1].time = -1.0F;

        gradient.SetKeys(gck, gak);
    }
}
