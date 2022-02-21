using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wf_CameraConterller : MonoBehaviour
{    
    void Update()
    {
        Move(Wf_GameManager.Instance.wf_cameraTarget);
    }
    void Move(Transform target)
    {
        transform.position = Vector3.Lerp(transform.position, target.position, 2f * Time.deltaTime);
        transform.rotation = Quaternion.Lerp(transform.rotation, target.rotation, 2f * Time.deltaTime);
    }
}
