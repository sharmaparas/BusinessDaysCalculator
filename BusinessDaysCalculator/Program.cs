using BusinessDaysCalculator;
Console.WriteLine($"Paras Sharma: BusinessDaysCounter");

DateTime startDate = new DateTime(2025, 6, 1);
DateTime endDate = new DateTime(2025, 6, 30);

var publicHolidays = new List<BaseHoliday>
            {
                new DynamicPublicHoliday(2025, 6, DayOfWeek.Monday, 2, name: "King's Birthday"),
                new FixedPublicHoliday(2025, 6, 22, true, name: "Random Holiday")
            };
Console.WriteLine($"StartDate = {startDate.ToString("dd/MM/yyyy")}\nEndDate = {endDate.ToString("dd/MM/yyyy")}");
Console.WriteLine($"Public Holdidays - ");
foreach ( var publicHoliday in publicHolidays )
{
    Console.WriteLine($"{publicHoliday.Name}: {publicHoliday.Date.Value.ToString("dd/MM/yyyy")}"); // Ignoring null checks
}
var businessDaysCounter = new BusinessDaysCounter();
var weekdaysBetweenTwoDates = businessDaysCounter.WeekdaysBetweenTwoDates(startDate, endDate);
var businessDaysBetweenTwoDates = businessDaysCounter.BusinessDaysBetweenTwoDates(startDate, endDate, publicHolidays);
Console.WriteLine($"WeekdaysBetweenTwoDates in days: {weekdaysBetweenTwoDates}");
Console.WriteLine($"BusinessDaysBetweenTwoDates in days: {businessDaysBetweenTwoDates}");

