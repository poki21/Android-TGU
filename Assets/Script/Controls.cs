using UnityEngine;
public class Controls : MonoBehaviour
{
    public Rigidbody _player;
    private Vector3 _previousMousePosition;
    public float Sensetivity = 1f;
    private void Awake()
    {
        _player = GetComponent<Rigidbody>();
    }
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            Vector3 delta = Input.mousePosition - _previousMousePosition;
            _player.AddForce(delta.x * Sensetivity, 0, 0);
        }
        _previousMousePosition = Input.mousePosition;
    }
}
