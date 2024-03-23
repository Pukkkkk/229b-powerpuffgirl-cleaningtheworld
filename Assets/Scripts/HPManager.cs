using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HPManager : MonoBehaviour
{
    [SerializeField] private Text HPText;

    public static int HPCount;

    // Update is called once per frame
    void Update()
    {
        HPText.text = "HP : " + Mathf.Round(HPCount);
    }
}
