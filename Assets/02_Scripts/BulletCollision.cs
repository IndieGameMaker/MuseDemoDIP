// 11/23/2024 AI-Tag
// This was created with assistance from Muse, a Unity Artificial Intelligence product

using System;
using UnityEditor;
using UnityEngine;

public class BulletCollision : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        // 충돌 시 Bullet 오브젝트를 삭제
        Destroy(gameObject);
    }
}
