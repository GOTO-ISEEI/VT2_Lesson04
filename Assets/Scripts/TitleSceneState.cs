using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SocialPlatforms.Impl;
using static IState;

public class TitleSceneState : BaseSceneState
{
    public override string HudAddress { get; protected set; } = "Assets/Prefabs/TitleHud.prefab";

    private TitleHUDController _hudController;

    private int _score;
    public int Score { get { return _score; } }

    private int _maxScore = 10;
    public int MaxScore { get { return _maxScore; } }

    public override async void Enter()
    {
        base.Enter();

        var hudView = new TitleHUDView();
        hudView.Initialize(_hudCanvas.GetComponent<Canvas>());

        _hudController = new TitleHUDController(hudView, this);
    }

    public override void Execute()
    {
        if (Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            //SceneManager.LoadScene("GameScene");
            _sceneManager.ChangeScene(new GameSceneState());
        }

        base.Execute();
    }

    public void AddScore()
    {
        _score++;
        Debug.Log($"ÉXÉRÉA: {_score}");
    }
}
