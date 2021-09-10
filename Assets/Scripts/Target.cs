using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Rewards
{
    lightnings = 0,
    crystals = 1
}

public class Target : MonoBehaviour
{
    [SerializeField] private Rewards _rewardType;
    [SerializeField] private int _rewardValue;
    [SerializeField] private float _destroyDelay;

    [SerializeField] private Canvas _canvas;
    [SerializeField] private Reward _rewardTemplate;
    [SerializeField] private GameObject _lightningIcon;
    [SerializeField] private GameObject _crystalIcon;
    [SerializeField] private float _spawnDelay;

    public bool IsExploded { get; private set; } = false;

    public Rewards Reward => _rewardType;
    public int RewardValue => _rewardValue;

    public void SetExploded()
    {
        IsExploded = true;
    }

    public void SpawnReward()
    {
        StartCoroutine(SpawnRewardWithDelay());
    }

    public void StartDestroyWithDelay()
    {
        StartCoroutine(DestroyWithDelay(_destroyDelay));
    }

    private IEnumerator DestroyWithDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        Destroy(gameObject);
    }

    private IEnumerator SpawnRewardWithDelay()
    {
        for (int i = 0; i < _rewardValue; i++)
        {
            Reward newReward = Instantiate(_rewardTemplate, _canvas.transform);
            newReward.Initialize(_rewardType == Rewards.lightnings ? _lightningIcon : _crystalIcon, _rewardType);
            newReward.SetPosition(transform.position);
            newReward.gameObject.SetActive(true);

            yield return new WaitForSeconds(_spawnDelay);
        }
    }
}
