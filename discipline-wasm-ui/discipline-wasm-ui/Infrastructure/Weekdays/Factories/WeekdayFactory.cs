using discipline_wasm_ui.Infrastructure.Services.DTOs;

namespace discipline_wasm_ui.Infrastructure.Weekdays.Factories;

internal static class WeekdayFactory
{
    internal static List<WeekdayDto> Get() 
        => [
                new WeekdayDto()
                {
                    IsChecked = false,
                    Name = "Monday",
                    Id = 1
                },
                new WeekdayDto()
                {
                    IsChecked = false,
                    Name = "Tuesday",
                    Id = 2
                },
                new WeekdayDto()
                {
                    IsChecked = false,
                    Name = "Wednesday",
                    Id = 3
                },
                new WeekdayDto()
                {
                    IsChecked = false,
                    Name = "Thursday",
                    Id = 4
                },
                new WeekdayDto()
                {
                    IsChecked = false,
                    Name = "Friday",
                    Id = 5
                },
                new WeekdayDto()
                {
                    IsChecked = false,
                    Name = "Saturday",
                    Id = 6
                },
                new WeekdayDto()
                {
                    IsChecked = false,
                    Name = "Sunday",
                    Id = 0
                }
            ];
}