using UnityEngine;

public class AudioController : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip audioClip;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            Debug.LogError("AudioSource component not found on this GameObject.");
        }
        audioClip = Resources.Load<AudioClip>("Audio/Wanna-KARA"); // Replace with your audio file name
        if (audioClip == null)
        {
            Debug.LogError("Audio clip not found in Resources folder.");
        }
        audioSource.clip = audioClip;
        audioSource.Play();
        Debug.Log("Audio clip is playing.");
    }

    // Update is called once per frame
    void Update()
    {

    }
}
