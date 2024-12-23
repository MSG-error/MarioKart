using UnityEngine;

public class BananaCollision : MonoBehaviour
{
    public AudioSource audioSource; // المرجع لـ AudioSource في الموزة
    public AudioClip bananaSound;  // الصوت الذي سيتم تشغيله عند الاصطدام
    private float originalSpeed;    // السرعة الأصلية للسيارة
    public float slowDownFactor = 0.1f; // نسبة التباطؤ (من 0 إلى 1)

    private KartController kartController; // مرجع إلى سكربت تحكم السيارة

    void Start()
    {
        // التأكد من أن audioSource مرفق
        if (audioSource == null)
        {
            audioSource = GetComponent<AudioSource>();
        }

        // الحصول على سكربت التحكم في السيارة
        kartController = FindObjectOfType<KartController>();

        // تخزين السرعة الأصلية للسيارة
        if (kartController != null)
        {
            originalSpeed = kartController.acceleration;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // التحقق إذا كانت السيارة هي التي تصطدم
        {
            // تشغيل الصوت عند الاصطدام
            if (audioSource != null && bananaSound != null)
            {
                audioSource.PlayOneShot(bananaSound); // تشغيل الصوت
            }

            // تباطؤ السيارة
            if (kartController != null)
            {
                kartController.acceleration *= slowDownFactor; // تقليل السرعة
            }

            // إخفاء الموزه بعد الاصطدام
            Destroy(gameObject, 0.5f); // يتم تدمير الموزه بعد 0.5 ثانية

            // إعادة السرعة بعد فترة
            Invoke("ResetSpeed", 2f); // بعد 2 ثانية يتم استعادة السرعة الأصلية
        }
    }

    void ResetSpeed()
    {
        if (kartController != null)
        {
            kartController.acceleration = originalSpeed; // إعادة السرعة الأصلية
        }
    }
}
