using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    [SerializeField] private GameObject ObjectToPool;

    private int MaxPoolSize = 20;
    private Stack<GameObject> inactiveObjects = new Stack<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
    if (ObjectToPool != null)
    {
        for (int i = 0; i < MaxPoolSize; i++)
        {
            var newObject = Instantiate(ObjectToPool);
            newObject.SetActive(false);
            inactiveObjects.Push(newObject);
        }
    }
        
    }

    public GameObject GetObjectFromPool()
    {
        while (inactiveObjects.Count > 0)
        {
            var Object = inactiveObjects.Pop();
            if (Object != null)
            {
                Object.SetActive(true);
                return Object;
            }
        }
        return null;
    }

    public void ReturnObjectToPool(GameObject ObjectToDeactivate)
    {
        if(ObjectToDeactivate != null)
        {
            ObjectToDeactivate.SetActive(false);
            inactiveObjects.Push(ObjectToDeactivate);
        }
    }
}
