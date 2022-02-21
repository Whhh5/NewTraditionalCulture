using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Sirenix.OdinInspector;
using Wf_Assist_Cs;
using Doozy.Engine.UI;
using DG.Tweening;
using System;

public class Test : MonoBehaviour
{
    public int number = 5;

    [Title("Default")]
    public SomeBitmaskEnum DefaultEnumBitmask;

    [Title("Standard Enum")]
    [EnumToggleButtons]
    public SomeEnum SomeEnumField;

    [EnumToggleButtons, HideLabel]
    public SomeEnum WideEnumField;

    [Title("Bitmask Enum")]
    [EnumToggleButtons]
    public SomeBitmaskEnum BitmaskEnumField;

    [EnumToggleButtons, HideLabel]
    public SomeBitmaskEnum EnumFieldWide;

    public enum SomeEnum
    {
        First, Second, Third, Fourth, AndSoOn
    }

    [System.Flags]
    public enum SomeBitmaskEnum
    {
        A = 1 << 1,
        B = 1 << 2,
        C = 1 << 3,
        All = A | B | C
    }



    [HorizontalGroup]
    public int A;

    public UIPopup ui1;

    //[HideLabel, LabelWidth(150)]
    //[HorizontalGroup(150)]
    //public LayerMask B;

    //// LabelWidth can be helpfull when dealing with HorizontalGroups.
    //[HorizontalGroup("Group 1", LabelWidth = 20)]
    //public int C;

    //[HorizontalGroup("Group 1")]
    //public int D;

    //[HorizontalGroup("Group 1")]
    //public int E;

    //// Having multiple properties in a column can be achived using multiple groups. Checkout the "Combining Group Attributes" example.
    //[HorizontalGroup("Split", 0.5f, LabelWidth = 20)]
    //[BoxGroup("Split/Left")]
    //public int L;

    //[BoxGroup("Split/Right")]
    //public int M;

    //[BoxGroup("Split/Left")]
    //public int N;

    //[BoxGroup("Split/Right")]
    //public int O;

    //// Horizontal Group also has supprot for: Title, MarginLeft, MarginRight, PaddingLeft, PaddingRight, MinWidth and MaxWidth.
    //[HorizontalGroup("MyButton", MarginLeft = 0.25f, MarginRight = 0.25f)]
    //public void SomeButton()
    //{
    //    // ...

    //}

    List<int> inn = new List<int>();
    private void Start()
    {
        //Debug.Log(Time.timeScale);
        //Time.timeScale = 0;
        //Debug.Log(Time.timeScale);

        for (int i = 0; i < 5; i++)
        {
            inn.Add(i);
        }
    }



    void Update()
    {
        if (Input.GetKey(KeyCode.Alpha1))
        {
            //Wf_Tools.Instance.my_Timer.gameObject.SetActive(true);
            Wf_Tools.Instance.my_Timer.StartTime(10, Wf_Tools.Instance.my_Timer.gameObject.GetComponent<RectTransform>().anchoredPosition);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            Wf_FactoryPattern.Instance.ShowPopup("Start Setting");
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            Wf_FactoryPattern.Instance.ShowPopup("Gaming Setting");
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            Wf_FactoryPattern.Instance.HidePopup("Start Setting");
        }
        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            Wf_FactoryPattern.Instance.HidePopup("Gaming Setting");
        }
        if (Input.GetKeyDown(KeyCode.Alpha6))
        {
            
        }
        if (Input.GetKeyDown(KeyCode.Alpha7))
        {
            int temp = UnityEngine.Random.Range(0, 2);

            Debug.Log(UnityEngine.Random.Range(0, 2));
        }
    }
}
