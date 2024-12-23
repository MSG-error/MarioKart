using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinPickUp : MonoBehaviour
{
    public AudioSource coinAudioSource; // المصدر الصوتي للعملة
    public Rigidbody sphere; // جسم السيارة للحصول على السرعة
    public float speedThreshold = 10f; // حد السرعة لتعديل الـ pitch

    private void OnTriggerEnter(Collider other)
    {
        // إذا كانت السيارة هي التي تصطدم بالعملة
        if (other.CompareTag("Player"))
        {
            // إذا كان المصدر الصوتي معرف
            if (coinAudioSource != null)
            {
                // تعديل الـ pitch بناءً على سرعة السيارة
                coinAudioSource.pitch = Mathf.Lerp(0.5f, 2.0f, sphere.linearVelocity.magnitude / speedThreshold);
                coinAudioSource.Play(); // تشغيل الصوت
            }

            // تدمير العملة بعد الاصطدام
            Destroy(gameObject);
        }
    }
}
