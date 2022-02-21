using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody rb;
    bool isJump = false;
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        IsJump();
        if (Input.GetKey(KeyCode.Space) && isJump)
        {
            rb.AddRelativeForce(new Vector3(0, Wf_GameManager.Instance.speed * Time.fixedDeltaTime, 0));
        }
        if (Input.GetAxis("Vertical") != 0 || Input.GetAxis("Horizontal") != 0)
        {
            rb.AddRelativeForce(new Vector3(Wf_GameManager.Instance.speed * Time.fixedDeltaTime * Input.GetAxis("Horizontal") * 0.08f, 0, Wf_GameManager.Instance.speed * Time.fixedDeltaTime * Input.GetAxis("Vertical") * 0.08f));
        }
    }
            

    void IsJump()
    {
        Ray ray = new Ray(transform.position, -transform.up);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit,Wf_GameManager.Instance.wf_mask))
        {
            if (hit.distance <= 0.51f)
            {
                isJump = true;
            }
            else
            {
                isJump = false;
            }
        }
        else
        {
            isJump = false;
        }
    }

    public void Wf_Turning(float angle)
    {
        Wf_GameManager.Instance.wf_player.transform.DORotate(Wf_GameManager.Instance.wf_player.transform.rotation.eulerAngles + new Vector3(0, angle, 0), 0.5f);
    }
}
