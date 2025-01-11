namespace SagaDesign.Services;

public class InventoryService
{
    public async Task<bool> ReserveInventoryAsync(Order order)
    {
        Console.WriteLine($"Sipariş {order.Id} için envanter rezerve ediliyor.");
        await Task.Delay(100); // Asenkron işlem simülasyonu
        return true; // Basitlik için başarılı kabul ediliyor
    }

    public async Task UndoReserveInventoryAsync(Order order)
    {
        Console.WriteLine($"Sipariş {order.Id} için envanter rezervasyonu geri alınıyor.");
        await Task.Delay(100); // Asenkron işlem simülasyonu
    }
}