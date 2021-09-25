using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemIcon : MonoBehaviour
{
    [SerializeField] private Wallet _wallet;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent(out Reward reward))
        {
            if (reward.Target != gameObject)
                return;

            Destroy(reward.gameObject);
            AddRewardToBalance(reward);
        }
    }

    private void AddRewardToBalance(Reward reward)
    {
        if (reward.RewardType == Rewards.lightnings)
            _wallet.AddLightnings(reward.RewardValue);
        else
            _wallet.AddCrystals(reward.RewardValue);
    }
}
