using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Targetcontroller : MonoBehaviour,IIterface
{
    [SerializeField] float targetScoreValue;
    public void Targetshot()
    {
        Playanimation();
        PlayAudio();

        GameManager.Instance.PlayerScored(targetScoreValue);
    }

    public void Playanimation()
    {

    }

    public void PlayAudio()
    {
        
    }

    
    // Start is called before the first frame update
   
   
}
