namespace System
{
    public static class ObjectExtensions
    {
        public static void LogProperties<T>(this T obj)
        {
            foreach (var prop in typeof(T).GetProperties())
            {
                var propValue = prop.GetValue(obj);
                Console.WriteLine($"{prop.Name}: {propValue}");
            }
        }
    }
}
