using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;


namespace Wf_Assist_Cs
{
    #region     ------------  Enum  ------------
    [System.Flags]
    public enum Wf_Enum_Status
    {
        None = 0,
        stop = 1 << 1,
        run = 1 << 2,
        jump = 1 << 3,
        All = 255,
    }

    public enum Wf_Enum_CapNodeType
    {
        front = 0,
        left = -90,
        right = 90,
    }

    public enum Wf_Enum_CapNodeCreateFunction
    {
        system,
        setting,
    }
    #endregion


    #region     ------------  Sturct  ------------------
    [System.Serializable]
    public struct wf_Sturct_GbAndIndex
    {
        [HorizontalGroup("gameObject", MinWidth = 0.2f,MaxWidth = 0.7f,LabelWidth = 40)]
        public GameObject wf_gb;
        [HorizontalGroup("gameObject"), HideLabel]
        public int wf_index;
    }

    [System.Serializable]
    public struct wf_Sturct_CreateCapnode
    {
        [HorizontalGroup("gameObject", MinWidth = 0.2f, MaxWidth = 0.7f, LabelWidth = 40)]
        public Wf_CapNodeItem wf_item;
        [HorizontalGroup("gameObject"), HideLabel]
        public int wf_index;
    }
    #endregion





    #region   ------------  Interfance  ------------------
    interface Wf_I_TestInterface
    {

    }
    #endregion

    #region      ------------  Tools  ------------------
    public class Fw_ToolsFunction
    {
        #region  ----------------  判断是否超出了最大最小范围 --------------------
        public void ToMinMaxGoBack(float value, float min,float max)
        {
            if (value > max)
            {
                value = max;
            }
            else if(value < min)
            {
                value = min;
            }
        }
        public void ToMinMaxGoBack(int value, int min, int max)
        {
            if (value > max)
            {
                value = max;
            }
            else if (value < min)
            {
                value = min;
            }
        }
        #endregion
    }
    #endregion
}