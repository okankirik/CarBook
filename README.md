CarBook Projesi

🚀 Proje Hakkında
CarBook, bir araç kiralama sisteminin API tarafını geliştirmeye odaklanmıştır. Bu proje, özellikle Onion Mimarisi'nin ASP.NET Core API projelerinde nasıl uygulanacağını öğrenmek isteyen geliştiriciler için harika bir kaynaktır. Temel seviyede ASP.NET Core bilgisine sahip olan ve mimari desenlerini derinlemesine incelemek isteyenler için ideal bir yapı sunar.

✨ Öne Çıkan Özellikler ve Kullanılan Teknolojiler
Bu projede sadece güçlü bir mimari değil, aynı zamanda birçok popüler tasarım deseni ve modern ASP.NET Core özelliği kullanılmıştır:

Mimari: Onion Mimarisi
Tasarım Desenleri:
CQRS (Command Query Responsibility Segregation): Komut ve Sorgu sorumluluklarının ayrılması.
Mediator: Uygulama katmanları arasındaki iletişimi basitleştirmek için kullanılır.
Repository: Veri erişim katmanını soyutlamak ve iş mantığından ayırmak için kullanılır.
Kimlik Doğrulama: Json Web Token (JWT) ile güvenli API erişimi.
Gerçek Zamanlı İletişim: SignalR ile anlık bildirimler veya gerçek zamanlı veri akışı.
DTO (Data Transfer Object): Veri transferi için optimize edilmiş nesneler.
Doğrulama: Fluent Validation ile güçlü ve esnek veri doğrulama kuralları.

🛠️ Kurulum ve Çalıştırma
Projeyi yerel ortamınızda çalıştırmak için aşağıdaki adımları izlemeniz gerekmektedir:

1) Depoyu Klonlayın:
git clone https://github.com/okankirik/CarBook.git
cd CarBook

2) Çözümü Açın:
CarBook.sln dosyasını açın.

3) Bağımlılıkları Yükleyin:

Çözümü açtıktan sonra, projenin NuGet paket bağımlılıklarını otomatik olarak geri yüklemesi gerekir. Geri yüklenmezse, her bir projenin bağımlılıklarını manuel olarak yükleyebilirsiniz.

4) Veritabanı Ayarları ve Migrasyonlar:

CarBook.Persistence veya ilgili katmanda veritabanı bağlantı dizgesini (connection string) kendi veritabanı ayarlarınıza göre güncelleyin.
Entity Framework Core migrasyonlarını çalıştırarak veritabanı şemasını oluşturun ve güncelleyin:

5) Projenizi Çalıştırın:
CarBook.WebApi projesini başlangıç projesi olarak ayarlayın ve çalıştırın.
