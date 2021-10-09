using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSaver : MonoBehaviour
{
    [SerializeField] private Wallet _wallet;
    [SerializeField] private string _crystalsKey;

    private void Start()
    {
        if(PlayerPrefs.HasKey(_crystalsKey))
            _wallet.AddCrystals(PlayerPrefs.GetFloat(_crystalsKey, _wallet.Crystals));
    }

    private void OnApplicationPause(bool isPaused)
    {
        if(isPaused)
            PlayerPrefs.SetFloat(_crystalsKey, _wallet.Crystals);
    }
}
