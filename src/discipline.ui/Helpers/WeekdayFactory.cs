using discipline.ui.Models;

namespace discipline.ui.Helpers;

internal static class WeekdayFactory
{
    internal static List<Weekday> Get()
        => [
               new Weekday()
               {
                   IsChecked = false,
                   Name = "Monday",
                   Id = 1
               },
               new Weekday()
               {
                   IsChecked = false,
                   Name = "Tuesday",
                   Id = 2
               },
               new Weekday()
               {
                   IsChecked = false,
                   Name = "Wednesday",
                   Id = 3
               },
               new Weekday()
               {
                   IsChecked = false,
                   Name = "Thursday",
                   Id = 4
               },
               new Weekday()
               {
                   IsChecked = false,
                   Name = "Friday",
                   Id = 5
               },
               new Weekday()
               {
                   IsChecked = false,
                   Name = "Saturday",
                   Id = 6
               },
               new Weekday()
               {
                   IsChecked = false,
                   Name = "Sunday",
                   Id = 0
               }
           ];
}