using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class PlaySound : MonoBehaviour
{
    public AudioSource jss;
    public AudioClip js;
    public AudioSource css;
    public AudioClip cs;
    public AudioSource dss;
    public AudioClip ds;

    public void PlayJump(){
        jss.PlayOneShot(js);
    }

    public void PlayCrouch(){
        css.PlayOneShot(cs);
    }

    public void PlayDeath(){
        dss.PlayOneShot(ds);
    }
}
