using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Doozy.Engine.UI;
using Sirenix.OdinInspector;

public class Wf_UIManager : Wf_SingletonPattern_Serialized<Wf_UIManager>
{




    public Transform wf_idiomParent;

    [TitleGroup("Doozy UI")]
    public Dictionary<string, UIPopup> popups = new Dictionary<string, UIPopup>();
}
