using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Drawing;

namespace EISClient.Charts {
    
    public class ColorPalette {

        private static Color[] _palette = new Color[] {
            Color.FromArgb(21, 183, 164),
            Color.FromArgb(239, 219, 0),
            Color.FromArgb(255, 30, 75),
            Color.FromArgb(191, 14, 249),
            Color.FromArgb(26, 0, 255)
        };

        public static Color[] GetPalette() {
            return _palette;
        }

        public static Color GetColor(int index) {
            index = index % 5;
            return _palette[index];
        }

    }

}