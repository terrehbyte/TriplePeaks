using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Light))]
[RequireComponent(typeof(AudioSource))]
public class LightFlicker : MonoBehaviour
{
    public Light targetLight;
    public AudioSource audioSource;

    [SerializeField]
    private AudioClip flickerNoise;

    public float FlickerPhase = 5f;
    public float FlickerPhaseVariation = 3f;
    public float FlickerDuration = 0.05f;
    public int FlickerCount = 20;

    private float flickerCountdown;
    private Coroutine lastFlickerCoroutine;

    private float GetNextFlickerTime()
    {
        return FlickerPhase + (FlickerPhaseVariation * Random.Range(-1.0f, 1.0f));
    }

    IEnumerator StartFlickerEffect(float blackoutTime, int flickerCount)
    {
        while (flickerCount > 0)
        {
            flickerCount--;
            targetLight.enabled = !targetLight.enabled;

            yield return new WaitForSeconds(blackoutTime);

            targetLight.enabled = !targetLight.enabled;

            yield return new WaitForSeconds(blackoutTime);
        }
    }

    private void Start()
    {
        flickerCountdown = FlickerPhase;
    }

    private void FixedUpdate()
    {
        flickerCountdown -= Time.deltaTime;

        if (flickerCountdown <= 0f)
        {
            if (lastFlickerCoroutine != null) StopCoroutine(lastFlickerCoroutine);

            lastFlickerCoroutine = StartCoroutine(StartFlickerEffect(FlickerDuration, FlickerCount));
            flickerCountdown = GetNextFlickerTime();
        }
    }

    private void Reset()
    {
        targetLight = GetComponent<Light>();
        audioSource = GetComponent<AudioSource>();
    }
}
