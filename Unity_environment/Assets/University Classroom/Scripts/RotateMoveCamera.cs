using UnityEngine;

namespace University_Classroom.Scripts
{
    public class RotateMoveCamera : MonoBehaviour
    {
        public new GameObject camera = null;

        public float baseMoveFactor = 0.01f;
        public float shiftModifier = 3;
        public float shiftModifierVertical = 1;
        public float rotationAmount = 0.1f;

        void Update()
        {

            var rotation = camera.transform.eulerAngles;
            
            if (Input.GetKey(KeyCode.UpArrow))
            {
                // Pitch up
                rotation.x += -rotationAmount;
            }
            else if (Input.GetKey(KeyCode.DownArrow))
            {
                // Pitch down
                rotation.x += rotationAmount;
            }

            if (Input.GetKey(KeyCode.LeftArrow))
            {
                rotation.y += -rotationAmount;
            }
            else if (Input.GetKey(KeyCode.RightArrow))
            {
                rotation.y += rotationAmount;
            }

            camera.transform.eulerAngles = rotation;

            var moveAmount = baseMoveFactor;
            var moveAmountVertical = moveAmount;
            // Faster movement when shift pressed
            if (Input.GetKey(KeyCode.Space))
            {
                moveAmount *= shiftModifier;
                moveAmountVertical *= shiftModifierVertical;
            }
            
            
            if (Input.GetKey(KeyCode.W))
            {
                transform.Translate(new Vector3(0, 0, moveAmount), Space.World);
            }
            else if (Input.GetKey(KeyCode.S))
            {
                transform.Translate(new Vector3(0, 0, -moveAmount), Space.World);
            }

            if (Input.GetKey(KeyCode.D))
            {
                transform.Translate(new Vector3(moveAmount, 0, 0), Space.World);
            }
            else if (Input.GetKey(KeyCode.A))
            {
                transform.Translate(new Vector3(-moveAmount, 0, 0), Space.World);
            }
            

            if (Input.GetKey(KeyCode.LeftShift))
            {
                transform.Translate(new Vector3(0, moveAmountVertical, 0), Space.World);
            }
            else if (Input.GetKey(KeyCode.LeftControl))
            {
                transform.Translate(new Vector3(0, -moveAmountVertical, 0), Space.World);
            }

        }
    }
}
