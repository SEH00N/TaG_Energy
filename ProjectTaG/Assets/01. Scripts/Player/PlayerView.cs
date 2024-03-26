using UnityEngine;

public class PlayerView : MonoBehaviour
{
	[SerializeField] PlayInputSO input = null;

    [Space(15f)]
    [SerializeField] Transform headTrm = null;
    [SerializeField] float sensitivity = 15f;
    
    private void FixedUpdate()
    {
        transform.Rotate(Vector3.up, input.MouseDelta.x * sensitivity * Time.fixedDeltaTime);

        Vector3 headEuler = headTrm.eulerAngles;
        if(headEuler.x > 180f)
            headEuler.x -= 360f;
        headEuler.x -= input.MouseDelta.y * sensitivity * Time.fixedDeltaTime;
        headEuler.x = Mathf.Clamp(headEuler.x, -70f, 70f);
        headTrm.eulerAngles = headEuler;
    }
}
