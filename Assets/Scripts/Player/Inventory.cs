using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    int _treasureCount = 0;
    public int TreasureCount { get { return _treasureCount; } }

    public void increaseTreasure(int amount)
    {
        _treasureCount += amount;
    }
}
