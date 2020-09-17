using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Oculus.Platform;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;





public class TeleportInput : MonoBehaviour
{

    public Hand hand;
    
    
    private XRController controller = null;
    private SnapTurnProvider snapTurn = null;
    private LocomotionProvider locomotion = null;

    [SerializeField] private GameObject teleport;

    public bool teleportEnded = false;

    private void Awake()
    {
        controller = GetComponent<XRController>();
        snapTurn = GetComponentInParent<SnapTurnProvider>();
        locomotion = GetComponentInParent<LocomotionProvider>();


        locomotion.endLocomotion += EndTeleport;
    }

    private void EndTeleport(LocomotionSystem locomotionSystem)
    {
        teleportEnded = true;
        Debug.Log("end");
    }
    


    private void Update()
    {
        ControllerInput();

      
    }

    private void ControllerInput()
    {


      
        
        
        if(controller.inputDevice.TryGetFeatureValue(CommonUsages.primary2DAxis, out Vector2 position))
        {
            
            
            if (position.y > 0.2f && !teleportEnded)
            {
                teleport.SetActive(true);
                snapTurn.enabled = false;


            }
            else
            {
                teleport.SetActive(false);
                snapTurn.enabled = true;
                teleportEnded = false;

            }
        }
    }
    
    
    
}
