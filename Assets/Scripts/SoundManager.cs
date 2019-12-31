using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{

    public static AudioClip parrySound, attackSound, blockSound, windSound;
    static AudioSource audioSrc;
    // Start is called before the first frame update
    void Start()
    {
        parrySound = Resources.Load<AudioClip>("parry");
        attackSound = Resources.Load<AudioClip>("attack");
        windSound = Resources.Load<AudioClip>("wind");

        audioSrc = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public static void PlaySound(string clip)
    {
        switch (clip)
        {
            case "parry":
                audioSrc.PlayOneShot(parrySound);
                break;
            case "attack":
                audioSrc.PlayOneShot(attackSound, 0.2f);
                break;
        }
    }
}
