using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Wf_MainPopup_Setting : MonoBehaviour
{
    private int _backgroundVolume;

    [SerializeField] GameObject backgroundMusic2;
    List<Image> backgroundImageList = new List<Image>();

    private int backgroundVolume
    {
        get { return _backgroundVolume; }
        set
        {
            if (value < 0)
            {
                value = 0;
            }
            else if(value > backgroundImageList.Count)
            {
                value = backgroundImageList.Count;
            }
            _backgroundVolume = value;
            SetVolumeIcon(backgroundImageList, value);
            Debug.Log(_backgroundVolume);
        }
    }

    void Start()
    {
        for (int i = 0; i < backgroundMusic2.transform.childCount; i++)
        {
            backgroundImageList.Add(backgroundMusic2.transform.GetChild(i).GetComponent<Image>());
        }
        backgroundVolume = backgroundImageList.Count;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha0))
        {
            backgroundVolume += -1;
        }
        if (Input.GetKeyDown(KeyCode.Alpha9))
        {
            backgroundVolume += 1;
        }

    }




    public void SetVolume(ref int volume,int number)
    {
        volume += number;
    }

    public void SetVolumeIcon(List<Image> imageList, int index)
    {
        for (int i = 0; i < imageList.Count; i++)
        {
            if (i < index)
            {
                imageList[i].color = Color.green;
            }
            else
            {
                imageList[i].color = Color.white;
            }
        }
    }
}
