using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed_horizontal = 3.0f;
    public float speed_vertical = 3.0f;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }
    void Update()
    {


        var x = Input.GetAxis("Horizontal") * Time.deltaTime * speed_horizontal;
        var z = Input.GetAxis("Vertical") * Time.deltaTime * speed_vertical;
        

        //Blickrichtung horizontal
        //transform.Rotate(0, x, 0);

        //Bewegen
        transform.Translate(x, 0, z);

        // Generate a ray from the cursor position
        //var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if(Input.GetKeyDown("escape")){
            Cursor.lockState = CursorLockMode.None;
        }
    }

}