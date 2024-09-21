using System.Collections;
using UnityEngine;

namespace LordBreakerX.Utilities.Movement
{
    public static class MovementUtility
    {
        public static void MoveToPosition(this Transform transformToMove, Vector3 position)
        {
            if (transformToMove != null)
            {
                transformToMove.position = position;
            }
        }

        public static IEnumerator MoveToPositionOverTime(this Transform transformToMove, Vector3 end, float time)
        {
            if (transformToMove != null)
            {
                Vector3 start = transformToMove.position;
                float elapsed = 0.0f;

                while (elapsed < time)
                {
                    transformToMove.position = Vector3.Lerp(start, end, elapsed / time);
                    elapsed += Time.deltaTime;
                    yield return null;
                }
            }
        }

        public static void MoveInDirection(this Transform transformToMove, MoveDirection direction, float amount)
        {
            if (transformToMove != null)
            {
                Vector3 movement = GetDirectionalMovement(direction);
                transformToMove.position += movement * amount;
            }
        }

        public static void MoveInDirection(this Rigidbody rigidbodyToMove, MoveDirection direction, float amount)
        {
            if (rigidbodyToMove != null)
            {
                Vector3 movement = GetDirectionalMovement(direction);
                rigidbodyToMove.MovePosition(rigidbodyToMove.gameObject.transform.position + movement * amount);
            }
        }

        public static IEnumerator MoveToPositionOverTime(this Rigidbody rigidbodyToMove, Vector3 end, float time)
        {
            if (rigidbodyToMove != null)
            {
                Vector3 start = rigidbodyToMove.position;
                float elapsed = 0.0f;

                while (elapsed < time)
                {
                    Vector3 newPosition = Vector3.Lerp(start, end, elapsed / time);
                    rigidbodyToMove.MovePosition(newPosition);
                    elapsed += Time.deltaTime;
                    yield return null;
                }
            }
        }

        public static void MoveInDirection(this Rigidbody2D rigidbodyToMove, MoveDirection direction, float amount)
        {
            if (rigidbodyToMove != null)
            {
                Vector3 movement = GetDirectionalMovement(direction);
                rigidbodyToMove.MovePosition(rigidbodyToMove.gameObject.transform.position + movement * amount);
            }
        }

        public static IEnumerator MoveToPositionOverTime(this Rigidbody2D rigidbodyToMove, Vector3 end, float time)
        {
            if (rigidbodyToMove != null)
            {
                Vector3 start = rigidbodyToMove.position;
                float elapsed = 0.0f;

                while (elapsed < time)
                {
                    Vector3 newPosition = Vector3.Lerp(start, end, elapsed / time);
                    rigidbodyToMove.MovePosition(newPosition);
                    elapsed += Time.deltaTime;
                    yield return null;
                }
            }
        }

        private static Vector3 GetDirectionalMovement(MoveDirection direction)
        {
            Vector3 movement = Vector3.zero;

            switch (direction)
            {
                case MoveDirection.Left:
                    movement = Vector3.left;
                    break;
                case MoveDirection.Right:
                    movement = Vector3.right;
                    break;
                case MoveDirection.Up:
                    movement = Vector3.up;
                    break;
                case MoveDirection.Down:
                    movement = Vector3.down;
                    break;
                case MoveDirection.forward:
                    movement = Vector3.forward;
                    break;
                case MoveDirection.back:
                    movement = Vector3.back;
                    break;
            }

            return movement;
        }
    }
}
