using UnityEditor;
using UnityEngine;

// インターフェースを定義することで記述されているメソッドやプロパティの実装を強制することができる
public interface IState
{
    void Enter();       // 状態の初期処理
    void Execute();     // 状態の繰り返し処理
    void Exit();        // 状態の終了処理
}

// 抽象クラスを使用することで共通の処理をまとめることができる
public abstract class BaseSceneState : IState
{
    protected SceneManager _sceneManager;

    // HUDのプレハブのアドレスを入力
    public abstract string HudAddress { get; protected set; }

    public virtual void Enter()
    {
        // 状態の初期処理
        Debug.Log($"{this.GetType().Name}が開始されました");

        _sceneManager = Object.FindAnyObjectByType<SceneManager>();

        // プレハブのロード
        GameObject hudPrefab = AssetDatabase.LoadAssetAtPath<GameObject>(HudAddress);
        GameObject.Instantiate(hudPrefab);
    }
    public virtual void Execute()
    {
        // 状態の繰り返し処理
    }
    public virtual void Exit()
    {
        // 状態の終了処理
        Debug.Log($"{this.GetType().Name}が終了しました");
    }
}

