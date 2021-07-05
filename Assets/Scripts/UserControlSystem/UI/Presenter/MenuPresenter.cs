using UnityEngine;
using UnityEngine.UI;
using UniRx;

public class MenuPresenter : MonoBehaviour
{
	[SerializeField] private Button _backButton;
	[SerializeField] private Button _exitButton;

	private void Start()
	{
		_backButton.OnClickAsObservable().Subscribe(_ => gameObject.SetActive(false));
		_exitButton.OnClickAsObservable().Subscribe(_ => Application.Quit());
	}

    private void OnEnable()
    {
		Time.timeScale = 0;
    }

    private void OnDisable()
    {
		Time.timeScale = 1;
    }
}
