using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{

	public float x = 0.0F;
    public float y = 0.0F;
    private Vector2 pos;
    private const float spd = 3.5F;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float spFactor = 1.0F;
        int keysdown = 0;
        float dt = Time.deltaTime;
        Vector3 translation = new Vector3(0.0F , 0.0F);

        bool up   =  Input.GetKey("w");
        if (up){keysdown++;}
        bool down =  Input.GetKey("s");
        if (down){keysdown++;}
        bool left  = Input.GetKey("a");
        if (left){keysdown++;}
        bool right = Input.GetKey("d");
        if (right){keysdown++;}

        if (keysdown > 1){
            spFactor = 0.7F;
        }

        if (up){
            translation.y += spFactor;
        }
        if (down){
            translation.y -= spFactor;
        }
        if (right){
            translation.x += spFactor;
        }
        if (left){
            translation.x -= spFactor;
        }

    	transform.Translate(translation*dt*spd);
        
    }
}