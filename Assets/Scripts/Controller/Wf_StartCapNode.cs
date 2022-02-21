using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Wf_StartCapNode : MonoBehaviour
{
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            Wf_Exit();
        }
    }

    private void Wf_Exit()
    {
        transform.DOMove(transform.position + Wf_GameManager.Instance.wf_capAnimationStartPos,
            Wf_GameManager.Instance.wf_capMoveTime, false)
            .OnComplete((() =>
            {
                Wf_ObjectPool.Instance.Wf_RemoveObject(gameObject);
            }));
    }
}
