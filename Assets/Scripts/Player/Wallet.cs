using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using IJunior.TypedScenes;

public class Wallet : MonoBehaviour, ISceneLoadHandler<int>
{
    [SerializeField] private float _lightning;
    [SerializeField] private int _bombs;
    [SerializeField] private float _crystals;

    public float Lightnings => _lightning;
    public int Bombs => _bombs;
    public float Crystals => _crystals;

    public float CrystalsCollectedPerLevel { get; private set; }

    public event UnityAction<float> LighningsChanged;
    public event UnityAction<int> BombsChanged;
    public event UnityAction<float> CrystalsChanged;
    public event UnityAction<float> CrystalMultiplierChanged;

    private float _crystalMultiplier = 1;

    private void Start()
    {
        LighningsChanged?.Invoke(_lightning);
        BombsChanged?.Invoke(_bombs);
        CrystalsChanged?.Invoke(_crystals);
    }

    public void OnSceneLoaded(int argument)
    {
        _crystals = argument;
        CrystalsChanged?.Invoke(_crystals);
    }

    public void AddLightnings(float value)
    {
        _lightning += value;
        LighningsChanged?.Invoke(_lightning);
    }

    public void AddBombs(int value)
    {
        _bombs += value;
        BombsChanged?.Invoke(_bombs);
    }

    public void AddCrystals(float value)
    {
        _crystals += value;
        CrystalsCollectedPerLevel += value;
        CrystalsChanged?.Invoke(_crystals);
    }

    public void AddCrystalMultiplier(float value)
    {
        _crystalMultiplier += value;
        CrystalMultiplierChanged?.Invoke(_crystalMultiplier);
    }

    public void MultiplyCrystals()
    {
        CrystalsCollectedPerLevel = (int)(CrystalsCollectedPerLevel * _crystalMultiplier);
        _crystals += CrystalsCollectedPerLevel;
        CrystalsChanged?.Invoke(CrystalsCollectedPerLevel);
    }
}
