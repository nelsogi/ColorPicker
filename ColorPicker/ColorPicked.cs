namespace ColorPicker
{
    /// <summary>
    /// Represent a picked color with its Hex and RGB values
    /// </summary>
    public class ColorPicked
    {
        /// <summary>
        /// Hexadecimal representation of the color
        /// </summary>
        public string Hex { get; set; }

        /// <summary>
        /// Red-Green-Blue representation of the color
        /// </summary>
        public string Rgb { get; set; }

        /// <summary>
        /// Constructor to initialize a picked color
        /// </summary>
        /// <param name="hex"></param>
        /// <param name="rgb"></param>
        public ColorPicked(string hex, string rgb)
        {
            Hex = hex;
            Rgb = rgb;
        }

        /// <summary>
        /// Return the Hex value of the color
        /// </summary>
        /// <returns></returns>
        public string GetHex()
        {
            return Hex;
        }

        /// <summary>
        /// Return the RGB value of the color
        /// </summary>
        /// <returns></returns>
        public string GetRgb()
        {
            return Rgb;
        }

        /// <summary>
        /// Return a string representation of the picked color
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return $"Hex: {Hex}, RGB: {Rgb}";
        }
    }
}
