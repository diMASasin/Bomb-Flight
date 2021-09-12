using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    [SerializeField] private Text _lightnings;
    [SerializeField] private Text _bombs;
    [SerializeField] private Text _crystals;
    [SerializeField] private Wallet _wallet;

    private void OnEnable()
    {
        _wallet.FleshesChanged += OnFleshesChanged;
        _wallet.BombsChanged += OnBombsChanged;
        _wallet.CrystalsChanged += OnCrystalsChanged;
    }

    private void OnDisable()
    {
        _wallet.FleshesChanged -= OnFleshesChanged;
        _wallet.BombsChanged -= OnBombsChanged;
        _wallet.CrystalsChanged -= OnCrystalsChanged;
    }

    private void OnFleshesChanged(int fleshes)
    {
        _lightnings.text = fleshes.ToString();
    }

    private void OnBombsChanged(int bombs)
    {
        _bombs.text = bombs.ToString();
    }

    private void OnCrystalsChanged(int crystals)
    {
        _crystals.text = crystals.ToString();
    }
}
