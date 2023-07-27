using UnityEngine;

public class CameraController : MonoBehaviour
{
    //Room camera
    [SerializeField] private float speed;
    private float currentPosX;
    private Vector3 velocity = Vector3.zero;

    //Follow player
    [SerializeField] private Transform player;
    [SerializeField] private float aheadDistance;
    [SerializeField] private float cameraSpeed;
    private float lookAhead;

    private void Update()
    {
        //Room camera
        transform.position = Vector3.SmoothDamp(transform.position, new Vector3(currentPosX, transform.position.y, transform.position.z), ref velocity, speed);

        //Follow player
        //transform.position = new Vector3(player.position.x + lookAhead, transform.position.y, transform.position.z);
        //lookAhead = Mathf.Lerp(lookAhead, (aheadDistance * player.localScale.x), Time.deltaTime * cameraSpeed);
    }

    public void MoveToNewRoom(Transform _newRoom)
    {
        currentPosX = _newRoom.position.x;
    }
}
//using UnityEngine;

//public class CameraController : MonoBehaviour
//{
//    // Room camera
//    [SerializeField] private float speed;
//    private float currentPosX;
//    private Vector3 velocity = Vector3.zero;

//    // Follow player
//    [SerializeField] private Transform player;
//    [SerializeField] private float aheadDistance;
//    [SerializeField] private float cameraSpeed;
//    private float lookAhead;

//    // Camera boundaries
//    [SerializeField] private Vector2 minCameraPos, maxCameraPos;

//    // Look ahead
//    [SerializeField] private float lookAheadFactor;
//    [SerializeField] private float lookAheadReturnSpeed;
//    [SerializeField] private float lookAheadMoveThreshold;
//    private float offsetZ;
//    private Vector3 lastTargetPosition;
//    private Vector3 currentVelocity;
//    private Vector3 lookAheadPos;

//    private void Start()
//    {
//        lastTargetPosition = player.position;
//        offsetZ = (transform.position - player.position).z;
//        transform.parent = null;
//    }

//    private void Update()
//    {
//        // Room camera
//        transform.position = Vector3.SmoothDamp(transform.position, new Vector3(currentPosX, transform.position.y, transform.position.z), ref velocity, speed);

//        // Look ahead logic
//        float xMoveDelta = (player.position - lastTargetPosition).x;

//        bool updateLookAheadTarget = Mathf.Abs(xMoveDelta) > lookAheadMoveThreshold;

//        if (updateLookAheadTarget)
//        {
//            lookAheadPos = lookAheadFactor * Vector3.right * Mathf.Sign(xMoveDelta);
//        }
//        else
//        {
//            lookAheadPos = Vector3.MoveTowards(lookAheadPos, Vector3.zero, Time.deltaTime * lookAheadReturnSpeed);
//        }

//        Vector3 aheadTargetPos = player.position + lookAheadPos + Vector3.forward * offsetZ;
//        Vector3 newPos = Vector3.SmoothDamp(transform.position, aheadTargetPos, ref currentVelocity, cameraSpeed);

//        // Clamp to camera boundaries
//        newPos = new Vector3(
//            Mathf.Clamp(newPos.x, minCameraPos.x, maxCameraPos.x),
//            Mathf.Clamp(newPos.y, minCameraPos.y, maxCameraPos.y),
//            newPos.z
//        );

//        // Update camera position
//        transform.position = newPos;

//        lastTargetPosition = player.position;
//    }

//    public void MoveToNewRoom(Transform _newRoom)
//    {
//        currentPosX = _newRoom.position.x;
//    }
//}
