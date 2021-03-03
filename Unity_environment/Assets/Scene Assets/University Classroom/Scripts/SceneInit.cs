using UnityEngine;

namespace University_Classroom.Scripts
{
    public class SceneInit : MonoBehaviour
    {
    
        
        public GameObject boardObject;
        
        public bool overrideConfig;
        public bool enableBoard;
        public int monitorId;
    

        void Start()
        {
            if (overrideConfig)
            {
                if (enableBoard)
                {
                    boardObject.SetActive(true);
                    var texture = boardObject.GetComponent<uDesktopDuplication.Texture>();
                    texture.monitorId = monitorId;

                }
            }
        
        }
        

        // Update is called once per frame
        void Update()
        {
            
        }
    }
}
