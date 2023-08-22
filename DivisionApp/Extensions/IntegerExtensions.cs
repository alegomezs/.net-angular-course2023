namespace DivisionApp.Extensions
{
    public static class IntegerExtensions
    {
        public static decimal DoDivision(this decimal dividend, decimal divisor = 0)
        {            
            return (decimal) dividend / divisor;           
        }
    }
}
