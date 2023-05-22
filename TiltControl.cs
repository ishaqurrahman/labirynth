using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TiltControl : MonoBehaviour
{

    private Touch touch;
    private Vector2 touchPosition;
    private Quaternion rotationX, rotationZ;
    private float tiltSpeedModifier = 0.1f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0)
        {
            touch = Input.GetTouch(0);
            switch (touch.phase) 
            {
                case TouchPhase.Moved:

                    rotationX=Quaternion.Euler(
                        - touch.deltaPosition.x * tiltSpeedModifier,
                        0f,
                        0f);

                        transform.rotation = rotationX * transform.rotation;

                        rotationZ = Quaternion.Euler(
                            0f,
                            0f,
                            - touch.deltaPosition.y * tiltSpeedModifier
                        );

                        transform.rotation = transform.rotation * rotationZ;

                        break;
            }
        }
    }
}
