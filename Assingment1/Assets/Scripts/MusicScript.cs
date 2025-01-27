using UnityEngine;
using UnityEngine.UIElements;

public class MusicScript : MonoBehaviour
{
    public AudioClip backgroundMusic;
    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        AudioSource auidoSource = GetComponent<AudioSource>();
        if (auidoSource != null && backgroundMusic !=null)
        {
            auidoSource.clip = backgroundMusic;
            auidoSource.loop = true;
            auidoSource.Play();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
