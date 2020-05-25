using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExpInfo00 : MonoBehaviour
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
            item.GetComponent<AudioSource>().clip = ATAudios[rl[idx]];

            Debug.Log(item.GetComponent<AudioSource>().clip.name);
            cy.RotationSensitivity = RotationSensitivitys[exidx];
            idx += 1;
        }
    }
}