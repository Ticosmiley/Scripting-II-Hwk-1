using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bouncer : Enemy
{
    [SerializeField] int _pushForce = 400;

    protected override void PlayerImpact(Player player)
    {
        base.PlayerImpact(player);
        Vector3 push = player.transform.position - transform.position;
        player.gameObject.GetComponent<Rigidbody>().AddForce(push * _pushForce);
    }
}
