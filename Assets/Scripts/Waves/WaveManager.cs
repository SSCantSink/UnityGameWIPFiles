using UnityEngine;

public class WaveManager : MonoBehaviour
{

    int currentWaveIndex = 0;

    public GameObject[] wavePrefabs;

    public WaveStats currentWave;

    // Start is called before the first frame update
    void Start()
    {
        Instantiate(wavePrefabs[currentWaveIndex], transform.position, Quaternion.identity);
        currentWave = GameObject.FindGameObjectWithTag("Wave").GetComponent<WaveStats>();
    }

    /*
    WaveStats FindWave(string name)
    {
        if (GameObject.FindGameObjectWithTag("Wave").name == name)
        {
            return GameObject.FindGameObjectWithTag("Wave").GetComponent<WaveStats>();
        }

        Debug.Log("Couldn't find wave with name " + name + ".");
        return null;
    }
    */

    // Update is called once per frame
    void Update()
    {
        // BUSY WAITING
        if (GameObject.FindGameObjectWithTag("Wave") == null)
        {
            ChangeToNextWave();
        }
    }

    void ChangeToNextWave()
    {
        currentWaveIndex++;
        Instantiate(wavePrefabs[currentWaveIndex], transform.position, Quaternion.identity);
        // TODO: need to check if wave has been deleted and next one has been spawned before changing to next wave dummy.
        currentWave = GameObject.FindGameObjectWithTag("Wave").GetComponent<WaveStats>();
    }
}
