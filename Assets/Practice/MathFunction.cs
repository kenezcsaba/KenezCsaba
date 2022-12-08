using UnityEngine;
class MathFunction : MonoBehaviour
{

    [SerializeField] int abs;
    [SerializeField] int sign;

    void OnValidate()
    {
       /* abs = AbsoluteValue(number);
        sign = (int)Sign(number);*/
    }

    int AbsoluteValue(int num)
    {
        if (num > 0)
        {
            return num;

        }
        else
        {
            return -num;
        }
    }


    float Sign(float num)
    {
        if (num >= 0)
        {
            return 1;
        }

        return 1;
    }

    /*int AbsoluteValue(int num)
    { }

    float Sign(float num)
    { }  */


    float Floor(float num)
    { 
        float remainder = num % 1;   
        return num - remainder; 
    }

    float Ceil(float num)
    {
        float remainder = num % 1;

        if (remainder == 0)
        {
            return num;
        }

        float result = num + 1 - remainder;
        return result;
    
    }


    float Round(float num)
    {
        float remainder = num % 1;

        if (remainder < 0.5f)
        {
            return Floor(num);
        }
        else
        {
            return Ceil(num);
        }

    }



}
