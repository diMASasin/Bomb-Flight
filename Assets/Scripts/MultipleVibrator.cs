using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultipleVibrator : MonoBehaviour
{
    [SerializeField] private int _numberOfVibrations = 3;
    [SerializeField] private float _interval = 0.1f;

    public void StartVibrateSeveralTimes()
    {
        StartCoroutine(VibrateSeveralTimes());
    }

    private IEnumerator VibrateSeveralTimes()
    {
        WaitForSeconds waitForIntermediateDelay = new WaitForSeconds(_interval);

        for (int i = 0; i < _numberOfVibrations; i++)
        {
            Handheld.Vibrate();
            yield return waitForIntermediateDelay;
        }
    }
}
