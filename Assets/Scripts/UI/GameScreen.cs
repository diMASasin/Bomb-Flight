using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameScreen : MonoBehaviour
{
    [SerializeField] private TMP_Text _lightnings;
    [SerializeField] private TMP_Text _bombs;
    [SerializeField] private TMP_Text _crystals;
    [SerializeField] private Wallet _wallet;

    private void OnEnable()
    {
        _wallet.LighningsChanged += OnLightningsChanged;
        _wallet.BombsChanged += OnBombsChanged;
        _wallet.CrystalsChanged += OnCrystalsChanged;
        _wallet.UpdateAll();
    }

    private void OnDisable()
    {
        _wallet.LighningsChanged -= OnLightningsChanged;
        _wallet.BombsChanged -= OnBombsChanged;
        _wallet.CrystalsChanged -= OnCrystalsChanged;
    }

    private void OnLightningsChanged(float fleshes)
    {
        _lightnings.text = string.Format("{0:f1}", fleshes);
    }

    private void OnBombsChanged(int bombs)
    {
        _bombs.text = bombs.ToString();
    }

    private void OnCrystalsChanged(float crystals)
    {
        _crystals.text = crystals.ToString();
    }
}
