using discipline_wasm_ui.Infrastructure.Services.DTOs;
using discipline_wasm_ui.Infrastructure.Services.Models.ActivityRules;

namespace discipline_wasm_ui.Infrastructure.Mappers;

internal static class ActivityRuleMapper
{
    internal static ActivityRuleRequest AsRequest(this ActivityRuleDto dto)
        => new ActivityRuleRequest()
        {
            Title = dto.Title,
            Mode = dto.Mode,
            SelectedDays = dto.SelectedDays
        };
}