using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SynchTest : Photon.PunBehaviour, IPunObservable
{
//public Rigidbody rigidbody;
    public float min;
    public float max;
    public float smoothTime = 1F;

    private Vector3 velocity = Vector3.zero;

    private float x;
    private float y;
    private float z;
    //private bool downPressed = false ;

    private Vector3 newpos;
private bool currentlyInteracting = true;

//private float velocityFactor = 20000f;
//private Vector3 posDelta;

//private float rotationFactor = 400f;
//private Quaternion rotationDelta;
//private Vector3 axis;
//private float angle;

//private WandController attachedWand;

private Transform interactionPoint;


// Use this for initialization
void Start () {
// rigidbody = GetComponent();
 //interactionPoint = new GameObject().transform;
// velocityFactor /= rigidbody.mass;

 transform.position = new Vector3(0, 0, 0);
}

// Update is called once per frame
void Update() {
if (currentlyInteracting)
 {
    x = Random.Range(min, max);
    y = Random.Range(min, max);
    z = 0;
    newpos = new Vector3(x, y, z);

    transform.localPosition = Vector3.SmoothDamp(transform.localPosition, newpos, ref velocity, smoothTime);
 }
// {
// posDelta = attachedWand.transform.position - interactionPoint.position;
// this.rigidbody.velocity = posDelta * velocityFactor * Time.fixedDeltaTime;

// rotationDelta = attachedWand.transform.rotation * Quaternion.Inverse(interactionPoint.rotation);
// rotationDelta.ToAngleAxis(out angle, out axis);

// if (angle < 180) {
// angle -= 360;
// }

// this.rigidbody.angularVelocity = (Time.fixedDeltaTime * angle * axis) * rotationFactor;


//}
}

// public void BeginInteraction()
// {
// //attachedWand = wand;
// //interactionPoint.position = wand.transform.position;
// //interactionPoint.rotation = wand.transform.rotation;
// interactionPoint.SetParent(transform, true);

// currentlyInteracting = true;
// }

// public void EndInteraction()
// {
// if (Input.GetKeyUp(KeyCode.A))
// {
// //attachedWand = null;
// currentlyInteracting = false;
// }
// }

public bool IsInteracting()
{
return currentlyInteracting;
}

public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
{
if (stream.isWriting)
{
// We own this player: send the others our data
stream.SendNext(this.currentlyInteracting);

}
else
{
// Network player, receive data
this.currentlyInteracting = (bool)stream.ReceiveNext();
}
}


}