

using UnityEngine;
using System.Collections.Generic;
#if UNITY_EDITOR
using UnityEditor;
#endif

namespace AC
{

	[System.Serializable]
	public class FixAngle : Action
	{
		
		// Declare properties here
		public override ActionCategory Category { get { return ActionCategory.Custom; }}
		public override string Title { get { return "FixAngle"; }}
		public override string Description { get { return "This is for fixing player angle."; }}


		// Declare variables here
		public GameObject objectToFix;
        public int constantID;

        public override float Run ()
		{

            if (objectToFix != null)
            {
                float rotationY = objectToFix.transform.rotation.eulerAngles.y;

                if (rotationY >= 90 && rotationY <= 180)
                   
                {
                    objectToFix.transform.localRotation = Quaternion.Euler(0, 150, 0);
                }
                else if(rotationY >= 0 && rotationY <= 90)
                {
                    objectToFix.transform.localRotation = Quaternion.Euler(0, 30, 0);
                }
                else if (rotationY >= 180 && rotationY <= 270)
                {
                    objectToFix.transform.localRotation = Quaternion.Euler(0, 210, 0);
                }
                else if (rotationY >= 270 && rotationY <= 360)
                {
                    objectToFix.transform.localRotation = Quaternion.Euler(0, 330, 0);
                }

            }

			isRunning = true;
			return defaultPauseTime;
        }

        override public void AssignValues()
        {
            objectToFix = AssignFile(constantID, objectToFix);
        }

#if UNITY_EDITOR

        public override void ShowGUI ()
		{
            objectToFix = (GameObject) EditorGUILayout.ObjectField("Object to Scale:", objectToFix, typeof(GameObject), true);

			constantID = FieldToID (objectToFix, constantID);
            objectToFix = IDToField(objectToFix, constantID, true);
		}

		#endif
		
	}

}