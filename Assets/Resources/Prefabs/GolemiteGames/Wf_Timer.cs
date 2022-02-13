using System;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using System.Collections;
using UnityEditor;


public class Wf_Timer : MonoBehaviour
{
    [SerializeField]
    private Text text;
    [SerializeField] 
    private Image slider;
    [SerializeField]
    private Vector3 startPositin;
    [SerializeField]
    private float maxTime;

    private float _residueTime;
    bool isRun = false;

    private void Start()
    {
        gameObject.SetActive(false);
    }

    private float residueTime
    {
        get
        {
            return _residueTime;
        }
        set
        {
            if (value < 0)
            {
                value = 0;
            }
            else if(value > maxTime)
            {
                value = maxTime;
            }
            _residueTime = value;


            if (slider != null)
            {
                slider.fillAmount = _residueTime / maxTime;
            }
            if (text != null)
            {
                text.text = value.ToString("#0.0 ");
            }
        }
    }

    public void StartTime(float maxTime,Vector3 pos)
    {
        gameObject.SetActive(true);
        DOTween.To(x => GetComponent<CanvasGroup>().alpha = x, 0f, 1, 1f);
        RectTransform tempTrans = GetComponent<RectTransform>();
        tempTrans.anchoredPosition = pos;
        residueTime = this.maxTime = maxTime;
        if (isRun)
        {
            StopCoroutine("X_BeginTime");
            isRun = false;
        }
        StartCoroutine("X_BeginTime");
    }

    //计时器
    IEnumerator X_BeginTime()
    {
        isRun = true;
        for (int i = 0; residueTime > 0;i++)
        {
            residueTime -= Time.deltaTime;
            yield return new WaitForSeconds(0);
        }
        isRun = false;
        StopCoroutine("X_BeginTime");
        Cancel();
    }

    //隐藏
    public void Cancel()
    {
        if (isRun)
        {
            StopCoroutine("X_BeginTime");
            isRun = false;
        }
        DOTween.To(x => GetComponent<CanvasGroup>().alpha = x, 1f, 0, 1f)
                .OnComplete((() =>
                {
                    gameObject.SetActive(false);
                }
                ));
    }

    private void OnDisable()
    {
        if (isRun)
        {
            StopCoroutine("X_BeginTime");
            isRun = false;
        }
    }
}
