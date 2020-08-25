using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Treasure : CollectibleBase
{
    [SerializeField] int _treasureValue = 1;

    protected override void Collect(Player player)
    {
        Inventory _inventory = player.GetComponent<Inventory>(); 
        if (_inventory != null)
        {
            _inventory.increaseTreasure(_treasureValue);
        }
    }

    protected override void Movement(Rigidbody rb)
    {
        Quaternion turnOffset = Quaternion.Euler(0, 0, MovementSpeed);
        rb.MoveRotation(rb.rotation * turnOffset);
    }
}
