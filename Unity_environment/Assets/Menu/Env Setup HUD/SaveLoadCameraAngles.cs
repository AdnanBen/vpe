using UnityEngine;

namespace University_Classroom.Scripts
{
    public class SaveLoadCameraAngles : MonoBehaviour
    {
        public new GameObject camera = null;
        public float timeDown = 0.3f;
        private float time = 0f;

        struct cameraPosition 
        {
            public Vector3 position;
            public float rotationx;
            public float rotationy;
        }
        
        cameraPosition[] cameraPositions = new cameraPosition[9];

        void Update()
        {

        var rotation = camera.transform.eulerAngles;

        if (Input.GetKey(KeyCode.Alpha1))
            {
                time += Time.deltaTime;
                if (time > timeDown)
                {
                    cameraPositions[1].position = transform.position;
                    cameraPositions[1].rotationx = rotation.x;
                    cameraPositions[1].rotationy = rotation.y;
                }
            }
        if (Input.GetKeyUp(KeyCode.Alpha1)) 
        {
            transform.position = cameraPositions[1].position;
            rotation.x = cameraPositions[1].rotationx;
            rotation.y = cameraPositions[1].rotationy;
            camera.transform.eulerAngles = rotation;
            time = 0f;
        }

        if (Input.GetKey(KeyCode.Alpha2))
            {
                time += Time.deltaTime;
                if (time > timeDown)
                {
                    cameraPositions[2].position = transform.position;
                    cameraPositions[2].rotationx = rotation.x;
                    cameraPositions[2].rotationy = rotation.y;
                }
            }
        if (Input.GetKeyUp(KeyCode.Alpha2)) 
        {
            transform.position = cameraPositions[2].position;
            rotation.x = cameraPositions[2].rotationx;
            rotation.y = cameraPositions[2].rotationy;
            camera.transform.eulerAngles = rotation;
            time = 0f;
        }

        if (Input.GetKey(KeyCode.Alpha3))
            {
                time += Time.deltaTime;
                if (time > timeDown)
                {
                    cameraPositions[3].position = transform.position;
                    cameraPositions[3].rotationx = rotation.x;
                    cameraPositions[3].rotationy = rotation.y;
                }
            }
        if (Input.GetKeyUp(KeyCode.Alpha3)) 
        {
            transform.position = cameraPositions[3].position;
            rotation.x = cameraPositions[3].rotationx;
            rotation.y = cameraPositions[3].rotationy;
            camera.transform.eulerAngles = rotation;
            time = 0f;
        }

        }
    }
}
