using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class VRControllerData : MonoBehaviour
{
    public XRNode node;
    public bool tracked = false; // データ取得可能か
    public Vector3 position; // 位置
    public Quaternion rotation; // 向き
    public Vector3 velocity; // 速度
    public Vector3 acceleration; // 加速度
    public Vector3 angularVelocity; // 角速度
    public Vector3 angularAcceleration; // 角加速度

    // Update is called once per frame
    void Update()
    {
        // すべてのノードのデータを取得する

        // データ用のListを用意する
        List<XRNodeState> states = new List<XRNodeState>();
        // 最新のデータを取得する（全ノード分）
        InputTracking.GetNodeStates(states);
        // 取得したデータを確認する
        foreach (XRNodeState s in states)
        {
            if (s.nodeType == node) // ノードが合えば...
            {
                // データの取得を試す
                tracked = s.tracked;
                s.TryGetPosition(out position);
                s.TryGetRotation(out rotation);
                s.TryGetVelocity(out velocity);
                s.TryGetAcceleration(out acceleration);
                s.TryGetAngularVelocity(out angularVelocity);
                s.TryGetAngularAcceleration(out angularAcceleration);
                break; // これ以上ループを続けない
            }
        }
    }
}
