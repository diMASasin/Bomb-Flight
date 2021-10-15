using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using IJunior.TypedScenes;

public class Wallet : MonoBehaviour
{
    [SerializeField] private float _lightnings;
    [SerializeField] private int _bombs;
    [SerializeField] private float _crystals;
    [SerializeField] private GradualAccrualOf—urrency _accrualOf—urrency;

    public float Lightnings => _lightnings;
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
        UpdateAll();
    }

    public void UpdateAll()
    {
        LighningsChanged?.Invoke(_lightnings);
        BombsChanged?.Invoke(_bombs);
        CrystalsChanged?.Invoke(_crystals);
    }

    public void AddLightnings(float value)
    {
        _lightnings += value;
        LighningsChanged?.Invoke(_lightnings);
    }


    public void AddBombs(int value)
    {
        _bombs += value;
        BombsChanged?.Invoke(_bombs);
    }

    public void AddCrystals(float value)
    {
        _crystals += value;
        CrystalsChanged?.Invoke(_crystals);
    }

    public void AddCrystalsCollectedPerLevel(float value)
    {
        CrystalsCollectedPerLevel += value;
    }

    public void AddCurrency(Rewards rewards, float value)
    {
        if (rewards == Rewards.crystals)
            AddCrystals(value);
        else
            AddLightnings(value);
    }

    public void UpdateLightningsText(float value)
    {
        LighningsChanged?.Invoke(value);
    }

    public void UpdateCrystalsText(float value)
    {
        CrystalsChanged?.Invoke(value);
    }

    public void UpdateCurrency(Rewards rewards, float value)
    {
        if (rewards == Rewards.crystals)
            UpdateCrystalsText(value);
        else 
            UpdateLightningsText(value);
    }

    public void AddCrystalMultiplier(float value)
    {
        _crystalMultiplier += value;
        CrystalMultiplierChanged?.Invoke(_crystalMultiplier);
    }

    public void MultiplyCrystals()
    {
        _accrualOf—urrency.Add((int)(CrystalsCollectedPerLevel * (_crystalMultiplier - 1)), Rewards.crystals);
    }
}
