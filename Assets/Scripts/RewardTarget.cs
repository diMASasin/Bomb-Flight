using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class RewardTarget : MonoBehaviour
{
    [SerializeField] private Wallet _wallet;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent(out Reward reward))
        {
            reward.gameObject.SetActive(false);
            if (reward.RewardType == Rewards.lightnings)
                _wallet.AddLightnings(reward.RewardValue);
            else
                _wallet.AddCrystals(reward.RewardValue);
        }
    }
}
