using discipline.core.Helpers.Enums;

namespace discipline.core.Dispatchers.Models.Users;

public class CreateSubscriptionOrderRequest
{
    public Guid SubscriptionId { get; set; }
    public SubscriptionOrderFrequency SubscriptionOrderFrequency { get; set; }
    public string CardNumber { get; set; }
    public string CardCvvNumber { get; set; }
}