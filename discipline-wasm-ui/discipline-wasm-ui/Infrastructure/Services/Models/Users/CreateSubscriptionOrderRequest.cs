using discipline_wasm_ui.Infrastructure.Services.Enums;

namespace discipline_wasm_ui.Services.Models.Users;

public class CreateSubscriptionOrderRequest
{
    public Guid SubscriptionId { get; set; }
    public SubscriptionOrderFrequency SubscriptionOrderFrequency { get; set; }
    public string CardNumber { get; set; }
    public string CardCvvNumber { get; set; }
}