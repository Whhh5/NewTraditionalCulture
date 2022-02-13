using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;
using Wf_Assist_Cs;

public class Fw_GameManager : Wf_SingletonPattern_Mono<Fw_GameManager>
{
    [TitleGroup("PlayerDate")]
    [HorizontalGroup("PlayerDate/Group_1", Width = 0.5f, LabelWidth = 50)]
    [TabGroup("PlayerDate/Group_1/Group_1", "A")]
    public Transform Tr1, Tr2, Tr3;

    [TabGroup("PlayerDate/Group_1/Group_1", "B")]
    public string n1, n2, n3;

    [HorizontalGroup("PlayerDate/Group_1",0.5f, LabelWidth = 50)]
    [TabGroup("PlayerDate/Group_1/Group_2", "×é¼þ")]
    public Transform Tr21, Tr22, Tr23;

    [TabGroup("PlayerDate/Group_1/Group_2", "CS")]
    public string n21, n22, n23;




    [TitleGroup("PlayerDate2")]
    [HorizontalGroup("PlayerDate2/Group_1", Width = 0.5f, LabelWidth = 50)]
    [TabGroup("PlayerDate2/Group_1/Group_1", "A")]
    public Transform Tr31, Tr32, Tr33;

    [TabGroup("PlayerDate2/Group_1/Group_1", "B")]
    public string n31, n32, n33;

    [HorizontalGroup("PlayerDate2/Group_1", LabelWidth = 50)]
    [TabGroup("PlayerDate2/Group_1/Group_2", "A")]
    public Transform Tr231, Tr232, Tr233;

    [TabGroup("PlayerDate2/Group_1/Group_2", "B")]
    public string n231, n232, n233;




    [TitleGroup("PlayerDate3")]
    [HorizontalGroup("PlayerDate3/Group_1")]
    [TabGroup("PlayerDate3/Group_1/Group_1", "A")]
    [MinMaxSlider(-10, 10,true)]
    public Vector2 minMaxValueSlider = new Vector2();

    [TitleGroup("PlayerDate3")]
    [HorizontalGroup("PlayerDate3/Group_1")]
    [TabGroup("PlayerDate3/Group_1/Group_1", "A")]
    [Wrap(0, 10)]
    public float number1 = 0;


    [TitleGroup("PlayerDate4")]
    [HorizontalGroup("PlayerDate4/Group_1")]
    [TabGroup("PlayerDate4/Group_1/Group_1", "A")]
    public Wf_Enum_Status tempEnum1;
}
