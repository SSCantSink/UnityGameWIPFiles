using UnityEngine;

public class PlayerManger : MonoBehaviour
{

    public int coinCount;

    public CoinCounter coinUI;

    // Start is called before the first frame update
    void Start()
    {
        coinCount = 0;
    }

    public void GetCoin(int value)
    {
        coinCount += value;
        coinUI.SetMoney(coinCount);
    }
}
