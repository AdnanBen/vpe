using UnityEngine;

namespace Menu.Env_Setup_HUD
{
    public class SaveLoadCameraAngles : MonoBehaviour
    {
        public GameObject cam = null;
        public float timeDown = 0.3f;
        private float _time = 0f;
        
        [System.Serializable]
        public struct CameraPosition 
        {
            public Vector3 position;
            public float rotationx;
            public float rotationy;
        }
        
        public CameraPosition[] cameraPositions = new CameraPosition[11];

        void Update()
        {

        var rotation = cam.transform.eulerAngles;

        if (Input.GetKey(KeyCode.Alpha1))
        {
            _time += Time.deltaTime;
            if (_time > timeDown)
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
            cam.transform.eulerAngles = rotation;
            _time = 0f;
        }

        if (Input.GetKey(KeyCode.Alpha2))
        {
            _time += Time.deltaTime;
            if (_time > timeDown)
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
            cam.transform.eulerAngles = rotation;
            _time = 0f;
        }

        if (Input.GetKey(KeyCode.Alpha3))
        {
            _time += Time.deltaTime;
            if (_time > timeDown)
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
            cam.transform.eulerAngles = rotation;
            _time = 0f;
        }

        if (Input.GetKey(KeyCode.Alpha4))
        {
            _time += Time.deltaTime;
            if (_time > timeDown)
            {
                cameraPositions[4].position = transform.position;
                cameraPositions[4].rotationx = rotation.x;
                cameraPositions[4].rotationy = rotation.y;
            }
        }
        if (Input.GetKeyUp(KeyCode.Alpha4)) 
        {
            transform.position = cameraPositions[4].position;
            rotation.x = cameraPositions[4].rotationx;
            rotation.y = cameraPositions[4].rotationy;
            cam.transform.eulerAngles = rotation;
            _time = 0f;
        }

        if (Input.GetKey(KeyCode.Alpha5))
        {
            _time += Time.deltaTime;
            if (_time > timeDown)
            {
                cameraPositions[5].position = transform.position;
                cameraPositions[5].rotationx = rotation.x;
                cameraPositions[5].rotationy = rotation.y;
            }
        }
        if (Input.GetKeyUp(KeyCode.Alpha5)) 
        {
            transform.position = cameraPositions[5].position;
            rotation.x = cameraPositions[5].rotationx;
            rotation.y = cameraPositions[5].rotationy;
            cam.transform.eulerAngles = rotation;
            _time = 0f;
        }

        if (Input.GetKey(KeyCode.Alpha6))
        {
            _time += Time.deltaTime;
            if (_time > timeDown)
            {
                cameraPositions[6].position = transform.position;
                cameraPositions[6].rotationx = rotation.x;
                cameraPositions[6].rotationy = rotation.y;
            }
        }
        if (Input.GetKeyUp(KeyCode.Alpha6)) 
        {
            transform.position = cameraPositions[6].position;
            rotation.x = cameraPositions[6].rotationx;
            rotation.y = cameraPositions[6].rotationy;
            cam.transform.eulerAngles = rotation;
            _time = 0f;
        }

        if (Input.GetKey(KeyCode.Alpha7))
        {
            _time += Time.deltaTime;
            if (_time > timeDown)
            {
                cameraPositions[7].position = transform.position;
                cameraPositions[7].rotationx = rotation.x;
                cameraPositions[7].rotationy = rotation.y;
            }
        }
        if (Input.GetKeyUp(KeyCode.Alpha7)) 
        {
            transform.position = cameraPositions[7].position;
            rotation.x = cameraPositions[7].rotationx;
            rotation.y = cameraPositions[7].rotationy;
            cam.transform.eulerAngles = rotation;
            _time = 0f;
        }

        if (Input.GetKey(KeyCode.Alpha8))
        {
            _time += Time.deltaTime;
            if (_time > timeDown)
            {
                cameraPositions[8].position = transform.position;
                cameraPositions[8].rotationx = rotation.x;
                cameraPositions[8].rotationy = rotation.y;
            }
        }
        if (Input.GetKeyUp(KeyCode.Alpha8)) 
        {
            transform.position = cameraPositions[8].position;
            rotation.x = cameraPositions[8].rotationx;
            rotation.y = cameraPositions[8].rotationy;
            cam.transform.eulerAngles = rotation;
            _time = 0f;
        }

        if (Input.GetKey(KeyCode.Alpha9))
        {
            _time += Time.deltaTime;
            if (_time > timeDown)
            {
                cameraPositions[9].position = transform.position;
                cameraPositions[9].rotationx = rotation.x;
                cameraPositions[9].rotationy = rotation.y;
            }
        }
        if (Input.GetKeyUp(KeyCode.Alpha9)) 
        {
            transform.position = cameraPositions[9].position;
            rotation.x = cameraPositions[9].rotationx;
            rotation.y = cameraPositions[9].rotationy;
            cam.transform.eulerAngles = rotation;
            _time = 0f;
        }

        if (Input.GetKey(KeyCode.Alpha0))
        {
            _time += Time.deltaTime;
            if (_time > timeDown)
            {
                cameraPositions[10].position = transform.position;
                cameraPositions[10].rotationx = rotation.x;
                cameraPositions[10].rotationy = rotation.y;
            }
        }
        if (Input.GetKeyUp(KeyCode.Alpha0)) 
        {
            transform.position = cameraPositions[10].position;
            rotation.x = cameraPositions[10].rotationx; 
            rotation.y = cameraPositions[10].rotationy;
            cam.transform.eulerAngles = rotation;
            _time = 0f;
        }

        }
    }
}