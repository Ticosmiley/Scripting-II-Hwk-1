using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[RequireComponent(typeof(TMP_Text))]
public class TreasureDisplay : MonoBehaviour
{
    TMP_Text _text;
    Inventory _inventory;

    private void Awake()
    {
        _text = GetComponent<TMP_Text>();
    }

    private void Start()
    {
        _inventory = FindObjectOfType<Inventory>();
    }

    private void Update()
    {
        _text.text = "Treasure: " + _inventory.TreasureCount;
    }
}
