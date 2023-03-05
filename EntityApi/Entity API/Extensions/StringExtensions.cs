namespace System
{
    public static class StringExtensions
    {
        public static T ToEnum<T>(this string enumString) where T : struct
        {
            T convertedEnum; 

            if (Enum.TryParse(enumString, out convertedEnum))
                return convertedEnum;

            throw new Exception($"'{enumString}' is not a valid value for '{typeof(T).Name}'");
        }
    }
}
