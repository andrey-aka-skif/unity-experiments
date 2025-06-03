using UnityEngine;

namespace Assets.Experiment07.VideoSlider
{
    public static class TransformExtensions
    {
        public static T GetComponentInChildrenOrThrow<T>(this Transform transform) where T : Component
        {
            var component = transform.GetComponentInChildren<T>();

            return component
                ?? throw new System.NullReferenceException(
                    $"Component of type {typeof(T).Name} not found in children of {transform.name}"
                );
        }
    }
}
