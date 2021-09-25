using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastShoot : MonoBehaviour
{
    // Start is called before the first frame update
    Camera mainCamera;
    public GameObject hitEffect;
    public ParticleSystem muzzleFlash;
    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        mainCamera = Camera.main;        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            muzzleFlash.Play();
            if(Physics.Raycast(mainCamera.transform.position,mainCamera.transform.forward,out RaycastHit hitInfo))
            {
                if(hitInfo.point == null)
                {
                    return;
                }
                else
                {
                    GameObject bulletImpact = Instantiate(hitEffect,hitInfo.point,Quaternion.LookRotation(hitInfo.normal,Vector3.up));
                    Destroy(bulletImpact,5);
                    GetComponent<Destruction>().destruction(hitInfo.point);
                }

            }
        }
        
    }
}
