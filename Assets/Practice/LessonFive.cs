using UnityEngine;

public class LessonFive : MonoBehaviour
{



    // E2

    Vector3 DirectionVec(Vector3 start, Vector3 end)
    {
        return (end - start).normalized;
    }


    // C9

    float Clamp(float number, float min, float max)
    {

        if (number > max)
        {
            return max;
        }

        if (number < min)
        {
            return min;
        }
        else
        {
            return number;
        }
    }


       // D6

    float Clamp01(float number)
    {
        return Clamp(number, 0, 1);
    }

}
