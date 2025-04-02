using BlazorBootstrap;
using discipline_wasm_ui.Infrastructure.Services.DTOs;

namespace discipline_wasm_ui.Infrastructure.Helpers;

internal static class ToToastMessageExtensions
{
    internal static ToastMessage ToDangerToastMessage(this string value)
        => new ToastMessage()
        {
            Type = ToastType.Danger,
            Message = value
        };

    internal static ToastMessage ToToastMessage(this ResponseDto responseDto)
        => new ToastMessage()
        {
            Message = responseDto.Message,
            Type = responseDto.IsValid ? ToastType.Success : ToastType.Danger
        };
}