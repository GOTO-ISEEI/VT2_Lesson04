using UnityEngine;

public class TitleHUDController
{
    private TitleHUDView _view;                 // タイトルHUDのビュー
    private TitleSceneState _sceneState;        // タイトルシーンの状態

    // コンストラクタ
    public TitleHUDController(TitleHUDView view, TitleSceneState sceneState)
    {
        _view = view;
        _sceneState = sceneState;

        // ボタンクリック時のイベントを登録
        _view.OnClickButtonAction += OnClickButtonRequest;
    }

    private void OnClickButtonRequest()
    {
        _sceneState.AddScore();
        _view.UpdateScoreText(_sceneState.Score);
        _view.UpdateSliderValue(_sceneState.Score, _sceneState.MaxScore);
    }
}


