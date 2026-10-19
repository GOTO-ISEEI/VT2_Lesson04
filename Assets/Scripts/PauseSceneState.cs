using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;
using UnitySceneManager = UnityEngine.SceneManagement.SceneManager;

public class PauseSceneState : BaseSceneState
{
    public override string HudAddress { get; protected set; } = "Assets/Prefabs/PauseHud.prefab";

    public override void Enter()
    {
        base.Enter();

        SceneManager.LoadScene("PauseScene");
    }
    public override void Execute()
    {
        if (Keyboard.current.escapeKey.wasPressedThisFrame)
        {
            _sceneManager.ChangeScene(new GameSceneState());
        }
    }
}
