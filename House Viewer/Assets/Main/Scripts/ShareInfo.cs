using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShareInfo
{
    private List<_VRMainInfo> arrPosition;    

    public ShareInfo()
    {
        arrPosition = new List<_VRMainInfo>();

        arrPosition.Add(new _VRMainInfo(-0.2f, 43f, 90f)); //1
        arrPosition.Add(new _VRMainInfo(11.2f, 3.7f, -90f)); //2
        arrPosition.Add(new _VRMainInfo(-23.5f, 41f, 0f)); // 3

        arrPosition.Add(new _VRMainInfo(3.2f, 44f, 90f)); // 4
        arrPosition.Add(new _VRMainInfo(9.8f, 4.5f, -90f)); // 5
        arrPosition.Add(new _VRMainInfo(-25.3f, 41f, 0f)); // 6

        arrPosition.Add(new _VRMainInfo(4.6f, 43.5f, 90f)); // 7
        arrPosition.Add(new _VRMainInfo(11f, 4f, -90f)); // 8
        arrPosition.Add(new _VRMainInfo(-25f, 40.3f, 0f)); // 9

        arrPosition.Add(new _VRMainInfo(4f, 43.5f, 90f)); // 10
        arrPosition.Add(new _VRMainInfo(10.5f, 11f, -90f)); // 11
        arrPosition.Add(new _VRMainInfo(-18.5f, 40.6f, 90f)); // 12
    }

    public _VRMainInfo getInfo(int noOfStair)
    {
        return arrPosition[noOfStair-1];
    }

    public class _VRMainInfo
    {
        public float _xPos;
        public float _zPos;
        public float _yRot;

        public _VRMainInfo(float xPos, float zPos, float yRot)
        {
            _xPos = xPos;
            _zPos = zPos;
            _yRot = yRot;
        }
    }
}
