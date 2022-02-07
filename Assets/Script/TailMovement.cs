using System.Collections.Generic;
using UnityEngine;

public class TailMovement : MonoBehaviour
{
    public GameObject Player;
    public GameObject Tailprefab;
    public Rigidbody _rigidbody;
    public float speed;

    public List<Transform> tailAmount = new List<Transform>();
    public List<Vector3> positions = new List<Vector3>();

    private void Awake()
    {
        positions.Add(Player.transform.position);
    }

    private void Start()
    {
        AddTail();
        AddTail();
        AddTail();
        AddTail();
    }
    private void FixedUpdate()
    {
        _rigidbody.AddForce(Vector3.forward * speed);
    }
    private void Update()
    {
        
        float distance = (Player.transform.position - positions[0]).magnitude;

        if (distance > 1)
        {
            Vector3 direction = (Player.transform.position - positions[0]).normalized;

            positions.Insert(0, positions[0] + direction);
            positions.RemoveAt(positions.Count - 1);

        }

        for (int i = 0; i < tailAmount.Count; i++)
        {
            tailAmount[i].position = Vector3.Lerp(positions[i + 1], positions[i], distance);
        }
    }

    public void AddTail()
    {
        GameObject tail = Instantiate(Tailprefab, positions[positions.Count - 1], Quaternion.identity, transform);
        tailAmount.Add(tail.transform);
        positions.Add(tail.transform.position);
    }

    public void RemoveTail()
    {
        Destroy(tailAmount[tailAmount.Count - 1].gameObject);
        tailAmount.RemoveAt(tailAmount.Count - 1);
        positions.RemoveAt(0);
    }
}
