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

    public int CrystalsCollectedPerLevel { get; private set; }

    public event UnityAction<int> LighningsChanged;
    public event UnityAction<int> BombsChanged;
    public event UnityAction<int> CrystalsChanged;

    private float _crystalMultiplier = 1;

    private void Start()
    {
        LighningsChanged?.Invoke(_lightning);
        BombsChanged?.Invoke(_bombs);
        CrystalsChanged?.Invoke(_crystals);
    }

    public void AddLightnings(int value)
    {
        _lightning += value;
        LighningsChanged?.Invoke(_lightning);
    }

    public void AddBombs(int value)
    {
        _bombs += value;
        BombsChanged?.Invoke(_bombs);
    }

    public void AddCrystals(int value)
    {
        _crystals += value;
        CrystalsCollectedPerLevel += value;
        CrystalsChanged?.Invoke(_crystals);
    }

    public void AddCrystalMultiplier(float value)
    {
        _crystalMultiplier += value;
    }

    public void MultiplyCrystals()
    {
        CrystalsCollectedPerLevel = (int)(CrystalsCollectedPerLevel * _crystalMultiplier);
        _crystals += CrystalsCollectedPerLevel;
        CrystalsChanged?.Invoke(CrystalsCollectedPerLevel);
    }
}
