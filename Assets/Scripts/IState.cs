using UnityEngine;

// インターフェースを定義することで記述されているメソッドやプロパティの実装を強制することができる
public interface IState
{
    void Enter();       // 状態の初期処理
    void Execute();     // 状態の繰り返し処理
    void Exit();        // 状態の終了処理
}
