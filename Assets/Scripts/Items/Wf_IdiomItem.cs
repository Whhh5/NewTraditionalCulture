using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "New IdiomItem", menuName = "Inventory/New IdiomItem")]
public class Wf_IdiomItem : ScriptableObject
{
    public GameObject wf_model;
    public List<string> idiom = new List<string>();
}
