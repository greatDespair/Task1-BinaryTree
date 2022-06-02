namespace StringTask
{
    class StringHandler
    {
        public bool StrEnd(string baseString, string endOfString)
        {
            endOfString = endOfString.Trim();
            baseString = baseString.Trim();
            baseString = baseString.Substring(baseString.Length - endOfString.Length);
            return baseString == endOfString;
        }
    }
}
