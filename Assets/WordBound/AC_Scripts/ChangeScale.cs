

using UnityEngine;
using System.Collections.Generic;
#if UNITY_EDITOR
using UnityEditor;
#endif

namespace AC
{

	[System.Serializable]
	public class ChangeScale : Action
	{
		
		// Declare properties here
		public override ActionCategory Category { get { return ActionCategory.Custom; }}
		public override string Title { get { return "ChangeScale"; }}
		public override string Description { get { return "This is for change palyer scale."; }}


		// Declare variables here
		public GameObject objectToScale;
        public int constantID;

        public override float Run ()
		{

            if (objectToScale != null)
            {
                float rotationY = objectToScale.transform.rotation.eulerAngles.y;

                if ((rotationY >= -10 && rotationY <= 60)
                    || (rotationY >= 130 && rotationY <= 240)
                    || (rotationY >= 300 && rotationY <= 350))
                {
                    objectToScale.transform.localScale = new Vector3(1f, 1f, 0.3f);
                }
                else
                {
                    objectToScale.transform.localScale = new Vector3(0.3f, 1f, 1f);
                }
            }

			isRunning = true;
			return defaultPauseTime;
        }

        override public void AssignValues()
        {
            objectToScale = AssignFile(constantID, objectToScale);
        }

#if UNITY_EDITOR

        public override void ShowGUI ()
		{
			objectToScale = (GameObject) EditorGUILayout.ObjectField("Object to Scale:", objectToScale, typeof(GameObject), true);

			constantID = FieldToID (objectToScale, constantID);
			objectToScale = IDToField(objectToScale, constantID, true);
		}

		#endif
		
	}

}