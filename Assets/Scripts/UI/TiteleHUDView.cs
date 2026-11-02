using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class TitleHUDView
{
    // メンバー
    public Action OnClickButtonAction;      // ボタンクリック時のイベント
    private Button _clickButton;
    private TextMeshProUGUI _scoreText;     // スコア表示用のテキスト

    private Slider _slider;                 // スライダーの参照

    public void Initialize(Canvas uiCanvas)
    {
        // UIキャンバスからボタンを取得
        _clickButton = uiCanvas.GetComponentInChildren<Button>();

        GameObject obj = GameObject.Find("Value");

        TextMeshProUGUI[] textObjects = uiCanvas.GetComponentsInChildren<TextMeshProUGUI>();
        foreach (var text in textObjects)
        {
            if (text.name == "Value")
            {
                _scoreText = text;
                break;
            }
        }

        Slider[] sliders = uiCanvas.GetComponentsInChildren<Slider>();
        foreach (var slider in sliders)
        {
            if (slider.name == "Slider")
            {
                _slider = slider;
                break;
            }
        }

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

    public void UpdateScoreText(int score)
    {
        if (_scoreText != null)
        {
            _scoreText.text = $"Score: {score}";
        }
    }

    public void UpdateSliderValue(float value, int max)
    {
        if (_slider != null)
        {
            _slider.value = (value % max) / max;
        }
    }
}
