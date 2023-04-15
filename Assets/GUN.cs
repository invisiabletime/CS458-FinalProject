using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class GUN : MonoBehaviour
{
    [Header("Grab interactable")]
    [SerializeField] XRGrabInteractable grabInteractable;

    [Header("Raycasting info")]
    [Tooltip("All the features required for raycasting")]
    [SerializeField] Transform raycastOrigin;
    [SerializeField] LayerMask targetLayer;

    [Header("Audio SFX")]
     AudioSource gunAudioSource;
    [SerializeField] AudioClip gunClipSFX;

    [Header("target hit graphic")]
    [SerializeField] GameObject hitGraphic;

    private void Awake()
    {
        if(TryGetComponent(out AudioSource audio))
        {
            gunAudioSource = audio;
        }
        else
        {
            gunAudioSource = gameObject.AddComponent(typeof(AudioSource)) as AudioSource;
        }
    }

    // Update is called once per frame
    private void OnEnable() => grabInteractable.activated.AddListener(TriggerPulled);

    private void OnDisable() => grabInteractable.activated.RemoveListener(TriggerPulled);
    


    private void TriggerPulled(ActivateEventArgs arg0)
    {
        arg0.interactor.GetComponent<XRBaseController>().SendHapticImpulse(.5f, .25f);

        gunAudioSource.PlayOneShot(gunClipSFX);

        FireRaycastIntoScene();
    }

    private void FireRaycastIntoScene()
    {
        RaycastHit hit;

        if (Physics.Raycast(raycastOrigin.position, raycastOrigin.TransformDirection(Vector3.forward), out hit, Mathf.Infinity, targetLayer))
        {
            if (hit.transform.GetComponent<IIterface>() != null)
            {
                hit.transform.GetComponent<IIterface>().Targetshot();

                if(!GameManager.Instance.ShouldCreatedHitGraphic)
                {
                    return;
                }

                CreateHitGraphicOnTarget(hit.point);

            }
            else
            {
                Debug.Log("Not interheriting from interface");
            }
        }
    }

    private void CreateHitGraphicOnTarget(Vector3 hitLocation)
    {
        GameObject hitMarker = Instantiate(hitGraphic, hitLocation, Quaternion.identity);
    }
}