using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBombDropper : MonoBehaviour
{
    [SerializeField] private Bomb _bombTemplate;
    [SerializeField] private Transform _bombStartPosition;
    [SerializeField] private float _slowMotionDuration = 0.5f;
    [SerializeField] private float _slowMotionScale = 0.75f;
    [SerializeField] private Animator _bombsAnimator;
    [SerializeField] private ExplosionEffect _explosionEffect;

    public void DropBomb(Bomb bomb, float speed)
    {
        bomb.transform.parent = null;
        bomb.SetSpeed(speed);
        bomb.TurnOnGravity();
        bomb.SetDroped();
    }

    public Bomb TrySpawnBomb(Wallet wallet)
    {
        Bomb newBomb = null;

        if (wallet.Bombs > 0)
        {
            newBomb = Instantiate(_bombTemplate, _bombStartPosition);
            newBomb.Exploded += OnBombExploded;
        }
        else
        {
            _bombsAnimator.SetTrigger("NoBombs");
        }
        return newBomb;
    }

    public void PlayCollectBombsAnimation()
    {
        _bombsAnimator.SetTrigger("Collected");
    }

    private void OnBombExploded(Bomb bomb)
    {
        bomb.Exploded -= OnBombExploded;
        Handheld.Vibrate();
        StartCoroutine(SlowDownTime(_slowMotionScale, _slowMotionDuration));
        _explosionEffect.PlayExplosionEffect();
    }

    private IEnumerator SlowDownTime(float scale, float duration)
    {
        Time.timeScale *= scale;
        yield return new WaitForSeconds(duration);
        Time.timeScale /= scale;
    }
}
