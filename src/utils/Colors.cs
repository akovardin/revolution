using Godot;
using System;

class Colors {
    public static Color Convert(string color) {
        switch (color) {
            case "red":
                return new Color("#f14343");
            case "green":
                return new Color("#65cb87");
            case "blue":
                return new Color("#878df9");
            case "orange":
                return new Color("#f79c25");
        }

        return new Color("#fff");
    }
}