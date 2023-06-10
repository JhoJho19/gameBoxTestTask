using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
/// <summary>
/// Post this script on the mute button and enjoy the silence!
/// </summary>
public class Mute : MonoBehaviour
{
    [SerializeField] private Image imageMute; // image for mute symbol
    [SerializeField] private Image imageVolume; // image for volume on symbol
    private bool muted;

    public void Start()
    {
        imageMute.gameObject.SetActive(true); 
        imageVolume.gameObject.SetActive(false);
        muted = false;
    }

    public void MuteButton ()
    {
        muted = !muted;

        if (muted) 
        {
            AudioListener.volume = 0f;
            imageMute.gameObject.SetActive(false);
            imageVolume.gameObject.SetActive(true);
        }

        else 
        {
            AudioListener.volume = 1f;
            imageMute.gameObject.SetActive(true);
            imageVolume.gameObject.SetActive(false);
        }
    }
}
