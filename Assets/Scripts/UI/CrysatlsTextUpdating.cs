using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CrysatlsTextUpdating : MonoBehaviour
{
    [SerializeField] private Text _crystals;
    [SerializeField] private Wallet _wallet;

    private void OnEnable()
    {
        _crystals.text = _wallet.Crystals.ToString();
    }
}
