using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SurvivalHorror_Camera
{
    public class CameraPositionManager : MonoBehaviour
    {
        static CameraPositionManager instance;
        static List<CameraSpot> validPositions = new List<CameraSpot>();
        static CameraSpot activeCamera = null;
        static Transform playerCameraPivot;
        static Transform player;

        private void Start()
        {
            //Use some system to find a default Camera Pivot. In this case, a custom one with a tag.
            playerCameraPivot = GameObject.FindGameObjectWithTag("PlayerCameraPivot").transform;
            player = playerCameraPivot.root;
            instance = this;

            transform.position = playerCameraPivot.position;
            transform.rotation = playerCameraPivot.rotation;
        }

        private void Update()
        {
            if (activeCamera != null)
            {
                if (activeCamera.followPlayer)
                {
                    transform.LookAt(player.position);
                }
                return;
            }

            transform.position = Vector3.Lerp(transform.position, playerCameraPivot.position, 3 * Time.deltaTime);
            transform.rotation = Quaternion.Slerp(transform.rotation, playerCameraPivot.rotation, 3 * Time.deltaTime);
        }

        public static void AddValidPosition(CameraSpot spot)
        {
            validPositions.Add(spot);
            if (validPositions.Count == 1)
            {
                validPositions[0].TriggerPerspective();
                activeCamera = spot;
            }
            else
            {
                CameraSpot mostImportant = FindMostImportantCamera();
                mostImportant.TriggerPerspective();
                activeCamera = mostImportant;
            }
        }

        public static void RemoveValidPosition(CameraSpot spot)
        {
            validPositions.Remove(spot);
            if (activeCamera == spot || validPositions.Count == 0)
            {
                activeCamera = null;
                if (validPositions.Count > 0)
                {
                    CameraSpot mostImportant = FindMostImportantCamera();
                    mostImportant.TriggerPerspective();
                    activeCamera = mostImportant;
                }
                else
                {
                    instance.transform.position = playerCameraPivot.position;
                    instance.transform.rotation = playerCameraPivot.rotation;
                }
            }
        }

        public static CameraSpot FindMostImportantCamera()
        {
            if (validPositions.Count == 0) return null;

            int highestPrio = -1;
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
    }

}