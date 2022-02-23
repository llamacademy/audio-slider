using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkyboxAdjuster : MonoBehaviour
{
    [SerializeField]
    private Light Sun;
    [SerializeField]
    private float DayNightCycleTime = 30f;
    [SerializeField]
    private float RotationOffset = 10f;

    private void Start()
    {
        StartCoroutine(UpdateSkybox());
    }

    private IEnumerator UpdateSkybox()
    {
        while (true)
        {
            float time = 0;
            while (time < 1)
            {
                Sun.transform.rotation = Quaternion.Lerp(Quaternion.Euler(0, RotationOffset, 0), Quaternion.Euler(179.99f, RotationOffset, 0), time);

                time += Time.deltaTime / DayNightCycleTime;
                yield return null;
            }
            
            time = 0;
            while (time < 1)
            {
                Sun.transform.rotation = Quaternion.Lerp(Quaternion.Euler(180, RotationOffset, 0), Quaternion.Euler(359.99f, RotationOffset, 0), time);

                time += Time.deltaTime / DayNightCycleTime * 4;
                yield return null;
            }
        }
    }
}
