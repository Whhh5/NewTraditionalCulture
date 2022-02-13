using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wf_SingletonPattern_Mono<T> : MonoBehaviour where T : Wf_SingletonPattern_Mono<T>
{
    public static T Instance;
    private void Awake()
    {
        Instance = (T)this;
    }
}
