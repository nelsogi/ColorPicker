using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ColorPicker
{
    public class ColorPicked
    {
        public string Hex { get; set; }
        public string Rgb { get; set; }

        public ColorPicked(string hex, string rgb)
        {
            Hex = hex;
            Rgb = rgb;
        }
        public string GetHex()
        {
            return Hex;
        }
        public string GetRgb()
        {
            return Rgb;
        }

        public override string ToString()
        {
            return $"Hex: {Hex}, RGB: {Rgb}";
        }
    }
}
