using BlazorBootstrap;
using discipline.core.DTOs;

namespace discipline.ui.Helpers;

internal static class ResponseDtoToToastMessageExtensions
{
    internal static ToastMessage AsToastMessage(this ResponseDto responseDto, string? message = null)
        => new ToastMessage()
        {
            Type = (responseDto?.IsValid ?? false)
                ? ToastType.Success
                : ToastType.Danger,
            Message = (responseDto?.IsValid ?? false) ? message : responseDto?.Message
        };
}