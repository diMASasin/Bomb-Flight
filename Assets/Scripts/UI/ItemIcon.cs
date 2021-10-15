using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemIcon : MonoBehaviour
{
    [SerializeField] private Wallet _wallet;
    [SerializeField] private ParticleSystem[] _particleSystems;
    [SerializeField] private Animator _animator;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent(out Reward reward))
        {
            if (reward.Target != gameObject)
                return;

            foreach (var particleSystem in _particleSystems)
                particleSystem.Play();

            AddRewardToBalance(reward);

            if (!_animator.GetCurrentAnimatorStateInfo(0).IsName("RewardAccepted"))
                _animator.SetTrigger("Collected");
            else
                _animator.ResetTrigger("Collected");

            Destroy(reward.gameObject);
        }
    }

    private void AddRewardToBalance(Reward reward)
    {
        if (reward.RewardType == Rewards.lightnings)
        {
            _wallet.AddLightnings(reward.RewardValue);
        }
        else
        {
            _wallet.AddCrystals(reward.RewardValue);
            _wallet.AddCrystalsCollectedPerLevel(reward.RewardValue);
        }
    }
}
