using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LukaExtras
{
    public static class Math
    {
        public static float ExpDecay(float a, float b, float decay, float dt)
        {
            return b + (a - b) * Mathf.Exp(-decay * dt);
        }

        public static Vector2 ExpDecay(Vector2 a, Vector2 b, float decay, float dt)
        {
            return b + (a - b) * Mathf.Exp(-decay * dt);
        }

        public static Vector3 ExpDecay(Vector3 a, Vector3 b, float decay, float dt)
        {
            return b + (a - b) * Mathf.Exp(-decay * dt);
        }
    }
}