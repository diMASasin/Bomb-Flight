using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using IJunior.TypedScenes;

public class FinishScreen : MonoBehaviour
{
    [SerializeField] private int _nextSceneId;
    [SerializeField] private GameObject _claimButton;
    [SerializeField] private GameObject _claimX2Button;
    [SerializeField] private float _claimButtonDelay;
    [SerializeField] private Wallet _wallet;
    [SerializeField] private GameSaver _gameSaver;
    [SerializeField] private Animator _claimButtonAnimator;
    [SerializeField] private Animator _claimX2ButtonAnimator;

    private void Start()
    {
        _claimButton.transform.localScale = Vector3.zero;
        _claimButtonAnimator.SetTrigger("Pop-up");
        StartCoroutine(SetActiveClaimButtonWithDelay());
    }

    public void LoadNextScene()
    {
        _gameSaver.Save();
        switch (_nextSceneId)
        {
            case 0: 
                Level_1.Load();
                break;
            case 1:
                Level_2.Load();
                break;
            default:
                break;
        }
    }

    private IEnumerator SetActiveClaimButtonWithDelay()
    {
        yield return new WaitForSeconds(_claimButtonDelay);
        _claimX2Button.transform.localScale = Vector3.zero;
        _claimX2ButtonAnimator.SetTrigger("Pop-up");
        _claimButton.SetActive(true);
    }
}
