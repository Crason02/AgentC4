using UnityEngine;

public class ScreenShakeScript : MonoBehaviour
{
    private float trauma = 0f;
    public float traumaDecay = 1.5f;
    public float maxAngle = 10f;
    public float noiseSpeed = 20f;

    void Update()
    {
        if (trauma > 0)
        {
            float shake = trauma * trauma; // squared falloff feels more natural
            float t = Time.time * noiseSpeed;

            float offsetX = (Mathf.PerlinNoise(t, 0f) - 0.5f) * 2f;
            float offsetY = (Mathf.PerlinNoise(0f, t) - 0.5f) * 2f;
            float offsetZ = (Mathf.PerlinNoise(t, t) - 0.5f) * 2f;

            transform.localRotation = Quaternion.Euler(
                offsetX * maxAngle * shake,
                offsetY * maxAngle * shake,
                offsetZ * maxAngle * shake
            );

            trauma = Mathf.Clamp01(trauma - traumaDecay * Time.deltaTime);
        }
        else
        {
            transform.localRotation = Quaternion.identity;
        }
    }

    public void AddTrauma(float amount)
    {
        trauma = Mathf.Clamp01(trauma + amount);
    }
}
