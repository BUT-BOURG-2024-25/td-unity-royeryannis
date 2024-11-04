using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.InputSystem;


public class NewBehaviourScript : MonoBehaviour
{


    [SerializeField]
    private GameObject objectToSpawn = null;

    [SerializeField]
    private LayerMask GroundLayer;

    private void OnDestroy() 
    {
        InputManager.Instance.UnRegisterOnClick(OnClick);

    }
    // Update is called once per frame
    private void Start()
    {
        InputManager.Instance.RegisterOnClick(OnClick);

    }

    private void OnClick(InputAction.CallbackContext callbackContext)
    {
        Debug.Log("aaaaahh");
        Ray cameraRay = Camera.main.ScreenPointToRay(Input.mousePosition);
       
        RaycastHit hitInfo;

        bool raycastHasHit = Physics.Raycast(cameraRay, out hitInfo, 10000, GroundLayer);
            if (raycastHasHit && objectToSpawn != null) { 
            GameObject.Instantiate(objectToSpawn,hitInfo.point + (Vector3.up * 0.5f), Quaternion.identity);
            }
    }
}
