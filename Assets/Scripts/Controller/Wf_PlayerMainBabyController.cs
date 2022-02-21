using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wf_PlayerMainBabyController : MonoBehaviour
{
    
    void Start()
    {
        
    }

    
    void Update()
    {
        if (Input.GetAxis("Horizontal") > 0.1f)
        {

        }
        else if (Input.GetAxis("Horizontal") < 0.1f)
        {

        }

        if (Input.GetAxis("Vertical") > 0.1f)
        {
            
        }
        else if (Input.GetAxis("Vertical") < 0.1f)
        {

        }
    }
}
