using UnityEngine;

public class SceneManager : MonoBehaviour
{
    public static SceneManager Instance { get; private set; }       // シングルトンインスタンス
    private IState _currentSceneState;      // 現在実行中のシーン

    void Awake()
    {
        // SceneManagerが存在しているかチェック
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    void Start()
    {
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
