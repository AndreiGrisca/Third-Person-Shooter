using UnityEngine;

namespace Utility
{
    public class IndestructibleObject : MonoBehaviour
    {
        private void Awake()
        {
            DontDestroyOnLoad(this);
        }
    }
}
