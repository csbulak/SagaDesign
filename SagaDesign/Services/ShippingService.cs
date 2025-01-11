namespace SagaDesign.Services;

public class ShippingService
{
    public async Task<bool> ShipOrderAsync(Order order)
    {
        Console.WriteLine($"Sipariş {order.Id} gönderiliyor.");
        await Task.Delay(100); // Asenkron işlem simülasyonu
        return true; // Basitlik için başarılı kabul ediliyor
    }

    public async Task UndoShipOrderAsync(Order order)
    {
        Console.WriteLine($"Sipariş {order.Id} için gönderim iptal ediliyor.");
        await Task.Delay(100); // Asenkron işlem simülasyonu
    }
}