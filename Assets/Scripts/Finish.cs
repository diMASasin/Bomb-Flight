using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Finish : MonoBehaviour
{
    [SerializeField] private Boss _boss;
    [SerializeField] private Animator _animator;

    public void FinishLevel()
    {
        _animator.SetTrigger("Finished");
        _boss.StartExplodeWithDelay(2);
    }
}
