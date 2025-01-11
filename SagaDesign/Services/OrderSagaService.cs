namespace SagaDesign.Services;

public class OrderSagaService(
    InventoryService inventoryService,
    PaymentService paymentService,
    ShippingService shippingService)
{
    public async Task<bool> ProcessOrderAsync(Order order)
    {
        try
        {
            bool inventoryReserved = await inventoryService.ReserveInventoryAsync(order);
            if (!inventoryReserved)
                throw new Exception("Envanter rezervasyonu başarısız oldu.");

            bool paymentProcessed = await paymentService.ProcessPaymentAsync(order);
            if (!paymentProcessed)
                throw new Exception("Ödeme işlemi başarısız oldu.");

            bool orderShipped = await shippingService.ShipOrderAsync(order);
            if (!orderShipped)
                throw new Exception("Sipariş gönderimi başarısız oldu.");

            return true;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Hata: {ex.Message}");
            await CompensateAsync(order);
            return false;
        }
    }

    private async Task CompensateAsync(Order order)
    {
        await shippingService.UndoShipOrderAsync(order);
        await paymentService.UndoProcessPaymentAsync(order);
        await inventoryService.UndoReserveInventoryAsync(order);
    }
}