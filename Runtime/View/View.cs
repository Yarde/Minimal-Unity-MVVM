using System;
using UnityEngine;

namespace Yarde.MVVM.View
{
    public abstract class View : MonoBehaviour, IDisposable
    {
        public abstract void Dispose();
    }
}