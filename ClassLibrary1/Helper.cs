
namespace ClassLibrary1
{
    /*
     * This class was created for experimenting with external libraries.
     * Has method for validating if payroll number is correctly formatted.
     * Also has methods for printing certain error messages to the commandline.
     */
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