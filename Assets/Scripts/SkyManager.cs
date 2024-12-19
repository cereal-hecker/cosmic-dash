using UnityEngine;

public class SkyManager : MonoBehaviour
{

    float skySpeed = 3f;
    void Update()
    {
        RenderSettings.skybox.SetFloat("_Rotation", Time.time * -1 *skySpeed);
    }
}
