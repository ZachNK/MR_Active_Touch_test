using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIMng00 : MonoBehaviour
{
    public GameObject Select;
    public GameObject AT;

    public List<Text> TestInfos;

    private int ExIdx;
    private List<int> Counts = new List<int> { 0 };

    public void setSelect()
    {
        int idx = 0;
        foreach (var item in TestInfos)
        {
            item.text = string.Format("Test {0}\n{1}", idx + 1, Counts[idx]);
            idx++;
        }

        bool isExpDone = false;
        Counts.ForEach((int i) => { if (i == 100) isExpDone = true; });

        if (isExpDone)
        {
        }

        Select.SetActive(true);
        AT.SetActive(false);
    }

    public void setEx(int idx)
    {
        Select.SetActive(false);
        AT.SetActive(true);
        ExIdx = idx;
        FindObjectOfType<ExpInfo00>().StartExp(ExIdx, Counts[ExIdx]);
        Counts[ExIdx]++;
    }
}