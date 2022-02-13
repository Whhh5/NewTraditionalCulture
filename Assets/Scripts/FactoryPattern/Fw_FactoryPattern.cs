using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Doozy.Engine.UI;

public class Fw_FactoryPattern : Wf_SingletonPattern_Mono<Fw_FactoryPattern>
{
    #region Show And Heid 弹窗
    public void ShowPopup(string popupName)
    {
        if (Fw_UIManager.Instance.popups.ContainsKey(popupName))
        {
            return;
        }
        UIPopup tempPopup = null;
        tempPopup = UIPopup.GetPopup(popupName);
        if (tempPopup == null)
        {
            Debug.Log(".......popup 不存在，名称错误.......");
            return;
        }
        Fw_UIManager.Instance.popups.Add(popupName, tempPopup);
        
        tempPopup.Show();
    }

    public void HidePopup(string popupName)
    {
        UIPopup tempPopup = null;
        if (Fw_UIManager.Instance.popups.ContainsKey(popupName))
        {
            tempPopup = Fw_UIManager.Instance.popups[popupName];
            Fw_UIManager.Instance.popups.Remove(popupName);
        }
        else
        {
            Debug.Log(".......popup 不存在，无法隐藏.......");
            return;
        }
        tempPopup.Hide();
    }
    #endregion








    #region "生成地图"


    #endregion
}
