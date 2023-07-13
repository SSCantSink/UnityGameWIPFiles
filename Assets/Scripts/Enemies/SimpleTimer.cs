using UnityEngine;

public class SimpleTimer : MonoBehaviour
{

    float minTime;
    float maxTime;
    float currentTime;

    public SimpleTimer(float minTime, float maxTime)
    {
        this.minTime = minTime;
        this.maxTime = maxTime;
        currentTime = Random.Range(minTime, maxTime);
    }


    // Start is called before the first frame update
    void Start()
    {
    }

    public void ResetTimer()
    {
        currentTime = Random.Range(minTime, maxTime);
    }

    // Update is called once per frame
    void Update()
    {
        if (currentTime > 0)
        {
            currentTime -= Time.deltaTime;
        }
        else
        {
            Debug.Log("Hey, Im here!");
            ResetTimer();
        }
    }
}
