namespace Task2
{
    public interface INumberParser
    {
        /// <summary>
        /// Parse string value to integer value without using any library method.
        /// </summary>
        /// <param name="stringValue">String to be converted to integer.</param>
        /// <returns>Returns integer value of the provided param.</returns>
        int Parse(string stringValue);
    }
}