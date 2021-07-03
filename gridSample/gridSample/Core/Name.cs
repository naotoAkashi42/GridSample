namespace gridSample.Core
{
    internal class Name
    {
        public string Value { get; }
        public static bool Validate(string text)
        {
            // 名前データには/は使用できない仕様
            if (text.Contains("/")) return false;
            return true;
        }
    }
}
