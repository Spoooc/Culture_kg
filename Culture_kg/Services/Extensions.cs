namespace Culture_kg.Services
{
    public static class Extensions
    {
        public static string CutController(this string str)
        {
            return str.Replace("Controller", "");
        }

    }
}
