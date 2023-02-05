using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Kulip
{
    public abstract class TimeSOBase : ScriptableObject
    {
        abstract public float Time { get; }
        abstract public float FixedTime { get; }

        abstract public float DeltaTime { get; }
        abstract public float FixedDeltaTime { get; }
    }
}
