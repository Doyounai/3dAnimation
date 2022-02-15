using UnityEngine;

public enum vector3Boolean
{
    x = 0,
    y = 1,
    z = 2
}

public class repeatedObject : MonoBehaviour
{
    public bool isLoop = false;
    bool isLooped = false;
    Vector3 startPosition;

    [Header("Moving Attribute")]
    public float speed;
    public vector3Boolean moveAxis = vector3Boolean.z;

    [Header("Repeat Attribute")]
    public Transform startPoint;
    public Transform endPoint;

    float checkingValue;

    private void Start()
    {
        if (isLoop)
            startPosition = transform.position;

        checkingValue = getVector3VarByIndex(endPoint.position, ((int)moveAxis));
    }

    public void FixedUpdate()
    {
        float[] velocityAxis = new float[3];
        velocityAxis[((int)moveAxis)] = speed;

        transform.position += new Vector3(velocityAxis[0], velocityAxis[1], velocityAxis[2]) * Time.fixedDeltaTime;

        if(isLooped)
        {
            if(Vector3.Distance(transform.position, startPosition) <= 0.5f)
            {
                UnityEditor.EditorApplication.isPlaying = false;
            }
        }

        if(getVector3VarByIndex(transform.position, ((int)moveAxis)) <= checkingValue)
        {
            if(isLoop)
            {
                isLooped = true;
            }

            transform.position = editvector3OnIndex(transform.position, ((int)moveAxis), getVector3VarByIndex(startPoint.position, ((int)moveAxis)));
        }
    }

    Vector3 editvector3OnIndex(Vector3 varlue, int index, float changingVarlue)
    {
        if (index == 0)
            varlue.x = changingVarlue;
        else if (index == 1)
            varlue.y = changingVarlue;
        else
            varlue.z = changingVarlue;

        return varlue;
    }

    float getVector3VarByIndex(Vector3 varlue, int index)
    {
        return (index == 0) ?
                    varlue.x :
                    (index == 1) ?
                        varlue.y :
                        varlue.z;
    }
}
