using UnityEngine;

namespace Menu.Scene_Config_Menu
{
    public interface IComponentConfigurator
    {
        
        /**
         * Generates needed component configuration user interface 
         */
        void DrawConfigUI(GameObject parentUI);

        /**
         * Returns vertical size of configuration UI,
         * needed for spacing.
         */
        int GetUISize();
    }
}