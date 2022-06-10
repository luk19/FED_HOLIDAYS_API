// Title: API Project for US Federal Holidays
// Start Date: June 4th, 2022
// End Date: June 9th, 2022
// Developer: Luke Browning


// Imported Libraries
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Globalization;
using System.Data.SQLite;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;


namespace Holiday_API
{
    public class Program
    {
        
        public static string GetHolidayData(string dateSelected)  
        {
            
            // Get current project path
            var myCurrentDirectory = Environment.CurrentDirectory.Replace("Unit_Tests_for_Holiday_API/bin/Debug/net6.0", "Holiday_API");

            // Date Input Verification
            DateTime dateTime;
            string expectedFormat = "yyyy-MM-dd HH:mm:ss:fff";
            string emptyString = "";
            if (dateSelected == emptyString)
            {
                return "{\"ERROR\": \"No date was given for endpoint /isHoliday\"}";
            }
            if (!DateTime.TryParseExact(dateSelected, expectedFormat, CultureInfo.InvariantCulture, DateTimeStyles.None, out dateTime))
            {
                return "{\"ERROR\": \"Input date does not match ISO 8601 Format\", \"ExpectedFormatExample\": \"2021-01-01 14:00:00:123\"}";
            }

            // SQLite database connection
            string databaseName = "Luke_Brownings_Database";
            string databasePathName = myCurrentDirectory + "/" + databaseName;
            Console.WriteLine("Opening connection to " + databaseName);
            SQLiteConnection db = new SQLiteConnection("Data Source=" + databasePathName);
            db.Open();

            // Grab DB results with selected date
            string dateSelectedsub = dateSelected.Substring(0, 10);
            string selectStatement = "select * from US_FED_HOLIDAYS WHERE Date = '" + dateSelectedsub + "'";
            SQLiteCommand selectCommand = new SQLiteCommand(selectStatement, db);
            SQLiteDataReader dataReader = selectCommand.ExecuteReader();
            DataTable dt = new DataTable("US_FED_HOLIDAYS_TABLE");
            dt.Load(dataReader);
            
            // Iterate through rows in the returned SQL data and determine if selected date is a holiday
            bool wasDataReturned = false;
            string holidayData = "";
            foreach(DataRow row in dt.Rows)
            {
                wasDataReturned = true;
                string ID = row["ID"].ToString();
                string Date = dateSelected;
                string Name = row["Name"].ToString();
                string Description = row["Description"].ToString();
                string Fixed_or_Floating = row["Fixed_or_Floating"].ToString();
                holidayData = "{\"ID\": " + ID + ", \"isHoliday\": " + wasDataReturned + ", \"Date\": \"" + Date + "\", \"Name\": \"" + Name + "\", \"Description\": \"" + Description + "\", \"Fixed_or_Floating\": \"" + Fixed_or_Floating + "\"}";
            }
            if (!wasDataReturned)
            {
                holidayData = "{\"isHoliday\": " + wasDataReturned + ", \"Date\": \"" + dateSelected + "\"}";
                Console.WriteLine("SQL command returned nothing.. Date is not a holiday!");
            }
            
            // Close database connection
            Console.WriteLine("Closing connection to " + databaseName);
            db.Close();
            
            return holidayData;
        }


        public static void Main(string[] args)
        {
            
            // Simple API Build & Run
            var app = WebApplication.CreateBuilder(args).Build();
            app.MapGet("/", () => "Hello Federal Holidays API User! Please see the following endpoint example to get started: base-url/isHoliday/2021-01-01 14:00:00:123");
            app.MapGet("/isHoliday", () =>
            {
                string dateSelected = "";
                string holidayResults = Program.GetHolidayData(dateSelected);
                return Results.Text(holidayResults, contentType: "application/json");
            });
            app.MapGet("/isHoliday/{dateSelected}", (string dateSelected) =>
            {
                string holidayResults = Program.GetHolidayData(dateSelected);
                return Results.Text(holidayResults, contentType: "application/json");
            });
            app.Run();
        }
    }
}
