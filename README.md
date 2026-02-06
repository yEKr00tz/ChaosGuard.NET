ChaosGuard.NET 🌪️ (v1.0)
English | Türkçe

English
.NET-based resilience middleware designed to evaluate system behavior under simulated latency, faults, and resource pressure.

🚀 Key Features
Dynamic Fault Injection: Injects real-time failure scenarios into the request pipeline.

Environment Safety: Built-in safeguards to ensure chaos only runs in Development environments.

Observability: Integrated logging to monitor how the system reacts to specific failure modes.

🔍 Simulated Scenarios
Critical: 500 Internal Server Error (Simulates unhandled exceptions and service crashes).

High: Latency Injection (3s - 7s delays to test timeout management and UX).

Medium: Resource Stress (Temporary memory spikes to analyze stability).

🛠️ Usage
Add ChaosResilienceMiddleware.cs to your project.

Register in Program.cs:

```csharp
if (app.Environment.IsDevelopment()) {
    app.UseMiddleware<ChaosResilienceMiddleware>();
}
```
Monitor the logs while interacting with your application.

Türkçe
.NET tabanlı uygulamaların gecikme, hata ve kaynak baskısı altındaki davranışlarını ölçmek için geliştirilmiş Resilience (Dayanıklılık) ara yazılımıdır.

🚀 Öne Çıkan Özellikler
Dinamik Hata Enjeksiyonu: İstek boru hattına (request pipeline) gerçek zamanlı hata senaryoları dahil eder.

Ortam Güvenliği: Kaos senaryolarının sadece Development ortamında çalışmasını sağlayan emniyet kilitleri içerir.

Gözlemlenebilirlik: Sistemin hata modlarına verdiği tepkileri izlemek için entegre loglama sunar.

🔍 Simüle Edilen Senaryolar
Kritik: 500 Internal Server Error (Beklenmedik servis çökmelerini simüle eder).

Yüksek: Gecikme Enjeksiyonu (Zaman aşımı yönetimi ve kullanıcı deneyimi testi için 3-7sn lag).

Orta: Kaynak Baskısı (Anlık bellek artışları ile sistem stabilitesi analizi).

🛠️ Kullanım
ChaosResilienceMiddleware.cs dosyasını projenize ekleyin.

Program.cs dosyasına kaydedin:

```csharp
if (app.Environment.IsDevelopment()) {
    app.UseMiddleware<ChaosResilienceMiddleware>();
}
```
Uygulamanızı kullanırken log ekranından kaos çıktılarını takip edin.

⚖️ Disclaimer / Yasal Uyarı
English: This tool is for testing and development purposes only. Never enable chaos injection in a production environment as it can cause service unavailability for real users.

Türkçe: Bu araç sadece test ve geliştirme amaçlıdır. Kaos enjeksiyonunu asla canlı (production) ortamda aktif etmeyin; gerçek kullanıcılar için servis kesintilerine yol açabilir.
