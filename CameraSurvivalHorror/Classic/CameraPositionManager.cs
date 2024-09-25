using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LukaExtras.SurvivalHorror.ClassicCamera
{
    public class CameraPositionManager : MonoBehaviour
    {
        public static CameraPositionManager instance;
        public static bool follow = false;
        static List<CameraSpot> validPositions;
        static Transform player;

        private void Start()
        {
            //Use some system to find a default Camera Object To Follow.
            //In this case, a custom one with a tag.
            //In the future it may be good to use a singleton to grab a reference if it
            //persists within levels or something.
            player = GameObject.FindGameObjectWithTag("Player").transform;
            instance = this;
            validPositions = new();
        }

        private void Update()
        {
            if (follow)
            {
                Camera.main.transform.LookAt(player);
            }
        }

        public static void AddValidPosition(CameraSpot spot)
        {
            validPositions.Add(spot);
            if (validPositions.Count == 1)
            {
                validPositions[0].TriggerPerspective();
            }
            else
            {
                TriggerMostImportantCamera();
            }
        }

        public static void RemoveValidPosition(CameraSpot spot)
        {
            validPositions.Remove(spot);

            TriggerMostImportantCamera();
        }

        public static CameraSpot FindMostImportantCamera()
        {
            if (validPositions.Count == 0) return null;

            int highestPrio = int.MinValue;
            CameraSpot highestCam = null;
            for (int i = 0; i < validPositions.Count; i++)
            {
                int prio = validPositions[i].priority;
                if (prio > highestPrio)
                {
                    highestPrio = prio;
                    highestCam = validPositions[i];
                }
            }

            return highestCam;
        }

        public static void TriggerMostImportantCamera()
        {
            CameraSpot mostImportant = FindMostImportantCamera();
            if (mostImportant == null)
            {
                Debug.LogWarning("No se detecta una cámara en la posición " + player.position);
                return;
            }
            mostImportant.TriggerPerspective();
        }
    }

}