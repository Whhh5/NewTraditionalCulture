using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;
using Wf_Assist_Cs;

[CreateAssetMenu(fileName = "New CapNodeItem", menuName = "Inventory/New CapNodeItem")]
public class Wf_CapNodeItem : ScriptableObject
{
    [EnumToggleButtons, HideLabel]
    public Wf_Enum_CapNodeType wf_type;

    public string wf_name = "";

    public GameObject wf_model;

    public Transform wf_startTr;
    public Transform wf_endTr;

    [TextArea]
    public string wf_information;

}
