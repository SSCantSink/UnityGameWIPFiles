using UnityEngine;
using UnityEngine.UI;

public class CoinCounter : MonoBehaviour
{
    public Text text;

    public void SetMoney(int value)
    {
        text.text = value.ToString();
    }

    public void SubtractMoney(int value)
    {

    }
}
