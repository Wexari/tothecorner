using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts
{
    class RoomTeleporter : MonoBehaviour
    {
        public CameraController playerCameraController;

        public float X;
        public float Y;

        public float NewBorderX1;
        public float NewBorderX2;
        public float NewBorderY1;
        public float NewBorderY2;
        //public float NewScale;

        private void Start()
        {
            playerCameraController = FindObjectOfType<CameraController>();
        }
        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.collider.name == "John(Clone)")
            {
                collision.collider.gameObject.transform.position = new Vector3(X, Y, 0);

                playerCameraController.borderX1 = NewBorderX1;
                playerCameraController.borderX2 = NewBorderX2;
                playerCameraController.borderY1 = NewBorderY1;
                playerCameraController.borderY2 = NewBorderY2;
            }
        }
    }
}