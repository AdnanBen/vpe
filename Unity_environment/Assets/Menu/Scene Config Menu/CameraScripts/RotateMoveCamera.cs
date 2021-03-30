using System;
using UnityEngine;

namespace Menu.Scene_Config_Menu.CameraScripts
{
    public class RotateMoveCamera : MonoBehaviour
    {
        public GameObject sceneCamera = null;

        private float baseMoveFactor = 0.05f;
        private float modifierKey = 3;
        private float rotationFactor = 0.5f;

        public static bool allowMovement = false;

        public static void EnableMovement()
        {
            allowMovement = true;
        }

        public static void DisableMovement()
        {
            allowMovement = false;
        }
        
        void Update()
        {
            
            if (!allowMovement)
            {
                return;
            }
            
            // Movement sensitivity controls 
            if (Input.GetKeyDown(KeyCode.Minus))
            {
                baseMoveFactor = Math.Max(baseMoveFactor - 0.002f, 0);
            }
            else if (Input.GetKeyDown(KeyCode.Equals))
            {
                baseMoveFactor += 0.002f;
            }
            
            // Look sensitivity controls 
            if (Input.GetKeyDown(KeyCode.LeftBracket))
            {
                rotationFactor = Math.Max(rotationFactor - 0.02f, 0);
            }
            else if (Input.GetKeyDown(KeyCode.RightBracket))
            {
                rotationFactor += 0.02f;
            }
            
            // Look controls 
            var rotation = sceneCamera.transform.eulerAngles;
            if (Input.GetKey(KeyCode.UpArrow))
            {
                // Pitch up
                rotation.x += -rotationFactor;
            }
            else if (Input.GetKey(KeyCode.DownArrow))
            {
                // Pitch down
                rotation.x += rotationFactor;
            }

            if (Input.GetKey(KeyCode.LeftArrow))
            {
                // Look left
                rotation.y += -rotationFactor;
            }
            else if (Input.GetKey(KeyCode.RightArrow))
            {
                // Look right
                rotation.y += rotationFactor;
            }
            sceneCamera.transform.eulerAngles = rotation;
            
            
            // Faster allowMovement when modifier key pressed
            var moveAmount = baseMoveFactor;
            if (Input.GetKey(KeyCode.Space))
            {
                moveAmount *= modifierKey;
            }
            
            // Movement 
            if (Input.GetKey(KeyCode.W))
            {
                transform.Translate(new Vector3(0, 0, moveAmount));
            }
            else if (Input.GetKey(KeyCode.S))
            {
                transform.Translate(new Vector3(0, 0, -moveAmount));
            }

            if (Input.GetKey(KeyCode.D))
            {
                transform.Translate(new Vector3(moveAmount, 0, 0));
            }
            else if (Input.GetKey(KeyCode.A))
            {
                transform.Translate(new Vector3(-moveAmount, 0, 0));
            }
            
            
            // Vertical movement 
            if (Input.GetKey(KeyCode.LeftShift))
            {
                transform.Translate(new Vector3(0, moveAmount/2, 0), Space.World);
            }
            else if (Input.GetKey(KeyCode.LeftControl))
            {
                transform.Translate(new Vector3(0, -moveAmount/2, 0), Space.World);
            }

        }


        private void OnTriggerEnter(Collider other) {
            PreventCameraEscape();
        }

        private void OnTriggerStay(Collider other) {
            PreventCameraEscape();
        }

        private void OnTriggerExit(Collider other)
        {
            PreventCameraEscape();
        }

        private void PreventCameraEscape()
        {
            var rotation = sceneCamera.transform.eulerAngles;
            sceneCamera.GetComponent<Rigidbody>().isKinematic = true;
            sceneCamera.GetComponent<Rigidbody>().isKinematic = false;
            rotation.z = 0;
            sceneCamera.transform.eulerAngles = rotation;
        }



    }
}
