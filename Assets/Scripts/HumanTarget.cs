using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(RewardSpawner))]
public class HumanTarget : Target
{
    private Animator _animator;

    private void Start()
    {
        base.Start();
        _animator = GetComponent<Animator>();
        //RewardSpawner = GetComponent<RewardSpawner>();
    }

    override public void SetExploded()
    {
        base.SetExploded();
        _animator.enabled = false;
    }
}
