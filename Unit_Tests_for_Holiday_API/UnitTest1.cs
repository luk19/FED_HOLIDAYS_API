using Microsoft.VisualStudio.TestPlatform.TestHost;
using System.Data.SQLite;

namespace Unit_Tests_for_Holiday_API;

public static class Tests
{
    [SetUp]
    public static void Setup()
    {
    }

    [Test]
    public static void Test_Empty_Date_Input()
    {
        string testDate = "";
        string hypothesis = "{\"ERROR\": \"No date was given for endpoint /isHoliday\"}";
        string result = Holiday_API.Program.GetHolidayData(testDate);
        Assert.AreEqual(hypothesis, result);
    }

    [Test]
    public static void Test_Wrong_Date_Format()
    {
        string testDate = "2021-01-01 12:00:00";
        string hypothesis = "{\"ERROR\": \"Input date does not match ISO 8601 Format\", \"ExpectedFormatExample\": \"2021-01-01 14:00:00:123\"}";
        string result = Holiday_API.Program.GetHolidayData(testDate);
        Assert.AreEqual(hypothesis, result);
    }
    
    [Test]
    public static void Test_Correct_Date_Format_with_Valid_Holiday()
    {
        string testDate = "2021-01-01 14:00:00:123";
        string hypothesis = "{\"ID\": 1, \"isHoliday\": True, \"Date\": \"" + testDate +"\", \"Name\": \"New Years Day\", \"Description\": \"The first day of the year in the modern Gregorian calendar.\", \"Fixed_or_Floating\": \"New Years Day is a fixed holiday (it has the same date each year).\"}";
        string result = Holiday_API.Program.GetHolidayData(testDate);
        Assert.AreEqual(hypothesis, result);
    }
    
    [Test]
    public static void Test_Correct_Date_Format_with_Invalid_Holiday()
    {
        string testDate = "2021-01-03 14:00:00:123";
        string hypothesis = "{\"isHoliday\": False, \"Date\": \"" + testDate + "\"}";
        string result = Holiday_API.Program.GetHolidayData(testDate);
        Assert.AreEqual(hypothesis, result);
    }
}