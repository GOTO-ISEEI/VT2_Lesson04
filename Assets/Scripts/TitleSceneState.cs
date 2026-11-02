using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;
using static IState;

public class TitleSceneState : BaseSceneState
{
    public override string HudAddress { get; protected set; } = "Assets/Prefabs/TitleHud.prefab";

    private TitleHUDController _hudController;

    private int _score;     // ÉXÉRÉA
    public override async void Enter()
    {
        base.Enter();

        var hudView = new TitleHUDView();
        hudView.Initialize(_hudCanvas.GetComponent<Canvas>());

        _hudController = new TitleHUDController(hudView, this);
    }

    public override void Execute()
    {
        if (Mouse.current != null && Mouse.current.leftButton.wasPressedThisFrame)
        {
            //SceneManager.LoadScene("GameScene");
            _sceneManager.ChangeScene(new GameSceneState());
        }

        base.Execute();
    }

    public void AddScore()
    {
        _score++;
        Debug.Log($"Score: {_score}");
    }
}
