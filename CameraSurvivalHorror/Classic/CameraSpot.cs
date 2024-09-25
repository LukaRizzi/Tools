using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LukaExtras.SurvivalHorror.ClassicCamera
{
    public class CameraSpot : MonoBehaviour
    {
        public bool follow = false;
        public int priority = 0;

        public void TriggerPerspective()
        {
            Camera.main.transform.position = transform.position;
            Camera.main.transform.rotation = transform.rotation;

            CameraPositionManager.follow = follow;
        }
    }
}