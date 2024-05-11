using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AC;


namespace AC
{



    [System.Serializable]
    public class ActionDestroyByTag : Action
    {
        

        public override ActionCategory Category { get { return ActionCategory.Custom; } }
        public override string Title { get { return "Destroy by tag"; } }
        public override string Description { get { return "Destroys all objects with the specified tag."; } }

        // Параметр для тега объектов, которые нужно уничтожить
        public string tagToDestroy = "puffFX";

        public override float Run()
        {
            GameObject[] objectsToDestroy = GameObject.FindGameObjectsWithTag(tagToDestroy);

            if (objectsToDestroy.Length > 0)
            {
                foreach (GameObject obj in objectsToDestroy)
                {
                    Object.Destroy(obj);
                }
            }
            else
            {
                ACDebug.Log("No objects found with tag '" + tagToDestroy + "'.");
            }

            return 0f;
        }

        public override void Skip()
        {
            Run();
        }
    }

}