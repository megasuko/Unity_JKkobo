using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class VRControllerData : MonoBehaviour
{
    public XRNode node;
    public bool tracked = false; // �f�[�^�擾�\��
    public Vector3 position; // �ʒu
    public Quaternion rotation; // ����
    public Vector3 velocity; // ���x
    public Vector3 acceleration; // �����x
    public Vector3 angularVelocity; // �p���x
    public Vector3 angularAcceleration; // �p�����x

    // Update is called once per frame
    void Update()
    {
        // ���ׂẴm�[�h�̃f�[�^���擾����

        // �f�[�^�p��List��p�ӂ���
        List<XRNodeState> states = new List<XRNodeState>();
        // �ŐV�̃f�[�^���擾����i�S�m�[�h���j
        InputTracking.GetNodeStates(states);
        // �擾�����f�[�^���m�F����
        foreach (XRNodeState s in states)
        {
            if (s.nodeType == node) // �m�[�h��������...
            {
                // �f�[�^�̎擾������
                tracked = s.tracked;
                s.TryGetPosition(out position);
                s.TryGetRotation(out rotation);
                s.TryGetVelocity(out velocity);
                s.TryGetAcceleration(out acceleration);
                s.TryGetAngularVelocity(out angularVelocity);
                s.TryGetAngularAcceleration(out angularAcceleration);
                break; // ����ȏニ�[�v�𑱂��Ȃ�
            }
        }
    }
}
