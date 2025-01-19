# Project Title

Business Days Calculator

## Description

Business Days Calculator is a C# utility that helps in calculating the number of week days as well as business days between two dates. It supports complex public holidays like fixed-date holidays, holidays with carry-forward rules, and dynamic holidays based on occurrence (eg second Monday in June).

## Getting Started

## Usage

### Public Holiday Classes

#### 1. **FixedPublicHoliday**
Represents a holiday on a fixed date (e.g., 25th December).

```csharp
var christmas = new FixedPublicHoliday(2025, 12, 25, carryForward: true, name: "Christmas Day");
```

#### 2. **DynamicPublicHoliday**
Represents a holiday based on a particular occurrence (e.g., second Monday in June).

```csharp
var kingsBirthday = new DynamicPublicHoliday(2025, 6, DayOfWeek.Monday, 2, name: "King's Birthday");
```

### Example: Calculating Business Days
```csharp
DateTime firstDate = new DateTime(2025, 6, 1);
DateTime secondDate = new DateTime(2025, 6, 30);

var publicHolidays = new List<BaseHoliday>
{
    new DynamicPublicHoliday(2025, 6, DayOfWeek.Monday, 2, name: "King's Birthday"),
    new FixedPublicHoliday(2025, 6, 22, true, name: "Random Holiday")
};

var weekdays = businessDaysCounter.WeekdaysBetweenTwoDates(startDate, endDate);
var businessDays = BusinessDaysBetweenTwoDates(firstDate, secondDate, publicHolidays);
Console.WriteLine($"Weekdays: {weekdays}");
Console.WriteLine($"Business Days: {businessDays}");

```

### Output
For the above example, the output will be:
```
Weekdays: 20
Business Days: 18
```

## Method Descriptions

### `BusinessDaysBetweenTwoDates`
Calculates business days between two dates, excluding weekends and public holidays.

#### Parameters:
- `DateTime firstDate`: The start date (excluded from calculation).
- `DateTime secondDate`: The end date (excluded from calculation).
- `IList<BaseHoliday> publicHolidays`: List of holiday rules.

#### Returns:
- `int`: The total number of business days.

---

### `WeekdaysBetweenTwoDates`
Calculates the total weekdays (Monday to Friday) between two dates, excluding start and end dates.

#### Parameters:
- `DateTime firstDate`: The start date (excluded from calculation).
- `DateTime secondDate`: The end date (excluded from calculation).

#### Returns:
- `int`: The total number of weekdays.

## How It Works
1. **Calculate Weekdays**: Count all weekdays between the given dates.
2. **Filter Public Holidays**: Exclude any holidays that:
   - Fall within the date range.
   - Are weekdays (Monday to Friday).
3. **Compute Business Days**: Subtract the filtered holidays from the total weekdays.


