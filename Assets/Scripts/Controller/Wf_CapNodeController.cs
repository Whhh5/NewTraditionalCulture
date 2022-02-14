using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using Unity.Mathematics;
using UnityEngine;
using Wf_Item;

public class Wf_CapNodeController : MonoBehaviour
{
    public Wf_CapNodeItem wf_item;
    public Vector3 wf_pos;
    public Vector3 wf_endPos;
    public Vector3 wf_endRot;

    public void Wf_Initialization(Vector3 targetPos,Vector3 targetRot)
    {
        //设置位置
        var tempStartPosition = transform.Find("Start Position");
        var tempEndPosition = transform.Find("End Position");
        transform.rotation = Quaternion.Euler(targetRot);
        var tempPos1 = transform.position - tempStartPosition.position;
        tempStartPosition.position = targetPos;
        transform.position = tempStartPosition.position + tempPos1;
        tempStartPosition.position = transform.position - tempPos1;


        wf_pos = transform.position;
        wf_endPos = tempEndPosition.position;
        wf_endRot = tempEndPosition.rotation.eulerAngles;
    }

    public void Wf_Move(Vector3 pos,float time)
    {
        var tempPos = transform.position;
        transform.position += pos;
        transform.DOMove(tempPos, time, false);
    }

    private void OnEnable()
    {
        if (GetComponent<BoxCollider>().enabled != true)
        {
            GetComponent<BoxCollider>().enabled = true;
        }
    }

    private void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Wf_Enter();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            Wf_Exit();
        }
    }

    private void Wf_Enter()
    {
        
    }
    private void Wf_Exit()
    {
        GetComponent<BoxCollider>().enabled = false;
        transform.DOMove(transform.position - Wf_GameManager.Instance.wf_capAnimationStartPos,
            Wf_GameManager.Instance.wf_capMoveTime, false)
            .OnComplete((()=>
        {
            Wf_ObjectPool.Instance.Wf_RemoveObject(gameObject);
        }));
        
        Debug.Log("2");
    }
    
}
