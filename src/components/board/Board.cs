using Godot;
using System;

public class Point {
    public Vector2 point;

    public Point(Vector2 point) {
        this.point = point;
    }
}

public class Interest {
    // Описание точки интереса, которое покажется в диалоговом окне   
    public String description;

    // Клетка, куда должен будет перейти игрок после показа диалога 
    public int cell = 0;

    public Interest(String description, int cell) {
        this.description = description;
        this.cell = cell;
    }
}

public partial class Board : Sprite2D {
    public Point[] Points = new Point[88];
    public Interest[] Interests = new Interest[88];
    private Dice dice;
    private Player player;

    public override void _Ready() {
        var vp = GetViewportRect();
        var vwidth = vp.Size.X;
        var vheight = vp.Size.Y;


        // row 1
        Points[0] = new Point(new Vector2((vwidth / 2 - 950) + 135, vheight / 2 + 460));
        Points[1] = new Point(new Vector2((vwidth / 2 - 950) + 270, vheight / 2 + 460));
        Points[2] = new Point(new Vector2((vwidth / 2 - 950) + 405, vheight / 2 + 460));
        Points[3] = new Point(new Vector2((vwidth / 2 - 950) + 540, vheight / 2 + 460));
        Points[4] = new Point(new Vector2((vwidth / 2 - 950) + 675, vheight / 2 + 460));
        Points[5] = new Point(new Vector2((vwidth / 2 - 950) + 810, vheight / 2 + 460));
        Points[6] = new Point(new Vector2((vwidth / 2 - 950) + 945, vheight / 2 + 460));
        Points[7] = new Point(new Vector2((vwidth / 2 - 950) + 1080, vheight / 2 + 460));
        Points[8] = new Point(new Vector2((vwidth / 2 - 950) + 1215, vheight / 2 + 460));
        Points[9] = new Point(new Vector2((vwidth / 2 - 950) + 1350, vheight / 2 + 460));
        Points[10] = new Point(new Vector2((vwidth / 2 - 950) + 1485, vheight / 2 + 460)); // 11

        // row 2
        Points[33] = new Point(new Vector2((vwidth / 2 - 950) + 135, vheight / 2 + 325));
        Points[34] = new Point(new Vector2((vwidth / 2 - 950) + 270, vheight / 2 + 325));
        Points[35] = new Point(new Vector2((vwidth / 2 - 950) + 405, vheight / 2 + 325));
        Points[36] = new Point(new Vector2((vwidth / 2 - 950) + 540, vheight / 2 + 325));
        Points[37] = new Point(new Vector2((vwidth / 2 - 950) + 675, vheight / 2 + 325));
        Points[38] = new Point(new Vector2((vwidth / 2 - 950) + 810, vheight / 2 + 325));
        Points[39] = new Point(new Vector2((vwidth / 2 - 950) + 945, vheight / 2 + 325));
        Points[40] = new Point(new Vector2((vwidth / 2 - 950) + 1080, vheight / 2 + 325));
        Points[41] = new Point(new Vector2((vwidth / 2 - 950) + 1215, vheight / 2 + 325));
        Points[42] = new Point(new Vector2((vwidth / 2 - 950) + 1350, vheight / 2 + 325));
        Points[11] = new Point(new Vector2((vwidth / 2 - 950) + 1485, vheight / 2 + 325)); // 11
        

        // row 3
        Points[32] = new Point(new Vector2((vwidth / 2 - 950) + 135, vheight / 2 + 190));
        Points[59] = new Point(new Vector2((vwidth / 2 - 950) + 270, vheight / 2 + 190));
        Points[60] = new Point(new Vector2((vwidth / 2 - 950) + 405, vheight / 2 + 190));
        Points[61] = new Point(new Vector2((vwidth / 2 - 950) + 540, vheight / 2 + 190));
        Points[62] = new Point(new Vector2((vwidth / 2 - 950) + 675, vheight / 2 + 190));
        Points[63] = new Point(new Vector2((vwidth / 2 - 950) + 810, vheight / 2 + 190));
        Points[64] = new Point(new Vector2((vwidth / 2 - 950) + 945, vheight / 2 + 190));
        Points[65] = new Point(new Vector2((vwidth / 2 - 950) + 1080, vheight / 2 + 190));
        Points[66] = new Point(new Vector2((vwidth / 2 - 950) + 1215, vheight / 2 + 190));
        Points[43] = new Point(new Vector2((vwidth / 2 - 950) + 1350, vheight / 2 + 190));
        Points[12] = new Point(new Vector2((vwidth / 2 - 950) + 1485, vheight / 2 + 190)); // 11

         // row 4
        Points[31] = new Point(new Vector2((vwidth / 2 - 950) + 135, vheight / 2 + 55));
        Points[58] = new Point(new Vector2((vwidth / 2 - 950) + 270, vheight / 2 + 55));
        Points[77] = new Point(new Vector2((vwidth / 2 - 950) + 405, vheight / 2 + 55));
        Points[78] = new Point(new Vector2((vwidth / 2 - 950) + 540, vheight / 2 + 55));
        Points[79] = new Point(new Vector2((vwidth / 2 - 950) + 675, vheight / 2 + 55));
        Points[80] = new Point(new Vector2((vwidth / 2 - 950) + 810, vheight / 2 + 55));
        Points[81] = new Point(new Vector2((vwidth / 2 - 950) + 945, vheight / 2 + 55));
        Points[82] = new Point(new Vector2((vwidth / 2 - 950) + 1080, vheight / 2 + 55));
        Points[67] = new Point(new Vector2((vwidth / 2 - 950) + 1215, vheight / 2 + 55));
        Points[44] = new Point(new Vector2((vwidth / 2 - 950) + 1350, vheight / 2 + 55));
        Points[13] = new Point(new Vector2((vwidth / 2 - 950) + 1485, vheight / 2 + 55)); // 11
        
         // row 5
        Points[30] = new Point(new Vector2((vwidth / 2 - 950) + 135, vheight / 2 - 80));
        Points[57] = new Point(new Vector2((vwidth / 2 - 950) + 270, vheight / 2 - 80));
        Points[76] = new Point(new Vector2((vwidth / 2 - 950) + 405, vheight / 2 - 80));
        // победная точка
        Points[87] = new Point(new Vector2((vwidth / 2 - 950) + 540, vheight / 2 - 80));
        Points[86] = new Point(new Vector2((vwidth / 2 - 950) + 675, vheight / 2 - 80));
        Points[85] = new Point(new Vector2((vwidth / 2 - 950) + 810, vheight / 2 - 80));
        Points[84] = new Point(new Vector2((vwidth / 2 - 950) + 945, vheight / 2 - 80));
        Points[83] = new Point(new Vector2((vwidth / 2 - 950) + 1080, vheight / 2 - 80));
        Points[68] = new Point(new Vector2((vwidth / 2 - 950) + 1215, vheight / 2 - 80));
        Points[45] = new Point(new Vector2((vwidth / 2 - 950) + 1350, vheight / 2 - 80));
        Points[14] = new Point(new Vector2((vwidth / 2 - 950) + 1485, vheight / 2 - 80)); // 11
        
         // row 6
        Points[29] = new Point(new Vector2((vwidth / 2 - 950) + 135, vheight / 2 - 215));
        Points[56] = new Point(new Vector2((vwidth / 2 - 950) + 270, vheight / 2 - 215));
        Points[75] = new Point(new Vector2((vwidth / 2 - 950) + 405, vheight / 2 - 215));
        Points[74] = new Point(new Vector2((vwidth / 2 - 950) + 540, vheight / 2 - 215));
        Points[73] = new Point(new Vector2((vwidth / 2 - 950) + 675, vheight / 2 - 215));
        Points[72] = new Point(new Vector2((vwidth / 2 - 950) + 810, vheight / 2 - 215));
        Points[71] = new Point(new Vector2((vwidth / 2 - 950) + 945, vheight / 2 - 215));
        Points[70] = new Point(new Vector2((vwidth / 2 - 950) + 1080, vheight / 2 - 215));
        Points[69] = new Point(new Vector2((vwidth / 2 - 950) + 1215, vheight / 2 - 215));
        Points[46] = new Point(new Vector2((vwidth / 2 - 950) + 1350, vheight / 2 - 215));
        Points[15] = new Point(new Vector2((vwidth / 2 - 950) + 1485, vheight / 2 - 215));
        
         // row 7
        Points[28] = new Point(new Vector2((vwidth / 2 - 950) + 135, vheight / 2 - 350));
        Points[55] = new Point(new Vector2((vwidth / 2 - 950) + 270, vheight / 2 - 350));
        Points[54] = new Point(new Vector2((vwidth / 2 - 950) + 405, vheight / 2 - 350));
        Points[53] = new Point(new Vector2((vwidth / 2 - 950) + 540, vheight / 2 - 350));
        Points[52] = new Point(new Vector2((vwidth / 2 - 950) + 675, vheight / 2 - 350));
        Points[51] = new Point(new Vector2((vwidth / 2 - 950) + 810, vheight / 2 - 350));
        Points[50] = new Point(new Vector2((vwidth / 2 - 950) + 945, vheight / 2 - 350));
        Points[49] = new Point(new Vector2((vwidth / 2 - 950) + 1080, vheight / 2 - 350));
        Points[48] = new Point(new Vector2((vwidth / 2 - 950) + 1215, vheight / 2 - 350));
        Points[47] = new Point(new Vector2((vwidth / 2 - 950) + 1350, vheight / 2 - 350));
        Points[16] = new Point(new Vector2((vwidth / 2 - 950) + 1485, vheight / 2 - 350)); // 11
        
         // row 8
        Points[27] = new Point(new Vector2((vwidth / 2 - 950) + 135, vheight / 2 - 485));
        Points[26] = new Point(new Vector2((vwidth / 2 - 950) + 270, vheight / 2 - 485));
        Points[25] = new Point(new Vector2((vwidth / 2 - 950) + 405, vheight / 2 - 485));
        Points[24] = new Point(new Vector2((vwidth / 2 - 950) + 540, vheight / 2 - 485));
        Points[23] = new Point(new Vector2((vwidth / 2 - 950) + 675, vheight / 2 - 485));
        Points[22] = new Point(new Vector2((vwidth / 2 - 950) + 810, vheight / 2 - 485));
        Points[21] = new Point(new Vector2((vwidth / 2 - 950) + 945, vheight / 2 - 485));
        Points[20] = new Point(new Vector2((vwidth / 2 - 950) + 1080, vheight / 2 - 485));
        Points[19] = new Point(new Vector2((vwidth / 2 - 950) + 1215, vheight / 2 - 485));
        Points[18] = new Point(new Vector2((vwidth / 2 - 950) + 1350, vheight / 2 - 485));
        Points[17] = new Point(new Vector2((vwidth / 2 - 950) + 1485, vheight / 2 - 485)); // 11
        
        // точки интереса
        Interests[2] = new Interest(description: "Точка интереса", cell: 2);
        Interests[4] = new Interest(description: "Точка интереса", cell: 4);
        Interests[6] = new Interest(description: "Точка интереса", cell: 6);
        Interests[8] = new Interest(description: "Точка интереса", cell: 8);
        
        GlobalPosition = new Vector2((vwidth / 2 - 150), vheight / 2);
    }
}
