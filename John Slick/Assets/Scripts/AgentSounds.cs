using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgentSounds : AudioPlayer
{
    [field: SerializeField]
    private AudioClip hitClip, deathClip, voiceLineClip;

    public void PlayHitSound()
    {
        PlayClipWithVariablePitch(hitClip);
    }

    public void PlayDeathSound()
    {
        PlayClip(deathClip);
    }

    public void PlayVoiceSound()
    {
        PlayClipWithVariablePitch(voiceLineClip);
    }
}
