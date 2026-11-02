using System;
using UnityEngine;
using UnityEngine.UI;


public class TitleHUDView
{
    // メンバー
    public Action OnClickButtonAction;  // ボタンクリック時のイベント
    private Button _clickButton;

    public void Initialize(Canvas uiCanvas)
    {
        // UIキャンバスからボタンを取得
        _clickButton = uiCanvas.GetComponentInChildren<Button>();


        if (_clickButton != null)
        {
                _clickButton.onClick.AddListener(OnClickButton);
        }
    }
    
    private void OnClickButton()
    {
        Debug.Log("Buttonがクリックされました");

        OnClickButtonAction?.Invoke();
    }

}
