using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LootTable : MonoBehaviour
{
    public Coin coin1;
    public Coin coin5;

    public int minCoins;
    public int maxCoins;

    public void DropLoot()
    {
        int number = Random.Range(minCoins, maxCoins + 1);

        if (number >= 5)
        {
            DropLoot(5, number / 5);
            DropLoot(1, number % 5);
        }
        else
        {
            DropLoot(1, number);
        }
    }

    public void DropLoot(int coinVal, int howMany)
    {
        if (coinVal == 1)
        {
            for (int i = 0; i < howMany; i++)
                Instantiate(coin1, transform.position, Quaternion.identity);
        }
        if (coinVal == 5)
        {
            for (int i = 0; i < howMany; i++)
                Instantiate(coin5, transform.position, Quaternion.identity);
        }
    }
}
