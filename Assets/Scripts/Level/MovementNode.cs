using UnityEngine;
using Random = System.Random;

public class MovementNode : MonoBehaviour
{
    public GameObject[] nextNodes;

    private Random randomNumberGenerator;

    void Awake()
    {
        randomNumberGenerator = new Random();
    }

    void Update()
    {
        foreach (var node in nextNodes)
        {
            Debug.DrawLine(transform.position, node.transform.position, Color.magenta);
        }
    }

    public GameObject PickRandomNextNode()
    {
        var index = randomNumberGenerator.Next(nextNodes.Length);
        return nextNodes[index];
    }
}