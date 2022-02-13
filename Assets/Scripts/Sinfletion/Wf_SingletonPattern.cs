using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wf_SingletonPattern<T> where T : Wf_SingletonPattern<T>, new()
{
    public static T Instance = new T();
}
