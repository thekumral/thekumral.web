# thekumral.web
Bu proje, web ve kontrol paneli işlevsellikleri için sağlam bir mimari sağlamak üzere tasarlanmış çok katmanlı bir uygulamadır. Aşağıda her katman ve kullanılan teknolojiler hakkında genel bir bilgi bulacaksınız.

## Katmanlar

### thekumral.Api
Bu katman, hem `thekumral.Web` hem de `thekumral.Web.Dashboard` için API uç noktalarını yönetir. Temel özellikler:
- **Controller'lar**: Uç noktaları tanımlar.
- **Kimlik Doğrulama**: Bearer Authorization.
- **Filtreler**: Özel filtreler (ör. `[ServiceFilter(typeof(NotFoundFilter<Company>))]`).
- **Özel Hatalar**: Çeşitli hataları ele alır.
- **Controller'lar**: `Post`, `Company`, `Auth`, `Account`.

### thekumral.Caching
Önbellekleme katmanı, sık erişilen verileri saklayarak performansı artırır. Temel bileşenler:
- **Bağımlılıklar**: `System.Threading.Tasks`, `AutoMapper`, `Microsoft.EntityFrameworkCore`, `Microsoft.Extensions.Caching.Memory`.
- **Önbellekleme Uygulaması**: `IMemoryCache` kullanır.
- **PostServiceWithCaching**: Postlar için önbellekleme uygulayan örnek bir servis.

### thekumral.Core
Çekirdek katman, projenin temel bileşenlerini içerir:
- **DTO Varlıkları**: Identity kütüphanesini kullanır.
- **Repository Arayüzleri**: `IGenericRepository`.
- **Servisler**: Token ve e-posta yönetimi.
- **Unit of Work**: İşlem yönetimi için `IUnitOfWork` arayüzü.

### thekumral.Repository
Bu katman, veri erişimi ve veritabanı işlemlerini yönetir:
- **Yapılandırma**: Seed verilerini içerir.
- **Migrations**: Veritabanı şema değişikliklerini yönetir.
- **Repository'ler**: Veritabanı sorguları için genel repository deseni.
- **Unit of Work**: İşlem yönetimi uygular.
- **AppDbContext**: `IdentityDbContext<User, Role, Guid>` genişletir.

### thekumral.Service
Servis katmanı, iş mantığını ve yardımcı servisleri sağlar:
- **Hatalar**: `ClientSideException`, `NotFoundException` gibi özel hatalar.
- **Mapping**: Nesne-nesne dönüşümleri için AutoMapper.
- **Servisler**: `CompanyService` gibi belirli servisler.
- **Doğrulamalar**: Veriler için FluentValidation.

### thekumral.Web
Web katmanı, projenin görünen kısmıdır ve şirketin web sitesi için MVC mimarisini uygular:
- **MVC Uygulaması**: API çağrılarını yönetir ve görünümleri render eder.

### thekumral.Web.Dashboard
Bu katman, gönderi işlemlerinin (ekleme, silme, güncelleme) yapıldığı kontrol panelini yönetir:
- **Kontrol Paneli İşlevselliği**: İçeriği yönetmek için API ile entegre olur.

## Kullanılan Teknolojiler

- **ASP.NET Core**: Web uygulamaları ve API'ler için çerçeve.
- **Entity Framework Core**: Veritabanı erişimi için ORM.
- **AutoMapper**: Nesne-nesne dönüşümleri.
- **FluentValidation**: Veri doğrulama kütüphanesi.
- **IMemoryCache**: Bellek içi önbellekleme.
- **Identity**: Kimlik doğrulama ve yetkilendirme.

## Kurulum

Başlamak için, projeyi klonlayın ve aşağıdaki adımları izleyin:

1. Gerekli paketleri yükleyin:
    ```bash
    dotnet restore
    ```

2. Migrations'ları uygulayın:
    ```bash
    dotnet ef database update
    ```

3. Uygulamayı çalıştırın:
    ```bash
    dotnet run
    ```

## Katkıda Bulunma

Katkılar memnuniyetle karşılanır! Lütfen projeyi fork'layın ve değişikliklerinizle bir pull request oluşturun.

## Lisans
