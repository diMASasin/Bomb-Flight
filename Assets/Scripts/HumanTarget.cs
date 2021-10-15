using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class HumanTarget : Target
{
    private Animator _animator;

    private new void Start()
    {
        base.Start();
        _animator = GetComponent<Animator>();
    }

    override public void SetExploded()
    {
        base.SetExploded();
        _animator.enabled = false;
    }
}
