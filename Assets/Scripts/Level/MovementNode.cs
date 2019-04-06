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

    void Start()
    {
        var lineRenderer = gameObject.AddComponent<LineRenderer>();
        lineRenderer.startColor = lineRenderer.endColor = Color.magenta;
        lineRenderer.startWidth = lineRenderer.endWidth = 0.1f;

        foreach (var node in nextNodes)
        {
            var direction = node.transform.position - transform.position;
            lineRenderer.SetPositions(new Vector3[] {
                transform.position,
                node.transform.position
            });
        }
    }

    public GameObject PickRandomNextNode()
    {
        var index = randomNumberGenerator.Next(nextNodes.Length);
        return nextNodes[index];
    }
}