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
    [SerializeField] private Rewards _reward;
    [SerializeField] private int _rewardValue;
    [SerializeField] private float _destroyDelay;

    public bool IsExploded { get; private set; } = false;

    public Rewards Reward => _reward;
    public int RewardValue => _rewardValue;

    public void SetExploded()
    {
        IsExploded = true;
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
}
