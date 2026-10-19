using UnityEngine;
using UnityEngine.InputSystem;

public class TitleSceneState : MonoBehaviour, IState
{
    private SceneManager _sceneManager;

    void Start()
    {
        SceneManager.LoadScene("TitleScene");
    }

    void IState.Enter()
    {
        // 状態の初期処理
        Debug.Log($"{this.GetType().Name}が開始されました");
        _sceneManager = Object.FindAnyObjectByType<SceneManager>();
    }

    void IState.Execute()
    {
        if (Mouse.current.leftButton.wasPressedThisFrame)
        {
            _sceneManager.ChangeScene(new GameSceneState());
        }
    }

    void IState.Exit()
    {
        // 状態の終了処理
        Debug.Log($"{this.GetType().Name}が終了しました");
    }
}
