using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBehaviorScript : MonoBehaviour
{

	Vector3 camerapos = new Vector3();

    public Transform tracking;

    private float range = 0.0f;
    private float offsetMax = 1.0F;

    Vector3 offset = new Vector3();
    Vector2 center = new Vector2((Screen.width/2.0F), -(Screen.height/2.0F));

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update(){
    	camerapos.Set(tracking.position.x, tracking.position.y, -10.0f);
        transform.position = camerapos-offset;
    }
    void OnGUI()
    {
        range = range + Time.deltaTime;
        if (range > 0.1f)
        {
            Event e = Event.current;
            offset = (Vector2.Reflect(e.mousePosition, Vector2.left) + center)/ Screen.width * offsetMax;
            range = 0.0f;
        }
    }

}