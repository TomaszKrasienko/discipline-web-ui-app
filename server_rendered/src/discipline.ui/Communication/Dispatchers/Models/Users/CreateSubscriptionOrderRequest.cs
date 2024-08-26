using discipline.ui.Communication.Helpers.Enums;

namespace discipline.ui.Communication.Dispatchers.Models.Users;

public class CreateSubscriptionOrderRequest
{
    public Guid SubscriptionId { get; set; }
    public SubscriptionOrderFrequency SubscriptionOrderFrequency { get; set; }
    public string CardNumber { get; set; }
    public string CardCvvNumber { get; set; }
}