using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
