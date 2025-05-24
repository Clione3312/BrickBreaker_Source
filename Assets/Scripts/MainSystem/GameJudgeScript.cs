using System;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class GameJudgeScript : MonoBehaviour
{
    [SerializeField, Header("時間システム")]
    private TimeCountScript timeCount;

    [SerializeField, Header("リザルト画面")]
    private ResultSocreScript result;

    [SerializeField, Header("リザルト画面")]
    private GameOverScript gameOver;

    [SerializeField, Header("ゲームオブジェクト")]
    private GameObject PlayerPaddle;

    [SerializeField, Header("Audio Source")]
    private AudioSource bgm;

    private const string GAME_CLEAR = "Game Clear";
    private const string GAME_OVER = "Game Over";
    
    private bool boolBGMDestroy;

    // Update is called once per frame
    void Update()
    {
        if(!GameDataScript.Instance._GameClear && !GameDataScript.Instance._GameOver) {
            if (IsExistsBlock() && !GameDataScript.Instance._GameClear ) {
                GameDataScript.Instance._GameClear = true;
                ShowResult(GAME_CLEAR);
            }

            if (IsNotRestLife() && !GameDataScript.Instance._GameOver) {
                GameDataScript.Instance._GameOver = true;
                ShowResult(GAME_OVER);
            }
        }
    }

    private bool IsNotRestLife(){
        return GameObject.FindGameObjectsWithTag("Block").Length > 0 && GameDataScript.Instance._PlayerLife < 0;
    }

    private bool IsExistsBlock(){
        return GameObject.FindGameObjectsWithTag("Block").Length == 0 && GameDataScript.Instance._PlayerLife >= 0;
    }

    private void ShowResult(String _mode) {
        switch (_mode)
        {
            case GAME_CLEAR: 
                GameDataScript.Instance.BGMStop();

                timeCount._tStop();
                DisaictiveGameObject();
                result.gameObject.SetActive(true);
                result.Animate();
                break;
                
            case GAME_OVER: 
                GameDataScript.Instance.BGMStop();

                timeCount._tStop();
                DisaictiveGameObject();
                gameOver.gameObject.SetActive(true);
                gameOver.FadeIn();
                break;
        }


    }

    private void DisaictiveGameObject(){
        // GameObject playerPaddle = GameObject.FindGameObjectWithTag("Player");
        PlayerPaddle.SetActive(false);

        GameObject[] balls = GameObject.FindGameObjectsWithTag("Ball");
        foreach (var item in balls) { item.SetActive(false); }

        GameObject[] Items = GameObject.FindGameObjectsWithTag("Item");
        foreach (var item in Items) { item.SetActive(false); }
    }
}
