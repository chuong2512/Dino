using System.Collections;
using System.Collections.Generic;
using ChuongCustom;
using TMPro;
using UnityEngine;


public class TheLevelTMP : Singleton<TheLevelTMP>
{
    public TextMeshProUGUI textMeshProUgui;

    public int point;


    // Start is called before the first frame update
    void Start()
    {
        point = 0;
        textMeshProUgui.SetText($"0");
    }

    public float time = 1;

    void Update()
    {
        if (GameManager.Instance.currentState != State.Playing) return;
        time -= Time.deltaTime;

        if (!(time <= 0)) return;
        Add();
        time = 1;
    }

    private void Add()
    {
        if (GameManager.Instance.currentState != State.Playing) return;
        point++;
        textMeshProUgui.SetText($"{point}");

        ScoreManager.Score = point;
    }
}