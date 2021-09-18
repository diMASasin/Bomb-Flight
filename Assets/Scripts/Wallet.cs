using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Wallet : MonoBehaviour
{
    [SerializeField] private int _lightning;
    [SerializeField] private int _bombs;
    [SerializeField] private int _crystals;

    public int Lightnings => _lightning;
    public int Bombs => _bombs;
    public int Crystals => _crystals;

    public event UnityAction<int> FleshesChanged;
    public event UnityAction<int> BombsChanged;
    public event UnityAction<int> CrystalsChanged;

    public void AddLightnings(int value)
    {
        _lightning += value;
        FleshesChanged?.Invoke(_lightning);
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
