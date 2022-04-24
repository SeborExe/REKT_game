using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class WeaponZoom : MonoBehaviour
{
    RigidbodyFirstPersonController rb;

    [SerializeField] float weaponZoom = 30f; 
    [SerializeField] float zoomSensivity = 1f; 
    float standardZoom = 60f;
    float starndardSensivity = 2f;

    private void Start()
    {
        rb = GetComponentInParent<RigidbodyFirstPersonController>();
    }

    private void OnDisable()
    {
        NormalZoom();
    }

    private void Update()
    {
        if (Input.GetMouseButton(1))
        {
            Zoom();
        }
        else
        {
            NormalZoom();
        }
    }

    private void Zoom()
    {
        Camera.main.fieldOfView = weaponZoom;
        rb.mouseLook.XSensitivity = zoomSensivity;
        rb.mouseLook.YSensitivity = zoomSensivity;
    }

    private void NormalZoom()
    {
        Camera.main.fieldOfView = standardZoom;
        rb.mouseLook.XSensitivity = starndardSensivity;
        rb.mouseLook.YSensitivity = starndardSensivity;
    }
}
