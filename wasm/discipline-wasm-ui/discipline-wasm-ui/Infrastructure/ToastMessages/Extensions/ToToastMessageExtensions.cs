using BlazorBootstrap;

namespace discipline_wasm_ui.Infrastructure.Helpers;

internal static class ToToastMessageExtensions
{
    internal static ToastMessage ToDangerToastMessage(this string value)
        => new ToastMessage()
        {
            Type = ToastType.Danger,
            Message = value
        };
}