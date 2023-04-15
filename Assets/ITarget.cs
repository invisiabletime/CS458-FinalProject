using UnityEngine;

interface ITarget
{
    public void Shot(Vector3 hitpoint);

    public void PlayAnimation();

    public void PlayAudio();
}