using UnityEngine;
using System.Collections;

public class FollowPlayer : MonoBehaviour
{
    public Transform target;    // ターゲットへの参照

    void Update ()
    {
        // 自分の座標にtargetの座標を代入する     
        GetComponent<Transform>().position = target.position;
    }
}