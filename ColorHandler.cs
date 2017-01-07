using Tao.Sdl;
using System;
using System.Collections.Generic; 
using System.Linq;

public class ColorHandler {

  Random random;
  public const byte colorMaxValue = 255;
  const byte half = colorMaxValue/2;
  
  public ColorHandler(Random random) {
    this.random = random;
  }

  public int approximately(int x, int y, int d) {
    if (((x-y) < d) || ((y-x) < d)) return 0;
    else return 1;
  }
  
public List<T> CloneList<T>(List<T> originalList) where T : ICloneable
{
    return originalList.ConvertAll(x => (T) x.Clone());
}
  
public Dictionary<color, List<color> > generate_colors() {
  Dictionary<color, List<color> > colors = new Dictionary<color, List<color> >();
  List<color> clrs = generate_colors_();
  
  //fehér 0
  List<color> clrs_white = CloneList(clrs);
  clrs_white.RemoveAt(0);
  colors.Add(clrs[0], clrs_white);
  
    //rózsaszín1 1
  List<color> clrs_pink = CloneList(clrs);
  clrs_pink.RemoveAt(4);
  clrs_pink.RemoveAt(3);
  clrs_pink.RemoveAt(2);
  clrs_pink.RemoveAt(1);

  colors.Add(clrs[1], clrs_pink);
  
  //rózsaszín2 2
  colors.Add(clrs[2], clrs_pink);

  //rózsaszín3 3
  colors.Add(clrs[3], clrs_pink);

  //rózsaszín4 4
  colors.Add(clrs[4], clrs_pink);

  //piros1 5
  List<color> clrs_red = CloneList(clrs); //(List<color>)clrs.Clone();
  clrs_red.RemoveAt(15);
  clrs_red.RemoveAt(6);
  clrs_red.RemoveAt(5);
  colors.Add(clrs[5], clrs_red);
    
  //piros2 6
  colors.Add(clrs[6], clrs_red);

  //bordó 7
  List<color> clrs_bordeaux = CloneList(clrs);
  clrs_bordeaux.RemoveAt(23);
  clrs_bordeaux.RemoveAt(15);
  clrs_bordeaux.RemoveAt(7);
  colors.Add(clrs[7], clrs_bordeaux);

  //1 8
  List<color> clrs_orange = CloneList(clrs);
  clrs_orange.RemoveAt(22);
  clrs_orange.RemoveAt(21);
  clrs_orange.RemoveAt(16);
  clrs_orange.RemoveAt(15);
  clrs_orange.RemoveAt(10);
  clrs_orange.RemoveAt(9);
  clrs_orange.RemoveAt(8);
  colors.Add(clrs[8], clrs_orange);

    //2 9
  colors.Add(clrs[9], clrs_orange);

  //narancssárga3 10
  colors.Add(clrs[10], clrs_orange);

  //sárga 11
  List<color> clrs_yellow = CloneList(clrs);
  clrs_yellow.RemoveAt(23);
  clrs_yellow.RemoveAt(22);
  clrs_yellow.RemoveAt(21);
  clrs_yellow.RemoveAt(15);
  clrs_yellow.RemoveAt(11);
  colors.Add(clrs[11], clrs_yellow);

  //sárgászöld 12
  List<color> clrs_virid = CloneList(clrs);
  clrs_virid.RemoveAt(12);
  colors.Add(clrs[12], clrs_virid);

  //zöld1 13
List<color> clrs_green = CloneList(clrs);
  clrs_green.RemoveAt(14);
  clrs_green.RemoveAt(13);
  colors.Add(clrs[13], clrs_green);

  //zöld2 14
  colors.Add(clrs[14], clrs_green);

  //kékeszöld 15
  List<color> clrs_turquoise = CloneList(clrs);
  clrs_turquoise.RemoveAt(15);
  clrs_turquoise.RemoveAt(11);
  clrs_turquoise.RemoveAt(10);
  clrs_turquoise.RemoveAt(9);
  clrs_turquoise.RemoveAt(8);
  clrs_turquoise.RemoveAt(7);
  clrs_turquoise.RemoveAt(6);
  clrs_turquoise.RemoveAt(5);
  colors.Add(clrs[15], clrs_turquoise);

  //világoskék 16
  List<color> clrs_blue = CloneList(clrs);
  clrs_blue.RemoveAt(16);
  clrs_blue.RemoveAt(10);
  clrs_blue.RemoveAt(9);
  clrs_blue.RemoveAt(7);
  colors.Add(clrs[16], clrs_blue);

  //kék1 17
  List<color> clrs_blue2 = CloneList(clrs);
  clrs_blue2.RemoveAt(18);
  clrs_blue2.RemoveAt(17);
  colors.Add(clrs[17], clrs_blue2);

  //kék2 18
  colors.Add(clrs[18], clrs_blue2);

  //sötétkék 19
  List<color> clrs_blue3 = CloneList(clrs);
  clrs_blue3.RemoveAt(20);
  clrs_blue3.RemoveAt(19);
  colors.Add(clrs[19], clrs_blue3);

  //kékeslila 20
  colors.Add(clrs[20], clrs_blue3);

  //lila1 21
  List<color> clrs_lilac = CloneList(clrs);
  clrs_lilac.RemoveAt(22);
  clrs_lilac.RemoveAt(21);
  clrs_lilac.RemoveAt(11);
  clrs_lilac.RemoveAt(10);
  clrs_lilac.RemoveAt(9);
  clrs_lilac.RemoveAt(8);
  colors.Add(clrs[21], clrs_lilac);

  //lila2 22
  colors.Add(clrs[22], clrs_lilac);

  //bíbor 23
  List<color> clrs_purple = CloneList(clrs);
  clrs_purple.RemoveAt(23);
  clrs_purple.RemoveAt(11);
  clrs_purple.RemoveAt(8);
  colors.Add(clrs[23], clrs_purple);

  return colors;
}
 
public List<color> generate_age_colors() {   
  List<color> colors = new List<color>();
  
  color white;
  //fehér
  white.red = colorMaxValue;
  white.green = colorMaxValue;
  white.blue = colorMaxValue;
  white.alpha = colorMaxValue;
  colors.Add(white);
  
  color red2;
  //piros2
  red2.red = colorMaxValue;
  red2.green = 0;
  red2.blue = 0;  
  red2.alpha = colorMaxValue;
  colors.Add(red2);
  
  color blue1;
  //kék1
  blue1.red = 0;
  blue1.green = 0;
  blue1.blue = colorMaxValue;      
  blue1.alpha = colorMaxValue;
  colors.Add(blue1);
  
    color lilac1;
  //lila1
  lilac1.red = colorMaxValue/2;
  lilac1.green = colorMaxValue/4;
  lilac1.blue = colorMaxValue;
  lilac1.alpha = colorMaxValue;
  colors.Add(lilac1);
  
  color orange2;
    //2
  orange2.red = colorMaxValue;
  orange2.green = colorMaxValue/4;
  orange2.blue = 0;
  orange2.alpha = colorMaxValue;
  colors.Add(orange2);
  
  color dark_green;
  //zöld1
  dark_green.red = 0;
  dark_green.green = colorMaxValue/2;
  dark_green.blue = 0;
  dark_green.alpha = colorMaxValue;
  colors.Add(dark_green);
  
  color yellow;
  //sárga
  yellow.red = colorMaxValue;
  yellow.green = colorMaxValue;
  yellow.blue = 0;
  yellow.alpha = colorMaxValue;
  colors.Add(yellow);
  
  color bordeaux;
  //bordó
  bordeaux.red = colorMaxValue/2;
  bordeaux.green = 0;
  bordeaux.blue = 0;
  bordeaux.alpha = colorMaxValue;
  colors.Add(bordeaux);
  
  color bright_blue;
  //világoskék
  bright_blue.red = colorMaxValue/2;
  bright_blue.green = colorMaxValue/2;
  bright_blue.blue = colorMaxValue;
  bright_blue.alpha = colorMaxValue;
  colors.Add(bright_blue);
  
  color pink3;
  //rózsaszín3
  pink3.red = colorMaxValue/2;
  pink3.green = colorMaxValue/4;
  pink3.blue = colorMaxValue/4;  
  pink3.alpha = colorMaxValue;
  colors.Add(pink3);
  
  color viridian;
  //sárgászöld
  viridian.red = colorMaxValue/3;
  viridian.green = colorMaxValue;
  viridian.blue = 0;
  viridian.alpha = colorMaxValue;
  colors.Add(viridian);
  
  color bluish_lilac;
  //kékeslila
  bluish_lilac.red = colorMaxValue/4;
  bluish_lilac.green = 0;
  bluish_lilac.blue = colorMaxValue/2;      
  bluish_lilac.alpha = colorMaxValue;
  colors.Add(bluish_lilac);
  
    return colors;
}
 
public List<color> generate_colors_() {   
  List<color> colors = new List<color>();
  color white;
  //fehér
  white.red = colorMaxValue;
  white.green = colorMaxValue;
  white.blue = colorMaxValue;
  white.alpha = colorMaxValue;
  colors.Add(white);
    
  color pink1;
  //rózsaszín1
  pink1.red = colorMaxValue;
  pink1.green = colorMaxValue/2;
  pink1.blue = colorMaxValue/2;  
  pink1.alpha = colorMaxValue;
  colors.Add(pink1);

  color pink2;
  //rózsaszín2
  pink2.red = colorMaxValue;
  pink2.green = colorMaxValue/3;
  pink2.blue = colorMaxValue/3;  
  pink2.alpha = colorMaxValue;
  colors.Add(pink2);

  color pink3;
  //rózsaszín3
  pink3.red = colorMaxValue/2;
  pink3.green = colorMaxValue/4;
  pink3.blue = colorMaxValue/4;  
  pink3.alpha = colorMaxValue;
  colors.Add(pink3);

  color pink4;
  //rózsaszín4
  pink4.red = colorMaxValue;
  pink4.green = 0;
  pink4.blue = colorMaxValue/4;
  pink4.alpha = colorMaxValue;
  colors.Add(pink4);

  color red1;
  //piros1
  red1.red = colorMaxValue;
  red1.green = 0;
  red1.blue = colorMaxValue/16;  
  red1.alpha = colorMaxValue;
  colors.Add(red1);
    
  color red2;
  //piros2
  red2.red = colorMaxValue;
  red2.green = 0;
  red2.blue = 0;  
  red2.alpha = colorMaxValue;
  colors.Add(red2);

  color bordeaux;
  //bordó
  bordeaux.red = colorMaxValue/2;
  bordeaux.green = 0;
  bordeaux.blue = 0;
  bordeaux.alpha = colorMaxValue;
  colors.Add(bordeaux);

  color orange1;
  //1
  orange1.red = colorMaxValue/3;
  orange1.green = colorMaxValue/16;
  orange1.blue = colorMaxValue;
  orange1.alpha = colorMaxValue;
  colors.Add(orange1);

  color orange2;
    //2
  orange2.red = colorMaxValue;
  orange2.green = colorMaxValue/4;
  orange2.blue = 0;
  orange2.alpha = colorMaxValue;
  colors.Add(orange2);

  color orange3;
  //narancssárga3
  orange3.red = colorMaxValue;
  orange3.green = colorMaxValue/2;
  orange3.blue = 0;
  orange3.alpha = colorMaxValue;
  colors.Add(orange3);

  color yellow;
  //sárga
  yellow.red = colorMaxValue;
  yellow.green = colorMaxValue;
  yellow.blue = 0;
  yellow.alpha = colorMaxValue;
  colors.Add(yellow);

  color viridian;
  //sárgászöld
  viridian.red = colorMaxValue/3;
  viridian.green = colorMaxValue;
  viridian.blue = 0;
  viridian.alpha = colorMaxValue;
  colors.Add(viridian);

  color dark_green;
  //zöld1
  dark_green.red = 0;
  dark_green.green = colorMaxValue/2;
  dark_green.blue = 0;
  dark_green.alpha = colorMaxValue;
  colors.Add(dark_green);

  color bright_green;
  //zöld2
  bright_green.red = 0;
  bright_green.green = colorMaxValue;
  bright_green.blue = 0;
  bright_green.alpha = colorMaxValue;
  colors.Add(bright_green);

  color turquoise;
  //kékeszöld
  turquoise.red = 0;
  turquoise.green = colorMaxValue/2;
  turquoise.blue = colorMaxValue/2;      
  turquoise.alpha = colorMaxValue;
  colors.Add(turquoise);

  color bright_blue;
  //világoskék
  bright_blue.red = colorMaxValue/2;
  bright_blue.green = colorMaxValue/2;
  bright_blue.blue = colorMaxValue;
  bright_blue.alpha = colorMaxValue;
  colors.Add(bright_blue);

  color blue1;
  //kék1
  blue1.red = 0;
  blue1.green = 0;
  blue1.blue = colorMaxValue;      
  blue1.alpha = colorMaxValue;
  colors.Add(blue1);

  color blue2;
  //kék2
  blue2.red = colorMaxValue/4;
  blue2.green = colorMaxValue/2;
  blue2.blue = colorMaxValue;
  blue2.alpha = colorMaxValue;
  colors.Add(blue2);

  color dark_blue;
  //sötétkék
  dark_blue.red = 0;
  dark_blue.green = 0;
  dark_blue.blue = colorMaxValue/2;      
  dark_blue.alpha = colorMaxValue;
  colors.Add(dark_blue);

  color bluish_lilac;
  //kékeslila
  bluish_lilac.red = colorMaxValue/4;
  bluish_lilac.green = 0;
  bluish_lilac.blue = colorMaxValue/2;      
  bluish_lilac.alpha = colorMaxValue;
  colors.Add(bluish_lilac);

  color lilac1;
  //lila1
  lilac1.red = colorMaxValue/2;
  lilac1.green = colorMaxValue/4;
  lilac1.blue = colorMaxValue;
  lilac1.alpha = colorMaxValue;
  colors.Add(lilac1);

  color lilac2;
  //lila2
  lilac2.red = colorMaxValue/4;
  lilac2.green = colorMaxValue/254;
  lilac2.blue = colorMaxValue/2;
  lilac2.alpha = colorMaxValue;
  colors.Add(lilac2);

  color purple;
  //bíbor
  purple.red = colorMaxValue/2;
  purple.green = 0;
  purple.blue = colorMaxValue/4;
  purple.alpha = colorMaxValue;
  colors.Add(purple);

  return colors;
}

public color generate_light(color col){
  if (col.red < half) col.red = col.red + (colorMaxValue - col.red) / 2;;
  if (col.green < half) col.green = col.green + (colorMaxValue - col.green) / 2;;
  if (col.blue < half) col.blue = col.blue + (colorMaxValue - col.blue) / 2;;
  return col;     
} 
 
//Ezt esetleg még javítani kell, hogy szép legyen
public color generate_dark(color col){
  int dist = 20;
  int wt = random.Next(0, 2);
  if ((col.red > half) && (col.green > half) && (col.blue > half)){
      //I still hate grey
    if (approximately(col.red, col.green, dist) == 0){
      if (wt == 1)
        col.red = col.red - half;
      else
        col.green = col.green - half;
    }
    else if (approximately(col.blue, col.green, dist) == 0){
      if (wt == 1)
        col.green = col.green - half;
      else
        col.blue = col.blue - half;
    }
    else if (approximately(col.blue, col.red, dist) == 0){
      if (wt == 1)
        col.red = col.red - half;
      else
        col.blue = col.blue - half;
    }
    else if ((col.red > col.green) && (col.red > col.blue)){
      if (wt == 1)
        col.green = col.green - half;
      else
        col.blue = col.blue - half;    
    }
    else if ((col.green > col.red) && (col.green > col.blue)){
      if (wt == 1)
        col.red = col.red - half;
      else
        col.blue = col.blue - half;
      }
    else if ((col.blue > col.green) && (col.blue > col.red)){
      col.blue = col.blue - half;
    }

    else {
      int wt2 = random.Next(0, 6);
    if (wt2 < 0){
       wt2 = wt2 + 6;
    }
    if (wt2 == 0){
       col.red = col.red - half;
     }
     else if (wt2 == 1){
       col.green = col.green - half;
     }
     else if (wt2 == 2){
       col.blue = col.blue - half;
     }
     else if (wt2 == 3){
       col.red = col.red - half;
       col.green = col.green - half;
     }
     else if (wt2 == 4){
       col.green = col.green - half;
       col.blue = col.blue - half;
     }
     else if (wt2 == 5){
       col.blue = col.blue - half;
       col.red = col.red - half;
     }
    }
  }
  return col;
}
} 