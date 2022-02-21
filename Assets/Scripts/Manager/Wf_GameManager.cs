using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;
using UnityEditor;
using Wf_Assist_Cs;

public class Wf_GameManager : Wf_SingletonPattern_Mono<Wf_GameManager>
{
    [TitleGroup("PlayerDate")]
    [HorizontalGroup("PlayerDate/Group_1", Width = 0.5f, LabelWidth = 50)]
    [TabGroup("PlayerDate/Group_1/Group_1", "A")]
    public GameObject wf_player;
    [TabGroup("PlayerDate/Group_1/Group_1", "A")]
    public PlayerController wf_playerController;
    [TabGroup("PlayerDate/Group_1/Group_1", "A")]
    [Range(0,500000)]
    public float speed, jump;

    [TabGroup("PlayerDate/Group_1/Group_1", "B")]
    public LayerMask wf_mask;

    [HorizontalGroup("PlayerDate/Group_1",0.5f, LabelWidth = 50)]
    [TabGroup("PlayerDate/Group_1/Group_2", "组件")]
    public Transform wf_cameraTarget;

    [TabGroup("PlayerDate/Group_1/Group_2", "CS")]
    public string n21, n22, n23;




    [TitleGroup("成语")]
    [HorizontalGroup("成语/Group_1", Width = 0.5f, LabelWidth = 50)]
    [TabGroup("成语/Group_1/Group_1", "A")]
    public Wf_IdiomItem wf_idiom;

    [TabGroup("成语/Group_1/Group_1", "B")]
    public string n31, n32, n33;

    [HorizontalGroup("成语/Group_1", LabelWidth = 50)]
    [TabGroup("成语/Group_1/Group_2", "A")]
    public Transform Tr231, Tr232, Tr233;

    [TabGroup("成语/Group_1/Group_2", "B")]
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


    [TitleGroup("Other")]
    [HorizontalGroup("Other/Group_1")]
    [TabGroup("Other/Group_1/Group_1", "A")]
    public Wf_Enum_Status tempEnum1;
    [TitleGroup("Other")]
    [HorizontalGroup("Other/Group_1")]
    [TabGroup("Other/Group_1/Group_1", "A")]
    public Transform wf_onLoadScene_Des;

    
    [TitleGroup("Create")]
    [HorizontalGroup("Create/Group_1")]
    [TabGroup("Create/Group_1/Group_1", "Setting")]
    public Transform wf_fistPos;
    [TabGroup("Create/Group_1/Group_1", "Setting")]
    public int wf_capNumber;
    [TabGroup("Create/Group_1/Group_1", "Setting")]
    public float wf_capIntervalTime;
    [TabGroup("Create/Group_1/Group_1", "Setting")]
    public float wf_capMoveTime;
    [TabGroup("Create/Group_1/Group_1", "Setting")]
    public Vector3 wf_capAnimationStartPos;
    
    
    [TabGroup("Create/Group_1/Group_1", "Deploy")]
    public List<Wf_CapNodeItem> wf_capNodeItems = new List<Wf_CapNodeItem>();
    
    [TabGroup("Create/Group_1/Group_1", "Gaming")] 
    public List<GameObject> wf_capNode = new List<GameObject>();
    public Dictionary<GameObject,int> wf_capNodeMap = new Dictionary<GameObject, int>();
}
