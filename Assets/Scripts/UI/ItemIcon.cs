using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemIcon : MonoBehaviour
{
    [SerializeField] private Wallet _wallet;
    [SerializeField] private ParticleSystem[] _particleSystems;
    [SerializeField] private Animation _animation;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent(out Reward reward))
        {
            if (reward.Target != gameObject)
                return;

            if(!_animation.isPlaying)
                _animation.Play();

            foreach (var particleSystem in _particleSystems)
                particleSystem.Play();

            AddRewardToBalance(reward);
            Destroy(reward.gameObject);
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
