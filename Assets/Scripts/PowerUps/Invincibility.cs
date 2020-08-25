using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Invincibility : PowerUpBase
{
    [SerializeField] Material _material;

    Material _playerMaterial;

    protected override void PowerUp(Player player)
    {
        _playerMaterial = player.gameObject.GetComponent<Renderer>().material;
        player.gameObject.GetComponent<Renderer>().material = _material;
        player.IsInvincible = true;
    }

    protected override void PowerDown(Player player)
    {
        player.gameObject.GetComponent<Renderer>().material = _playerMaterial;
        player.IsInvincible = false;
    }
}
