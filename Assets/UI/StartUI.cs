using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class StartUI : MonoBehaviour, IIterface
{
    [SerializeField] TextMeshProUGUI uiText;
    public void Playanimation()
    {
        
    }

    public void PlayAudio()
    {
       
    }

    public void Targetshot()
    {
        uiText.text = "GET READY!";
        Invoke("StartGame", 3f);
    }

   void StartGame()
    {
        GameManager.Instance.GameStart();
        this.gameObject.SetActive(false);
    }
    
}
