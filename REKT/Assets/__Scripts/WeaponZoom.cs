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
        rb = GetComponent<RigidbodyFirstPersonController>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            Camera.main.fieldOfView = weaponZoom;
            rb.mouseLook.XSensitivity = zoomSensivity;
            rb.mouseLook.YSensitivity = zoomSensivity;
        }
        else
        {
            Camera.main.fieldOfView = standardZoom;
            rb.mouseLook.XSensitivity = starndardSensivity;
            rb.mouseLook.YSensitivity = starndardSensivity;
        }
    }
}
