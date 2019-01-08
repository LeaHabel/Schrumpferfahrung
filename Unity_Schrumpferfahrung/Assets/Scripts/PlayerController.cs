using UnityEngine;

namespace shrink.project.de
{

    public class PlayerController : MonoBehaviour
    {
        public float speed_horizontal = 3.0f;
        public float speed_vertical = 3.0f;
        public float running_speed_factor = 2.0f;
        bool isRunning;
        public bool canMove;
        public bool isJumping;
        public float maxJumpHeight;
        float actualJumpHeight;
        public float jumpStep;
        public bool enableJumping;
        public bool enableJetpack;
        public float maxJetPackFuel, jetpackSpeed;
        float actualJetpackFuel;

        void Start()
        {
            //lock the mouse cursor to hide it from scene
            Cursor.lockState = CursorLockMode.Locked;
            canMove = true;
            actualJumpHeight = 0;
        }
        void Update()
        {
            checkRunKey();
            if (enableJumping)
            {
                checkJump();
            }
            movement();
            checkUnlockCursor();
            if (enableJetpack)
            {
                checkJetpack();
            }
        }

        //movement forward, backward, left, right
        void movement()
        {

            if ((Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0) && canMove)
            {
                float x = 0;
                float z = 0;
                //speeding up depending on run key
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

                //Bewegen
                transform.Translate(x, 0, z);
            }

        }
        void checkRunKey()
        {
            if (Input.GetKeyDown(KeyCode.LeftShift))
            {
                isRunning = true;
            }
            if (Input.GetKeyUp(KeyCode.LeftShift))
            {
                isRunning = false;
            }
        }
        void checkUnlockCursor()
        {
            if (Input.GetKeyDown("escape"))
            {
                Cursor.lockState = CursorLockMode.None;
            }
        }
        void checkJump()
        {

            if (Input.GetKeyDown("space") && !isJumping)
            {
                isJumping = true;
            }
            if (isJumping && actualJumpHeight != maxJumpHeight)
            {
                actualJumpHeight += jumpStep;
                transform.Translate(0, actualJumpHeight, 0);
            }
            if (actualJumpHeight >= maxJumpHeight)
            {
                isJumping = false;
                actualJumpHeight = 0;
            }

        }
        void checkJetpack()
        {
            if (actualJetpackFuel > 0)
            {
                if (Input.GetMouseButtonDown(1))
                {
                    transform.Translate(0, jetpackSpeed, 0);
                    actualJetpackFuel -= jetpackSpeed;
                }
            }
        }


        void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.tag == "room")
            {
                actualJetpackFuel = maxJetPackFuel;
            }
        }
    }
}