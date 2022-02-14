using System.Collections;
using UnityEngine;
using Wf_Item;

public class Wf_Create : MonoBehaviour
{
    private void Start()
    {
        var tempSc = Wf_GameManager.Instance;
        StartCoroutine(X_CreateCapNode(tempSc.wf_capNumber, tempSc.wf_capIntervalTime, tempSc.wf_capAnimationStartPos, tempSc.wf_capMoveTime));
    }

    IEnumerator X_CreateCapNode(int number,float intervalTime,Vector3 animationStartPos,float moveTime)
    {
        for (int i = 0; i < number; i++)
        {
            Wf_CapNodeItem tempIndex = Wf_GameManager.Instance.wf_capNodeItems[(int)Random.Range(0, Wf_GameManager.Instance.wf_capNodeItems.Count)];
            Wf_CapNodeController tempController = Wf_FactoryPattern.Instance.Wf_CarateCapNode(tempIndex);
            if (Wf_GameManager.Instance.wf_CapNode.Count == 1)
            {
                tempController.Wf_Initialization(Wf_GameManager.Instance.wf_fistPos.position,Wf_GameManager.Instance.wf_fistPos.rotation.eulerAngles);
            }
            else
            {
                Wf_CapNodeController tempGb = Wf_GameManager.Instance.wf_CapNode[Wf_GameManager.Instance.wf_CapNode.Count - 2].GetComponent<Wf_CapNodeController>();
                tempController.Wf_Initialization(tempGb.wf_endPos,tempGb.wf_endRot);
            }
            tempController.Wf_Move(animationStartPos,moveTime);
            
            yield return new WaitForSeconds(intervalTime);
        }
    }
}
