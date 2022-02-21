using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;
using Wf_Assist_Cs;

[CreateAssetMenu(fileName = "New ChildLevelItem", menuName = "Inventory/New ChildLevelItem")]
public class Wf_ChildLevelItem : ScriptableObject
{
    [TitleGroup("��ͼ")]
    public List<GameObject> wf_capnodes = new List<GameObject>();

    [TitleGroup("����")]
    public List<wf_Sturct_GbAndIndex> wf_posps = new List<wf_Sturct_GbAndIndex>();
}
