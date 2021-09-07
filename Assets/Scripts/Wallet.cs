using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Wallet : MonoBehaviour
{
    [SerializeField] private int _fleshes;
    [SerializeField] private int _bombs;
    [SerializeField] private int _crystals;

    public int Fleshes => _fleshes;
    public int Bombs => _bombs;
    public int Crystals => _crystals;

    public event UnityAction<int> FleshesChanged;
    public event UnityAction<int> BombsChanged;
    public event UnityAction<int> CrystalsChanged;

    public void AddFleshes(int value)
    {
        _fleshes += value;
        FleshesChanged?.Invoke(_fleshes);
    }

    public void AddBombs(int value)
    {
        _bombs += value;
        BombsChanged?.Invoke(_bombs);
    }

    public void AddCrystals(int value)
    {
        _crystals += value;
        CrystalsChanged?.Invoke(_crystals);
    }
}
