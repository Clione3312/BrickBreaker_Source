using TMPro;
using UnityEngine;
using DG.Tweening;

public class GameScoreScript : MonoBehaviour
{
    [SerializeField, Header("スコア表示")]
    private TextMeshProUGUI scoreText;

    private int score;
    private int previousValue;

    private bool isCountUp;

    private int[] digits;

    // 数字(画像)の位置
    [SerializeField] RectTransform rectScore001;
    [SerializeField] RectTransform rectScore010;
    [SerializeField] RectTransform rectScore100;
    [SerializeField] RectTransform rectScore001k;
    [SerializeField] RectTransform rectScore010k;
    [SerializeField] RectTransform rectScore100k;
    [SerializeField] RectTransform rectScore001m;
    [SerializeField] RectTransform rectScore010m;

    Sequence sequence;

    public void AddScore(int point){
        previousValue = score;
        score += point;

        GameDataScript.Instance._CurrentScore = score;

        if (isCountUp)
        {
            sequence.Kill(true);
        }

        CountUpAnim2();
    }

    private void CountUpAnim(){
        isCountUp = true;
        sequence = DOTween.Sequence()
            .Append(DOTween.To(
                    () => previousValue,
                    num => previousValue = num,
                    score,
                    0.5f
                ))
            .AppendInterval(0.1f)
            .AppendCallback(() => isCountUp = false);
    }

    private int[] GetAllDigits(int num){
        digits = new int[8];    // 8桁

        if (num > 1000000000) return digits;

        for (int i = 0; num > 0; i++)
        {
            int digit = num % 10;
            digits[i] = digit;
            num /= 10;
        }

        return digits;
    }

    private void CountUpAnim2(){
        GetAllDigits(score);

        if (!isCountUp){
            isCountUp = true;
            rectScore001.DOAnchorPosY(1000F, 2.0f)
                .OnComplete(() => {
                    rectScore001.localPosition = new Vector3(180f, 50f, 0f);
                    isCountUp = false;
                });
            rectScore010.DOAnchorPosY(1000f, 1.5f)
                .OnComplete(() => rectScore010.localPosition = new Vector3(130f, 50f, 0f));
                
        } 
        
        rectScore100.DOKill(true);
        switch (digits[2])
        {
            case 0:
                rectScore100.DOAnchorPosY(0, 1f)
                    .OnComplete(() => rectScore100.localPosition = new Vector3(80f, 1050f, 0f));
                break;
            case 1:
                rectScore100.DOAnchorPosY(100,1f)
                    .OnComplete(() => rectScore100.localPosition = new Vector3(80f, 1150, 0f));
                break;
            case 2:
                rectScore100.DOAnchorPosY(200,1f)
                    .OnComplete(() => rectScore100.localPosition = new Vector3(80f, 1250, 0f));
                break;
            case 3:
                rectScore100.DOAnchorPosY(300,1f)
                    .OnComplete(() => rectScore100.localPosition = new Vector3(80f, 1350, 0f));
                break;
            case 4:
                rectScore100.DOAnchorPosY(400,1f)
                    .OnComplete(() => rectScore100.localPosition = new Vector3(80f, 1450, 0f));
                break;
            case 5:
                rectScore100.DOAnchorPosY(500,1f)
                    .OnComplete(() => rectScore100.localPosition = new Vector3(80f, 1550, 0f));
                break;
            case 6:
                rectScore100.DOAnchorPosY(600,1f)
                    .OnComplete(() => rectScore100.localPosition = new Vector3(80f, 1650, 0f));
                break;
            case 7:
                rectScore100.DOAnchorPosY(700,1f)
                    .OnComplete(() => rectScore100.localPosition = new Vector3(80f, 1750, 0f));
                break;
            case 8:
                rectScore100.DOAnchorPosY(800,1f)
                    .OnComplete(() => rectScore100.localPosition = new Vector3(80f, 1850, 0f));
                break;
            case 9:
                rectScore100.DOAnchorPosY(900,1f)
                    .OnComplete(() => rectScore100.localPosition = new Vector3(80f, 1950, 0f));
                break;
        }

        if(score < 1000) return;
        rectScore001k.DOKill(true);
        switch (digits[3])
        {
            case 0:
                rectScore001k.DOAnchorPosY(0, 1f)
                    .OnComplete(() => rectScore001k.localPosition = new Vector3(30f, 1050f, 0f));
                break;
            case 1:
                rectScore001k.DOAnchorPosY(100,1f)
                    .OnComplete(() => rectScore001k.localPosition = new Vector3(30f, 1150, 0f));
                break;
            case 2:
                rectScore001k.DOAnchorPosY(200,1f)
                    .OnComplete(() => rectScore001k.localPosition = new Vector3(30f, 1250, 0f));
                break;
            case 3:
                rectScore001k.DOAnchorPosY(300,1f)
                    .OnComplete(() => rectScore001k.localPosition = new Vector3(30f, 1350, 0f));
                break;
            case 4:
                rectScore001k.DOAnchorPosY(400,1f)
                    .OnComplete(() => rectScore001k.localPosition = new Vector3(30f, 1450, 0f));
                break;
            case 5:
                rectScore001k.DOAnchorPosY(500,1f)
                    .OnComplete(() => rectScore001k.localPosition = new Vector3(30f, 1550, 0f));
                break;
            case 6:
                rectScore001k.DOAnchorPosY(600,1f)
                    .OnComplete(() => rectScore001k.localPosition = new Vector3(30f, 1650, 0f));
                break;
            case 7:
                rectScore001k.DOAnchorPosY(700,1f)
                    .OnComplete(() => rectScore001k.localPosition = new Vector3(30f, 1750, 0f));
                break;
            case 8:
                rectScore001k.DOAnchorPosY(800,1f)
                    .OnComplete(() => rectScore001k.localPosition = new Vector3(30f, 1850, 0f));
                break;
            case 9:
                rectScore001k.DOAnchorPosY(900,1f)
                    .OnComplete(() => rectScore001k.localPosition = new Vector3(30f, 1950, 0f));
                break;
        }


        if(score < 10000) return;
        rectScore010k.DOKill(true);
        switch (digits[4])
        {
            case 0:
                rectScore010k.DOAnchorPosY(0, 1f)
                    .OnComplete(() => rectScore010k.localPosition = new Vector3(-20f, 1050f, 0f));
                break;
            case 1:
                rectScore010k.DOAnchorPosY(100,1f)
                    .OnComplete(() => rectScore010k.localPosition = new Vector3(-20f, 1150, 0f));
                break;
            case 2:
                rectScore010k.DOAnchorPosY(200,1f)
                    .OnComplete(() => rectScore010k.localPosition = new Vector3(-20f, 1250, 0f));
                break;
            case 3:
                rectScore010k.DOAnchorPosY(300,1f)
                    .OnComplete(() => rectScore010k.localPosition = new Vector3(-20f, 1350, 0f));
                break;
            case 4:
                rectScore010k.DOAnchorPosY(400,1f)
                    .OnComplete(() => rectScore010k.localPosition = new Vector3(-20f, 1450, 0f));
                break;
            case 5:
                rectScore010k.DOAnchorPosY(500,1f)
                    .OnComplete(() => rectScore010k.localPosition = new Vector3(-20f, 1550, 0f));
                break;
            case 6:
                rectScore010k.DOAnchorPosY(600,1f)
                    .OnComplete(() => rectScore010k.localPosition = new Vector3(-20f, 1650, 0f));
                break;
            case 7:
                rectScore010k.DOAnchorPosY(700,1f)
                    .OnComplete(() => rectScore010k.localPosition = new Vector3(-20f, 1750, 0f));
                break;
            case 8:
                rectScore010k.DOAnchorPosY(800,1f)
                    .OnComplete(() => rectScore010k.localPosition = new Vector3(-20f, 1850, 0f));
                break;
            case 9:
                rectScore010k.DOAnchorPosY(900,1f)
                    .OnComplete(() => rectScore010k.localPosition = new Vector3(-20f, 1950, 0f));
                break;
        }

        if(score < 100000) return;
        rectScore100k.DOKill(true);
        switch (digits[5])
        {
            case 0:
                rectScore100k.DOAnchorPosY(0, 1f)
                    .OnComplete(() => rectScore100k.localPosition = new Vector3(-70f, 1050f, 0f));
                break;
            case 1:
                rectScore100k.DOAnchorPosY(100,1f)
                    .OnComplete(() => rectScore100k.localPosition = new Vector3(-70f, 1150, 0f));
                break;
            case 2:
                rectScore100k.DOAnchorPosY(200,1f)
                    .OnComplete(() => rectScore100k.localPosition = new Vector3(-70f, 1250, 0f));
                break;
            case 3:
                rectScore100k.DOAnchorPosY(300,1f)
                    .OnComplete(() => rectScore100k.localPosition = new Vector3(-70f, 1350, 0f));
                break;
            case 4:
                rectScore100k.DOAnchorPosY(400,1f)
                    .OnComplete(() => rectScore100k.localPosition = new Vector3(-70f, 1450, 0f));
                break;
            case 5:
                rectScore100k.DOAnchorPosY(500,1f)
                    .OnComplete(() => rectScore100k.localPosition = new Vector3(-70f, 1550, 0f));
                break;
            case 6:
                rectScore100k.DOAnchorPosY(600,1f)
                    .OnComplete(() => rectScore100k.localPosition = new Vector3(-70f, 1650, 0f));
                break;
            case 7:
                rectScore100k.DOAnchorPosY(700,1f)
                    .OnComplete(() => rectScore100k.localPosition = new Vector3(-70f, 1750, 0f));
                break;
            case 8:
                rectScore100k.DOAnchorPosY(800,1f)
                    .OnComplete(() => rectScore100k.localPosition = new Vector3(-70f, 1850, 0f));
                break;
            case 9:
                rectScore100k.DOAnchorPosY(900,1f)
                    .OnComplete(() => rectScore100k.localPosition = new Vector3(-70f, 1950, 0f));
                break;
        }

        if(score < 1000000) return;
        rectScore001m.DOKill(true);
        switch (digits[6])
        {
            case 0:
                rectScore001m.DOAnchorPosY(0, 1f)
                    .OnComplete(() => rectScore001m.localPosition = new Vector3(-120f, 1050f, 0f));
                break;
            case 1:
                rectScore001m.DOAnchorPosY(100,1f)
                    .OnComplete(() => rectScore001m.localPosition = new Vector3(-120f, 1150, 0f));
                break;
            case 2:
                rectScore001m.DOAnchorPosY(200,1f)
                    .OnComplete(() => rectScore001m.localPosition = new Vector3(-120f, 1250, 0f));
                break;
            case 3:
                rectScore001m.DOAnchorPosY(300,1f)
                    .OnComplete(() => rectScore001m.localPosition = new Vector3(-120f, 1350, 0f));
                break;
            case 4:
                rectScore001m.DOAnchorPosY(400,1f)
                    .OnComplete(() => rectScore001m.localPosition = new Vector3(-120f, 1450, 0f));
                break;
            case 5:
                rectScore001m.DOAnchorPosY(500,1f)
                    .OnComplete(() => rectScore001m.localPosition = new Vector3(-120f, 1550, 0f));
                break;
            case 6:
                rectScore001m.DOAnchorPosY(600,1f)
                    .OnComplete(() => rectScore001m.localPosition = new Vector3(-120f, 1650, 0f));
                break;
            case 7:
                rectScore001m.DOAnchorPosY(700,1f)
                    .OnComplete(() => rectScore001m.localPosition = new Vector3(-120f, 1750, 0f));
                break;
            case 8:
                rectScore001m.DOAnchorPosY(800,1f)
                    .OnComplete(() => rectScore001m.localPosition = new Vector3(-120f, 1850, 0f));
                break;
            case 9:
                rectScore001m.DOAnchorPosY(900,1f)
                    .OnComplete(() => rectScore001m.localPosition = new Vector3(-120f, 1950, 0f));
                break;
        }

        if(score < 10000000) return;
        rectScore010m.DOKill(true);
        switch (digits[7])
        {
            case 0:
                rectScore010m.DOAnchorPosY(0, 1f)
                    .OnComplete(() => rectScore010m.localPosition = new Vector3(-170f, 1050f, 0f));
                break;
            case 1:
                rectScore010m.DOAnchorPosY(100,1f)
                    .OnComplete(() => rectScore010m.localPosition = new Vector3(-170f, 1150, 0f));
                break;
            case 2:
                rectScore010m.DOAnchorPosY(200,1f)
                    .OnComplete(() => rectScore010m.localPosition = new Vector3(-170f, 1250, 0f));
                break;
            case 3:
                rectScore010m.DOAnchorPosY(300,1f)
                    .OnComplete(() => rectScore010m.localPosition = new Vector3(-170f, 1350, 0f));
                break;
            case 4:
                rectScore010m.DOAnchorPosY(400,1f)
                    .OnComplete(() => rectScore010m.localPosition = new Vector3(-170f, 1450, 0f));
                break;
            case 5:
                rectScore010m.DOAnchorPosY(500,1f)
                    .OnComplete(() => rectScore010m.localPosition = new Vector3(-170f, 1550, 0f));
                break;
            case 6:
                rectScore010m.DOAnchorPosY(600,1f)
                    .OnComplete(() => rectScore010m.localPosition = new Vector3(-170f, 1650, 0f));
                break;
            case 7:
                rectScore010m.DOAnchorPosY(700,1f)
                    .OnComplete(() => rectScore010m.localPosition = new Vector3(-170f, 1750, 0f));
                break;
            case 8:
                rectScore010m.DOAnchorPosY(800,1f)
                    .OnComplete(() => rectScore010m.localPosition = new Vector3(-170f, 1850, 0f));
                break;
            case 9:
                rectScore010m.DOAnchorPosY(900,1f)
                    .OnComplete(() => rectScore010m.localPosition = new Vector3(-170f, 1950, 0f));
                break;
        }



    }
}
