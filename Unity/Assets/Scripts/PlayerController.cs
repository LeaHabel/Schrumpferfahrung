using UnityEngine;

public class PlayerController : MonoBehaviour
{
    string size;
    bool isShrunk;

    void Start(){
        
    }
    void Update()
    {
       var x = Input.GetAxis("Horizontal") * Time.deltaTime * 150.0f;
        var z = Input.GetAxis("Vertical") * Time.deltaTime * 3.0f;


        //Blickrichtung horizontal
        transform.Rotate(0, x, 0);

        //Bewegen
        transform.Translate(0, 0, z);

        // Generate a ray from the cursor position
        //var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
    }

}