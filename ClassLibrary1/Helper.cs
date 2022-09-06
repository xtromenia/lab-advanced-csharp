namespace ClassLibrary1
{
    public static class Helper
    {
        /// <summary>
        /// Checks if the provided string input is a valid payroll number.
        /// </summary>
        public static bool ValidatePayRollNumberFormat(string stringInput)
        {
            return int.TryParse(stringInput, out int intOutput);
        }

        public static void PrintInvalidPayRollNumberMessage()
        {
            Console.WriteLine("Invalid payroll number, please try again.");
        }

        public static void PrintEmployeeNotFoundMessage()
        {
            Console.WriteLine("Employee not found, please try again.");
        }
    }
}