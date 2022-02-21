using System.Collections;
using UnityEngine;
using System.Collections.Generic;
using Wf_Assist_Cs;
using Sirenix.OdinInspector;

public class Wf_Create : MonoBehaviour
{
    [Title("选择生成方式")]
    [EnumToggleButtons, HideLabel]
    public Wf_Enum_CapNodeCreateFunction createFunction;
    public List<wf_Sturct_CreateCapnode> caps = new List<wf_Sturct_CreateCapnode>();

    List<int> idiomIndex = new List<int>();
    bool isrunningIdiom = false;
    Coroutine tempCorIdiom;
    private void Start()
    {
        for (int i = 0; i < Wf_GameManager.Instance.wf_idiom.idiom.Count; i++)
        {
            idiomIndex.Add(i);
        }

        switch (createFunction)
        {
            case Wf_Enum_CapNodeCreateFunction.system:
                StartCoroutine(X_CreateCapNode(Wf_GameManager.Instance.wf_capNumber, Wf_GameManager.Instance.wf_capIntervalTime, Wf_GameManager.Instance.wf_capAnimationStartPos, Wf_GameManager.Instance.wf_capMoveTime));
                break;
            case Wf_Enum_CapNodeCreateFunction.setting:
                StartCoroutine(X_SysttemCreateCapNode(Wf_GameManager.Instance.wf_capIntervalTime, Wf_GameManager.Instance.wf_capAnimationStartPos, Wf_GameManager.Instance.wf_capMoveTime));
                break;
            default:
                break;
        }
    }

    #region 生成地图
    IEnumerator X_CreateCapNode(int number,float intervalTime,Vector3 animationStartPos,float moveTime)
    {
        for (int i = 0; i < number; i++)
        {
            Wf_CapNodeItem tempIndex = Wf_GameManager.Instance.wf_capNodeItems[Random.Range(0, Wf_GameManager.Instance.wf_capNodeItems.Count)];
            for (int j = 0; j < Wf_GameManager.Instance.wf_capNodeItems.Count; j++)
            {
                if (tempIndex.wf_type == Wf_Assist_Cs.Wf_Enum_CapNodeType.left || tempIndex.wf_type == Wf_Assist_Cs.Wf_Enum_CapNodeType.right)
                {
                    tempIndex = Wf_GameManager.Instance.wf_capNodeItems[Random.Range(0, Wf_GameManager.Instance.wf_capNodeItems.Count)];
                }
                else
                {
                    break;
                }
            }
            Wf_CapNodeController tempController = Wf_FactoryPattern.Instance.Wf_CarateCapNode(tempIndex);
            if (Wf_GameManager.Instance.wf_capNode.Count == 1)
            {
                tempController.Wf_Initialization(Wf_GameManager.Instance.wf_fistPos.position,Wf_GameManager.Instance.wf_fistPos.rotation.eulerAngles);
                tempController.gameObject.GetComponent<BoxCollider>().enabled = true;
            }
            else
            {
                Wf_CapNodeController tempGb = Wf_GameManager.Instance.wf_capNode[Wf_GameManager.Instance.wf_capNode.Count - 2].GetComponent<Wf_CapNodeController>();
                tempController.Wf_Initialization(tempGb.wf_endPos,tempGb.wf_endRot);
            }
            tempController.Wf_Move(animationStartPos,moveTime);
            
            yield return new WaitForSeconds(intervalTime);
        }
    }

    IEnumerator X_SysttemCreateCapNode(float intervalTime, Vector3 animationStartPos, float moveTime)
    {
        for (int i = 0; i < caps.Count; i++)
        {
            for (int j = 0; j < caps[i].wf_index; j++)
            {
                Wf_CapNodeController tempController = Wf_FactoryPattern.Instance.Wf_CarateCapNode(caps[i].wf_item);
                if (Wf_GameManager.Instance.wf_capNode.Count == 1)
                {
                    tempController.Wf_Initialization(Wf_GameManager.Instance.wf_fistPos.position, Wf_GameManager.Instance.wf_fistPos.rotation.eulerAngles);
                    tempController.gameObject.GetComponent<BoxCollider>().enabled = true;
                }
                else
                {
                    Wf_CapNodeController tempGb = Wf_GameManager.Instance.wf_capNode[Wf_GameManager.Instance.wf_capNode.Count - 2].GetComponent<Wf_CapNodeController>();
                    tempController.Wf_Initialization(tempGb.wf_endPos, tempGb.wf_endRot);
                }
                tempController.Wf_Move(animationStartPos, moveTime);

                yield return new WaitForSeconds(intervalTime);
            }
        }
    }
    #endregion


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha6))
        {
            StartIdiomCro();
        }
    }


    public void StartIdiomCro()
    {
        if (isrunningIdiom)
        {
            StopCoroutine(tempCorIdiom);
        }
        tempCorIdiom = StartCoroutine(X_CreateIdiom(Wf_GameManager.Instance.wf_idiom));
    }
    #region

    private IEnumerator X_CreateIdiom(Wf_IdiomItem item)
    {
        isrunningIdiom = true;
        for (int i = 0; i < Wf_UIManager.Instance.wf_idiomParent.transform.childCount; i++)
        {
            Wf_ObjectPool.Instance.Wf_RemoveObject(Wf_UIManager.Instance.wf_idiomParent.transform.GetChild(i).gameObject);
        }
        if (idiomIndex.Count != 0)
        {
            int tempRamdom = Random.Range(0, idiomIndex.Count);
            int tempInt = tempRamdom;
            tempRamdom = idiomIndex[tempRamdom];
            idiomIndex.Remove(idiomIndex[tempInt]);
            for (int i = 0; i < idiomIndex.Count; i++)
            {
                Debug.Log(idiomIndex[i]);
            }

            int tempRan = Random.Range(0, item.idiom[tempRamdom].Length);
            for (int i = 0; i < item.idiom[tempRamdom].Length; i++)
            {
                if (i != tempRan)
                {
                    Wf_FactoryPattern.Instance.Wf_CarateIdiom(item).text = item.idiom[tempRamdom].Substring(i);
                }
                else
                {
                    Wf_FactoryPattern.Instance.Wf_CarateIdiom(item).text = "";
                }

                yield return new WaitForSeconds(0.3f);
            }
        }
        
        isrunningIdiom = false;
        StopCoroutine(X_CreateIdiom(Wf_GameManager.Instance.wf_idiom));
    }

    #endregion
}
