using UnityEngine;
using System.Collections;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerInput : MonoBehaviour
{

    public float vSensitivity = 10;
    public float hSensitivity = 0.5f;
    [SerializeField]
    private float hInput;
    [SerializeField]
    private float vInput;

    void FixedUpdate()
    {
        hInput = CrossPlatformInputManager.GetAxis("Horizontal") ;
        vInput = CrossPlatformInputManager.GetAxis("Vertical") ;

        CarPlayer.Instance.Speedup(vInput * vSensitivity);
        CarPlayer.Instance.Turn(hInput * hSensitivity);

        //方向盘的转向不属于信息显示，而是控制模块的视觉显示，所以放在 Input 模块处理
        InfoDisplay.Instance.RotateSteerWheel(hInput);
    }
}
