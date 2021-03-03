using System;
using UnityEngine;

namespace University_Classroom.Scripts
{
    public class RotateMoveCamera : MonoBehaviour
    {
        public GameObject sceneCamera = null;

        public float baseMoveFactor = 0.01f;
        public float shiftModifier = 3;
        public float rotationFactor = 0.1f;

        public bool movement = false;

        public void EnableMovement()
        {
            movement = true;
        }

        public void DisableMovement()
        {
            movement = false;
        }

        void Update()
        {
            
            if (!movement)
            {
                return;
            }

            if (Input.GetKeyDown(KeyCode.Minus))
            {
                baseMoveFactor = Math.Max(baseMoveFactor - 0.002f, 0);
            }
            else if (Input.GetKeyDown(KeyCode.Equals))
            {
                baseMoveFactor += 0.002f;
            }
            
            if (Input.GetKeyDown(KeyCode.LeftBracket))
            {
                rotationFactor = Math.Max(rotationFactor - 0.02f, 0);
            }
            else if (Input.GetKeyDown(KeyCode.RightBracket))
            {
                rotationFactor += 0.02f;
            }
            
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
                rotation.y += -rotationFactor;
            }
            else if (Input.GetKey(KeyCode.RightArrow))
            {
                rotation.y += rotationFactor;
            }

            sceneCamera.transform.eulerAngles = rotation;

            var moveAmount = baseMoveFactor;
            // Faster movement when shift pressed
            if (Input.GetKey(KeyCode.Space))
            {
                moveAmount *= shiftModifier;
            }
            
            
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
            

            if (Input.GetKey(KeyCode.LeftShift))
            {
                transform.Translate(new Vector3(0, moveAmount/2, 0), Space.World);
            }
            else if (Input.GetKey(KeyCode.LeftControl))
            {
                transform.Translate(new Vector3(0, -moveAmount/2, 0), Space.World);
            }

        }
    }
}
