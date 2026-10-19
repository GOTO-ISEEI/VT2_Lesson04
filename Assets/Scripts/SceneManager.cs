using UnityEngine;

public class SceneManager : MonoBehaviour
{
    private IState _currentSceneState;      // 現在実行中のシーン

    void Start()
    {
        DontDestroyOnLoad(gameObject);                  // シーン遷移時に破棄されないようにする

        _currentSceneState = new TitleSceneState();     // 初期状態をタイトルシーンに設定
        _currentSceneState .Enter();                    // タイトルシーンのEnterメソッドを呼び出す
    }

    void Update()
    {
        _currentSceneState.Execute();                   // 現在のシーンのExecuteメソッドを呼び出す
    }

    public void ChangeScene(IState nextScene)
    {
        _currentSceneState.Exit();                      // 現在のシーンのExitメソッドを呼び出す
        _currentSceneState = nextScene;
        _currentSceneState.Enter();                     // 次のシーンのEnterメソッドを呼び出す
    }

    public static void LoadScene(string sceneName)
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(sceneName);      // 指定されたシーンをロードする
    }
}
