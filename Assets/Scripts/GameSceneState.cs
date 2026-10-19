using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;
using UnitySceneManager = UnityEngine.SceneManagement.SceneManager;

public class GameSceneState : BaseSceneState
{
    public override string HudAddress { get; protected set; } = "Assets/Prefabs/GameHud.prefab";

    public override void Enter()
    {
        base.Enter();

        SceneManager.LoadScene("GameScene");
    }
    public override void Execute()
    {
        if (Mouse.current != null && Mouse.current.leftButton.wasPressedThisFrame)
        {
            _sceneManager.ChangeScene(new ResultSceneState());
        }

        if (Keyboard.current != null && Keyboard.current.escapeKey.wasPressedThisFrame)
        {
            _sceneManager.ChangeScene(new PauseSceneState());
        }

        base.Execute();
    }
}
