using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;
using UnitySceneManager = UnityEngine.SceneManagement.SceneManager;

public class ResultSceneState : BaseSceneState
{
    public override string HudAddress { get; protected set; } = "Assets/Prefabs/ResultHud.prefab";

    public override void Enter()
    {
        base.Enter();

        SceneManager.LoadScene("ResultScene");
    }

    public override void Execute()
    {
        if (Mouse.current != null && Mouse.current.leftButton.wasPressedThisFrame)
        {
            _sceneManager.ChangeScene(new TitleSceneState());
        }

        base.Execute();
    }
}
