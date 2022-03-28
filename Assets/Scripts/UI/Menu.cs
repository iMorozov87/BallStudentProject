using UnityEngine;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    [SerializeField] private Button _newGameButton;
    [SerializeField] private Button _creatorsButton;
    [SerializeField] private Button _exitButton;
    [SerializeField] private UIPanelAnimator _creatorsPanel;
    [SerializeField] private NewGameLoader _newGameLoader;

    private void OnEnable()
    {
        _newGameButton.onClick.AddListener(OnNewButtonClick);
        _creatorsButton.onClick.AddListener(OnCreatorsButtonClick);
        _exitButton.onClick.AddListener(OnExitButtonClick);
    }

    private void OnDisable()
    {
        _newGameButton.onClick.RemoveListener(OnNewButtonClick);
        _creatorsButton.onClick.RemoveListener(OnCreatorsButtonClick);
        _exitButton.onClick.RemoveListener(OnExitButtonClick);
    }

    private void OnNewButtonClick()
    {
        _newGameLoader.Load();
    }

    private void OnCreatorsButtonClick()
    {
        _creatorsPanel.Open();
    }

    private void OnExitButtonClick()
    {
        Application.Quit();
    }
}
