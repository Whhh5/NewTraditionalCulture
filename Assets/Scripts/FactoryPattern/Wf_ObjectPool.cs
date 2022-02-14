using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wf_ObjectPool : Wf_SingletonPattern_Mono<Wf_ObjectPool>
{
    private List<GameObject> wf_capNode;
    private Dictionary<GameObject, List<GameObject>> wf_pool = new Dictionary<GameObject, List<GameObject>>();

    private void Wf_Initialization() 
    {
        for (int i = 0; i < wf_capNode.Count; i++)
        {
            List<GameObject> tempList = new List<GameObject>();

            GameObject tempGb = Instantiate(wf_capNode[i]);
            tempList.Add(tempGb);
            wf_pool.Add(wf_capNode[i],tempList);
            tempGb.SetActive(false);
        }
        Debug.Log("---------   " + wf_capNode.Count + "       对象池与加载完成");
    }

    public GameObject Wf_GetObject(GameObject gb)
    {
        GameObject tempGb = new GameObject();
        if (wf_pool.ContainsKey(gb))
        {
            tempGb = wf_pool[gb][0];
            wf_pool[gb].Remove(tempGb);
            Debug.Log("获取到对象");
        }
        else
        {
            tempGb = Instantiate(gb);
            
            List<GameObject> tempList = new List<GameObject>();
            tempList.Add(tempGb);
            wf_pool.Add(tempGb,tempList);
            
            Debug.Log("创建对象 + 获取到对象");
        }
        return tempGb;
    }

    public void Wf_RemoveObject(GameObject gb)
    {
        gb.SetActive(false);
        
        if (wf_pool.ContainsKey(gb))
        {
            wf_pool[gb].Add(gb);
            Debug.Log("移除对象");
        }
        else
        {
            List<GameObject> tempList = new List<GameObject>();
            tempList.Add(gb);
            wf_pool.Add(gb,tempList);
            
            Debug.Log("新建列表 + 移除对象");
        }
    }
    
}
