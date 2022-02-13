using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

public class Wf_SingletonPattern_Serialized<T> : SerializedMonoBehaviour where T : Wf_SingletonPattern_Serialized<T>
{
    public static T Instance;
    private void Awake()
    {
        Instance = (T)this;
    }
}
