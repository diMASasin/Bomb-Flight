using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BonusPlatform : MonoBehaviour
{
    [SerializeField] private ParticleSystem[] _particleSystems;
    [SerializeField] private Wallet _wallet;
    [SerializeField] private float _addingCrystalMultiplier;
    [SerializeField] private Animator _animator;
    [SerializeField] private TMP_Text _crystalMultiplierText;

    private bool _isBonusIssued;

    private void Start()
    {
        ParticleSystemsSetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        ParticleSystemsSetActive(true);
        _animator.SetTrigger("OnHitting");
        Handheld.Vibrate();

        if(!_isBonusIssued)
        {
            _wallet.AddCrystalMultiplier(_addingCrystalMultiplier);
            _isBonusIssued = true;
        }
    }

    private void ParticleSystemsSetActive(bool value)
    {
        foreach (var particleSystem in _particleSystems)
            particleSystem.gameObject.SetActive(value);
    }
}
