using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CrysatlsTextUpdating : MonoBehaviour
{
    [SerializeField] private TMP_Text _crystals;
    [SerializeField] private Wallet _wallet;

    private void OnEnable()
    {
        _wallet.CrystalsChanged += OnCrystalsChanged;
        _wallet.UpdateCrystalsText(_wallet.Crystals);
    }

    private void OnDisable()
    {
        _wallet.CrystalsChanged -= OnCrystalsChanged;
    }

    private void OnCrystalsChanged(float value)
    {
        _crystals.text = value.ToString("0.");
    }
}
