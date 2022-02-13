using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Doozy.Engine.UI;

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








    #region "���ɵ�ͼ"


    #endregion
}
