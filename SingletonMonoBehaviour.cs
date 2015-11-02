using UnityEngine;
/// <summary>
/// Make a class a singleton monobehaviour by simply using this class as the parent instead of the default monobehaviour.
/// Example: The type of your class - Example: class YourClass : SingletonMonoBehaviour&lt;YourClass&gt; { /*...*/ }
/// </summary>
/// <typeparam name="T">The type of your class</typeparam>
public class SingletonMonoBehaviour<T> : MonoBehaviour where T : SingletonMonoBehaviour<T>
{
    private static T instance;
    public static T Instance
    {
        get
        {
            if (instance) return instance;
            SetInstance(FindObjectOfType(typeof(T)) as T);
            return instance;
        }
    }

    public static void SetInstance(T inst)
    {
        instance = inst;
    }

    void ForceSetInstanceToThis()
    {
        SetInstance((T)this);
    }
}

