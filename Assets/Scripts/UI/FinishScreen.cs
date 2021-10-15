using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using IJunior.TypedScenes;

public class FinishScreen : MonoBehaviour
{
    [SerializeField] private int _nextSceneId;
    [SerializeField] private GameObject _claimButton;
    [SerializeField] private float _claimButtonDelay;
    [SerializeField] private Wallet _wallet;
    [SerializeField] private GameSaver _gameSaver;

    private void Start()
    {
        StartCoroutine(SetActiveClaimButtonWithDelay());
    }

    public void LoadNextScene()
    {
        _gameSaver.Save();
        switch (_nextSceneId)
        {
            case 0: 
                Level_1.Load(_wallet.Crystals);
                break;
            case 1:
                Level_2.Load(_wallet.Crystals);
                break;
            default:
                break;
        }
    }

    private IEnumerator SetActiveClaimButtonWithDelay()
    {
        yield return new WaitForSeconds(_claimButtonDelay);
        _claimButton.SetActive(true);
    }
}
