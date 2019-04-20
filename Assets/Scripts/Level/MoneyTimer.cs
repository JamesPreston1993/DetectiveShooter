using UnityEngine;

public class MoneyTimer : MonoBehaviour
{
    private float startTime;
    public float destroyAfterTime;

    void Start()
    {
        startTime = Time.time;
    }

    void Update()
    {
        if (Time.time > startTime + destroyAfterTime)
        {
            Destroy(gameObject);
        }
    }
}
