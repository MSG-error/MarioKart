using UnityEngine;
using TMPro; // مكتبة لتعامل مع TextMeshPro

public class CoinManager : MonoBehaviour
{
    private int totalCoins = 0; // عدد العملات الإجمالي
    public int coinValue = 10; // قيمة كل عملة تُجمع
    public static CoinManager Instance; // لجعل الكود Singleton

    [SerializeField] private TextMeshProUGUI coinText; // مرجع لواجهة النص

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // للحفاظ على الكود بين المشاهد
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            CollectCoin(); // جمع العملة
        }
    }

    private void CollectCoin()
    {
        totalCoins += coinValue; // زيادة عدد العملات
        Debug.Log("Total Coins: " + totalCoins); // طباعة العدد في الكونسول

        // تدمير العملة بعد جمعها
        Destroy(gameObject);

        // تحديث واجهة المستخدم
        UpdateUI();
    }

    private void UpdateUI()
    {
        if (coinText != null)
        {
            coinText.text = "Coins: " + totalCoins; // تحديث النص
        }
    }

    public void ResetCoins()
    {
        totalCoins = 0; // إعادة تعيين العملات
        UpdateUI(); // تحديث الواجهة
    }
}
