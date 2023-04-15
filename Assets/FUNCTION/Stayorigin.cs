using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class Stayorigin : MonoBehaviour
{
    [SerializeField] XRBaseInteractable grabbedObject;
    private Pose _originPoint;
    private Rigidbody rb;

    private void OnEnable() => grabbedObject.selectExited.AddListener(ObjectReleased);

    private void OnDisable() => grabbedObject.selectExited.RemoveListener(ObjectReleased);

    private void Awake()
    {
        _originPoint.position = this.transform.position;
        _originPoint.rotation = this.transform.rotation;
        rb = GetComponent<Rigidbody>();
    }
    private void ObjectReleased(SelectExitEventArgs arg0)
    {
        rb.Sleep();

        GetComponent<Collider>().enabled = false;

        this.transform.position = _originPoint.position;
        this.transform.rotation = _originPoint.rotation;

        rb.WakeUp();

        GetComponent<Collider>().enabled = true;
        
    }
}
