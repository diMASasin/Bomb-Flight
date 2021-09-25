using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Rewards
{
    lightnings = 0,
    crystals = 1
}

[RequireComponent(typeof(RewardSpawner))]
public class Target : MonoBehaviour
{
    [SerializeField] private Rewards _rewardType;
    [SerializeField] private int _rewardValue;
    [SerializeField] private float _destroyDelay;
    [SerializeField] private int _ignoreBombLayerID = 6;

    public RewardSpawner RewardSpawner { get; private set; }
    public bool IsExploded { get; private set; } = false;

    private void Start()
    {
        RewardSpawner = GetComponent<RewardSpawner>();
    }

    public void SetExploded()
    {
        IsExploded = true;
        gameObject.layer = _ignoreBombLayerID;
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
