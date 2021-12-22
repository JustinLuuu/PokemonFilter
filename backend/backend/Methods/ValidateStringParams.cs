namespace backend.Methods
{
    public static class ValidateStringParams
    {
        public static bool Validate(string characterString)
        {            
            if (characterString == string.Empty ||
                characterString.Trim() == string.Empty ||
                characterString == null || characterString.All(char.IsNumber))
            {
                return false;
            }
            return true;
        }
    }
}
