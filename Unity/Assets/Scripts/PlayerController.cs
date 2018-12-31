using UnityEngine;

namespace shrink.project.de
{

    public class PlayerController : MonoBehaviour
    {
        public float speed_horizontal = 3.0f;
        public float speed_vertical = 3.0f;
        public float running_speed_factor = 2.0f;
        bool isRunning;
        void Start()
        {
            Cursor.lockState = CursorLockMode.Locked;
        }
        void Update()
        {
            float x = 0;
            float z = 0;
            if (isRunning)
            {
                 x = Input.GetAxis("Horizontal") * Time.deltaTime * speed_horizontal * running_speed_factor;
                 z = Input.GetAxis("Vertical") * Time.deltaTime * speed_vertical * running_speed_factor;
            }
            else
            {
                 x = Input.GetAxis("Horizontal") * Time.deltaTime * speed_horizontal;
                 z = Input.GetAxis("Vertical") * Time.deltaTime * speed_vertical;
            }



            //Blickrichtung horizontal
            //transform.Rotate(0, x, 0);

            //Bewegen
            transform.Translate(x, 0, z);

            // Generate a ray from the cursor position
            //var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Input.GetKeyDown("escape"))
            {
                Cursor.lockState = CursorLockMode.None;
            }
            if(Input.GetKeyDown(KeyCode.LeftShift)){
                isRunning = true;
            }
            if(Input.GetKeyUp(KeyCode.LeftShift)){
                isRunning = false;
            }
        }

    }
}