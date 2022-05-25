namespace Levels.Inventory
{
    using Doozy.Runtime.UIManager.Components;
    using Doozy.Editor.Common;
    using UnityEngine;

    public class StorageBuilder_Mono : MonoBehaviour
    {
        [Header("Test1")] 
        public int test;
        
        public StorageInfo Info;

        private void OnValidate()
        {
            Debug.Log("Validating");
            //Info.CreateList();
        }
    }
}

