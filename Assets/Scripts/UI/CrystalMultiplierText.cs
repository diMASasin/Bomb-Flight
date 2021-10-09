using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CrystalMultiplierText : MonoBehaviour
{
    [SerializeField] private Wallet _wallet;
    [SerializeField] private TMP_Text _crystalMultiplierText;

    private void OnEnable()
    {
        _wallet.CrystalMultiplierChanged += OnCrystalMultiplierChanged;
    }

    private void OnDisable()
    {
        _wallet.CrystalMultiplierChanged -= OnCrystalMultiplierChanged;
    }

    private void OnCrystalMultiplierChanged(float value)
    {
        _crystalMultiplierText.text = "x" + value.ToString();
    }
}
