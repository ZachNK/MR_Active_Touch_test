using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExpInfo : MonoBehaviour
{
    public List<float> RotationSensitivitys;
    public List<AudioClip> ATAudios;
    public List<GameObject> Cylinders;

    public void StartExp(int exidx, int cnt)
    {
        List<int> rl = new List<int>();
        for (int i = 0; i < ATAudios.Count; i++)
        {
            int rv = Random.Range(0, ATAudios.Count);
            while (rl.Contains(rv))
            {
                rv = Random.Range(0, ATAudios.Count);
            }
            rl.Add(rv);
        }

        int idx = 0;
        foreach (var item in Cylinders)
        {
            var cy = item.GetComponent<CylinderRotator>();
            //  cy.audioClip = ATAudios[rl[idx]];
            cy.RotationSensitivity = RotationSensitivitys[exidx];
            idx += 1;
        }
        FindObjectOfType<LogWriter>().AddText(string.Format("실험 1 : {0}번 과정, {1}번째 실험\n", exidx, cnt + 1));
        FindObjectOfType<LogWriter>().AddText(string.Format("실험 1 : {0}, {1}, {2} 순서로 배치\n", rl[0], rl[1], rl[2]));
    }
}