using UnityEngine;
using Cinemachine;
public class LookController : CinemachineExtension
{
    private InputController inputController;
    private Vector3 rotation;

    [SerializeField] private float clampAngle = 80f;
    [SerializeField] private float horizontalSpeed = 10f;
    [SerializeField] private float verticalSpeed = 10;

    [SerializeField] private bool invertY;

    protected override void Awake()
    {
        inputController =  InputController.instance;
        rotation = transform.localRotation.eulerAngles;

        base.Awake();
    }

    protected override void PostPipelineStageCallback(CinemachineVirtualCameraBase vcam, CinemachineCore.Stage stage, ref CameraState state, float deltaTime)
    {

        if (vcam.Follow) 
        {
            if(stage == CinemachineCore.Stage.Aim) 
            {


                Vector2 deltaInput = inputController.GetLook();

                if (invertY) deltaInput.y = deltaInput.y * -1;

                rotation.x += deltaInput.x *horizontalSpeed* Time.fixedDeltaTime;
                rotation.y += deltaInput.y *verticalSpeed* Time.fixedDeltaTime;

                rotation.y = Mathf.Clamp(rotation.y, -clampAngle, clampAngle);

                state.RawOrientation = Quaternion.Euler(rotation.y, rotation.x,0f); 
                    


            }

        }

    }
}
