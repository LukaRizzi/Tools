using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SurvivalHorror_Camera
{
    public class CameraTrigger : MonoBehaviour
    {
        [SerializeField] CameraSpot spot;

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                CameraPositionManager.AddValidPosition(spot);
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                CameraPositionManager.RemoveValidPosition(spot);
            }
        }
    }
}