using System.Net;
using System.Net.Http.Json;
using discipline.core.Communication.HttpClients.Abstractions;
using discipline.core.Dispatchers.Abstractions;
using discipline.core.Dispatchers.Models.DailyProductivity;
using discipline.core.DTOs;
using Microsoft.Extensions.Logging;

namespace discipline.core.Dispatchers.Internals;

internal sealed class DailyProductivityDisciplineAppDispatcher(
    ILogger<DailyProductivityDisciplineAppDispatcher> logger,
    IDisciplineAppClient disciplineAppClient) : IDailyProductivityDisciplineAppDispatcher
{
    public async Task<ResponseDto> CreateTodayActivity(ActivityRequest request)
    {
        var response = await disciplineAppClient.PostAsync("/daily-productive/current/add-activity", request);
        switch (response.StatusCode)
        {
            case HttpStatusCode.Created:
            {
                return ResponseDto.GetValid();
            }
            case (HttpStatusCode.BadRequest or HttpStatusCode.UnprocessableEntity):
            {
                var errorResult = await response.Content.ReadFromJsonAsync<ErrorResponseDto>();
                return ResponseDto.GetInvalid(errorResult.Message);
            }
            default:
                return ResponseDto.GetInvalid();
        }
    }

    public async Task<DailyProductivityDto> GetDailyProductivityByDay(DateOnly day)
    {
        var response = await disciplineAppClient.GetAsync($"daily-productivity/{day:yyyy-MM-dd}");
        if (response.StatusCode is HttpStatusCode.NoContent)
        {
            return null;
        }
        return await response.Content.ReadFromJsonAsync<DailyProductivityDto>();
    }
}