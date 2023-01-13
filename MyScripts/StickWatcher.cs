using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class StickWatcher : MonoBehaviour
{
    [SerializeField] private XRNode leftNode = XRNode.LeftHand;
    [SerializeField] private XRNode rightNode = XRNode.RightHand;
    private InputDevice controllerL;
    private InputDevice controllerR;
    public Vector2 valueL;
    public Vector2 valueR;
    public bool primaryL;
    public bool primaryR;
    // Start is called before the first frame update
    void Start()
    {
        controllerL = InputDevices.GetDeviceAtXRNode(leftNode);
        controllerR = InputDevices.GetDeviceAtXRNode(rightNode);
    }

    // Update is called once per frame
    void Update()
    {
        InputFeatureUsage<Vector2> primary2DVector = CommonUsages.primary2DAxis;
        InputFeatureUsage<bool> primaryButton = CommonUsages.primaryButton;
        controllerL.TryGetFeatureValue(primary2DVector, out valueL);
        controllerR.TryGetFeatureValue(primary2DVector, out valueR);
        controllerL.TryGetFeatureValue(primaryButton, out primaryL);
        controllerR.TryGetFeatureValue(primaryButton, out primaryR);
    }
}
