using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Battery : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent(out Reward reward))
        {
            if (reward.Target != gameObject)
                return;

            Destroy(reward.gameObject);
        }
    }
}
