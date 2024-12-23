using UnityEngine;

public class BananaSound : MonoBehaviour
{
    public AudioClip bananaSound; // حقل الصوت الذي ستضعه في Inspector
    private AudioSource audioSource; // مكون AudioSource للموزه

    void Start()
    {
        // احصل على مكون AudioSource من الموزه
        audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // تأكد أن التصادم مع السيارة
        {
            // تشغيل الصوت عند الاصطدام
            audioSource.PlayOneShot(bananaSound);
            
            // إخفاء الموزه بعد التصادم
            Destroy(gameObject, 1f); // تأخير الاختفاء لمدة ثانية بعد التصادم
        }
    }
}
