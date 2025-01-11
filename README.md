# SagaDesign Projesi

SagaDesign, dağıtık işlemleri yönetmek için **Saga deseninin** uygulanmasını gösteren bir C# projesidir. Bu proje, envanter yönetimi, ödeme işleme ve gönderim hizmetlerini içermekte olup, tüm işlemlerin ya başarıyla tamamlanmasını ya da başarısızlık durumunda telafi edilmesini sağlamayı amaçlar.

## Proje Yapısı

- **SagaDesign.sln**: Projenin çözüm dosyası.
- **SagaDesign/Order.cs**: `Id`, `Product` ve `Amount` gibi özelliklere sahip `Order` sınıfını tanımlar.
- **SagaDesign/Services/OrderSagaService.cs**: Saga desenini kullanarak sipariş işleme iş akışını yöneten `OrderSagaService` sınıfını içerir.
- **SagaDesign/Services/InventoryService.cs**: Envanter rezervasyonu ve telafisini yöneten `InventoryService` sınıfını içerir.

## Ana Bileşenler

### OrderSagaService

`OrderSagaService` sınıfı, **InventoryService**, **PaymentService** ve **ShippingService** ile koordinasyon sağlayarak siparişleri işler. Süreçte herhangi bir adım başarısız olursa, önceki adımların telafi edilmesini sağlar.

### Order

`Order` sınıfı, aşağıdaki özelliklere sahip bir siparişi temsil eder:

- **Id**: Siparişin benzersiz tanımlayıcısı.
- **Product**: Sipariş edilen ürünün adı.
- **Amount**: Siparişin toplam tutarı.

### InventoryService

`InventoryService` sınıfı, envanter rezervasyonu ve gerektiğinde rezervasyonun geri alınması için yöntemler sağlar. `Task.Delay` kullanarak asenkron işlemleri simüle eder.

## Kullanım

SagaDesign projesini kullanmak için şu adımları izleyin:

1. Depoyu klonlayın.
2. Çözüm dosyasını `SagaDesign.sln` tercih ettiğiniz IDE'de (örneğin, JetBrains Rider) açın.
3. Bağımlılıkları geri yüklemek ve projeyi derlemek için çözümü oluşturun.
4. Projeyi çalıştırın ve sipariş işleme iş akışını gözlemleyin.

### Örnek

`OrderSagaService` kullanarak bir siparişi nasıl işleyeceğinize dair bir örnek:

```csharp
var inventoryService = new InventoryService();
var paymentService = new PaymentService();
var shippingService = new ShippingService();
var orderSagaService = new OrderSagaService(inventoryService, paymentService, shippingService);

var order = new Order { Id = 1, Product = "Laptop", Amount = 1500.00m };
bool result = await orderSagaService.ProcessOrderAsync(order);

Console.WriteLine(result ? "Sipariş başarıyla işlendi." : "Sipariş işleme başarısız oldu.");
```

## Lisans

Bu proje [MIT Lisansı](LICENSE) altında lisanslanmıştır. Daha fazla bilgi için `LICENSE` dosyasına bakabilirsiniz.

## Katkıda Bulunma

Katkılar memnuniyetle karşılanır! Herhangi bir iyileştirme veya hata düzeltmesi için lütfen bir **sorun** açın veya bir **çekme isteği** gönderin.

## İletişim

Herhangi bir soru veya bilgi için csbulak@gmail.com üzerinden iletişime geçebilirsiniz.
