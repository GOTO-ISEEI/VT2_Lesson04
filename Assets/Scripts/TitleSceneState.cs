using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;
using static IState;

public class TitleSceneState : BaseSceneState
{
    public override string HudAddress { get; protected set; } = "Assets/Prefabs/TitleHud.prefab";

    public override async void Enter()
    {
        base.Enter();

        SceneManager.LoadScene("TitleScene");
    }

    public override void Execute()
    {
        if (Mouse.current != null && Mouse.current.leftButton.wasPressedThisFrame)
        {
            _sceneManager.ChangeScene(new GameSceneState());
        }

        base.Execute();
    }
}
