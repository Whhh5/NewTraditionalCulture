using Doozy.Engine.UI;
using UnityEngine;
using Wf_Item;

public class Wf_FactoryPattern : Wf_SingletonPattern_Mono<Wf_FactoryPattern>
{
    #region Show And Heid ����
    public void ShowPopup(string popupName)
    {
        if (Wf_UIManager.Instance.popups.ContainsKey(popupName))
        {
            return;
        }
        UIPopup tempPopup = null;
        tempPopup = UIPopup.GetPopup(popupName);
        if (tempPopup == null)
        {
            Debug.Log(".......popup �����ڣ����ƴ���.......");
            return;
        }
        Wf_UIManager.Instance.popups.Add(popupName, tempPopup);
        
        tempPopup.Show();
    }

    public void HidePopup(string popupName)
    {
        UIPopup tempPopup = null;
        if (Wf_UIManager.Instance.popups.ContainsKey(popupName))
        {
            tempPopup = Wf_UIManager.Instance.popups[popupName];
            Wf_UIManager.Instance.popups.Remove(popupName);
        }
        else
        {
            Debug.Log(".......popup �����ڣ��޷�����.......");
            return;
        }
        tempPopup.Hide();
    }
    #endregion

    #region Create CapNode

    public Wf_CapNodeController Wf_CarateCapNode(Wf_CapNodeItem item)
    {
        GameObject tempModel = Wf_ObjectPool.Instance.Wf_GetObject(item.wf_model);
        
        tempModel.transform.SetParent(Wf_GameManager.Instance.wf_onLoadScene_Des);

        tempModel.GetComponent<Wf_CapNodeController>().wf_item = item;
        
        Wf_GameManager.Instance.wf_CapNode.Add(tempModel);
            
        return tempModel.GetComponent<Wf_CapNodeController>();
    }
    

    #endregion






    #region "���ɵ�ͼ"


    #endregion
}
