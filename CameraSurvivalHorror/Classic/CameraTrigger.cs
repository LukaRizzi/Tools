using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LukaExtras.SurvivalHorror.ClassicCamera
{
    public class CameraTrigger : MonoBehaviour
    {
        [SerializeField] CameraSpot spot;

        private void OnTriggerEnter(Collider other)
        {
            Debug.Log("hola " + other.tag);
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