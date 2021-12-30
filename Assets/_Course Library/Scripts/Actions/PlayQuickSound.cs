using UnityEngine;

/// <summary>
/// Play a simple sounds using Play one shot with volume, and pitch
/// </summary>
[RequireComponent(typeof(AudioSource))]
public class PlayQuickSound : MonoBehaviour
{
    [Tooltip("The sound that is played")]
    public AudioClip sound = null;

    [Tooltip("The volume of the sound")]
    public float volume = 1.0f;

    [Tooltip("The range of pitch the sound is played at (-pitch, pitch)")]
    [Range(0, 1)] public float randomPitchVariance = 0.0f;

    private AudioSource audioSource = null;

    private float defaultPitch = 1.0f;
   
    Animator animator;
    AudioSource audioData;
    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
       // animator = GameObject.FindGameObjectWithTag("ybot").GetComponent<Animator>();
       // audioData = GameObject.FindGameObjectWithTag("Speaker").GetComponent<AudioSource>();
    }

    public void Play()
    {
        float randomVariance = Random.Range(-randomPitchVariance, randomPitchVariance);
        randomVariance += defaultPitch;

        audioSource.pitch = randomVariance;
        audioSource.PlayOneShot(sound, volume);
        audioSource.pitch = defaultPitch;

        Debug.Log(audioSource);

        /*       
        animator.SetBool("isDancing", true);
        if (audioData.isPlaying || audioSource.maxDistance != 499)
        {
            audioData.Pause();
        }
        else
        {
            audioData.Play(0);
        }
        */
    }

    private void OnValidate()
    {
        AudioSource audioSource = GetComponent<AudioSource>();
        audioSource.playOnAwake = false;
    }
}
