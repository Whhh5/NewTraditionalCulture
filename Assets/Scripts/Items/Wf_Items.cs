using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using Sirenix.OdinInspector;
using Wf_Assist_Cs;


namespace Wf_Item
{
    [CreateAssetMenu(fileName = "New CapNodeItem", menuName = "Inventory/New CapNodeItem")]
    public class Wf_CapNodeItem : ScriptableObject
    {
        [EnumToggleButtons, HideLabel]
        public Wf_Enum_CapNodeType wf_type;

        public string wf_name = "";

        public GameObject wf_model;

        [TextArea]
        public string wf_information;

    }
    [CreateAssetMenu(fileName = "New PlayerPropertyItem", menuName = "Inventory/New PlayerPropertyItem")]
    public class Wf_PlayerPropertyItem : ScriptableObject
    {
        public string wf_name = "";
        public float wf_maxBlood = 100;

        public float wf_harm = 0;
        public float wf_defense = 0;

        public float wf_moveSpeed = 0;
        public float wf_jumpHeight = 0;
        public float wf_rotationSpeed = 0;

        [TextArea]
        public string wf_information;
    }
    [CreateAssetMenu(fileName = "New MinEnemyItem", menuName = "Inventory/New MinEnemyItem")]
    public class Wf_MinEnemyItem : ScriptableObject
    {
        public string wf_name = "";
        public float wf_maxBlood = 100;

        public float wf_harm = 0;
        public float wf_defense = 0;

        public float wf_moveSpeed = 0;
        public float wf_jumpHeight = 0;
        public float wf_rotationSpeed = 0;

        [TextArea]
        public string wf_information;
    }

    [CreateAssetMenu(fileName = "New MainLevelItem", menuName = "Inventory/New MainLevelItem")]
    public class Wf_MainLevelItem : ScriptableObject
    {
        public int wf_EndLevel = 0;
    }

    [CreateAssetMenu(fileName = "New ChildLevelItem", menuName = "Inventory/New ChildLevelItem")]
    public class Wf_ChildLevelItem : ScriptableObject
    {
        [TitleGroup("µØÍ¼")]
        public List<GameObject> wf_capnodes = new List<GameObject>();

        [TitleGroup("µÀ¾ß")]
        public List<wf_Sturct_GbAndIndex> wf_posps = new List<wf_Sturct_GbAndIndex>();

    }
}