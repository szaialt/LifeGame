using Tao.Sdl;
//using Tao.Sdl.SdlGfx;
using System;
using System.Collections.Generic; 
using System.Linq;
using System.Drawing;
using System.Windows.Forms;

public class MainDrawing {
  Random random = new Random();
  
  //Setted information
  private MatrixType matrix;
  private NeighbourhoodType neighbourhood;
  private MeshType mesh;
  private List<int> borns;
  private List<int> survives;
  private bool ageT;
  
  public MainDrawing(MatrixType matrix, //= MatrixType.RANDOM, 
                NeighbourhoodType neighbourhood, //= NeighbourhoodType.CONWAY, 
                MeshType mesh, //= MeshType.SQUARE,
                List<int> borns, //= {2, 3},
                List<int> survives, //= {2},
                bool ageT //= false
                ){
    this.matrix = matrix;
    this.neighbourhood = neighbourhood;
    this.mesh = mesh;
    this.borns = borns;
    this.survives = survives;
    this.ageT = ageT;
    
                
  }
  
    //Maximum function
  int max(int a, int b){
    if (a > b) return a;
    else return b;
  } 
  
  [STAThread]
  public void Drawing() {
    //Default colors
    color black;
    black.red = 0;
    black.green = 0;
    black.blue = 0;  
    black.alpha = ColorHandler.colorMaxValue;

    color white;
    white.red = ColorHandler.colorMaxValue;
    white.green = ColorHandler.colorMaxValue;
    white.blue = ColorHandler.colorMaxValue;
    white.alpha = ColorHandler.colorMaxValue;
 

   //Initialization of graphics and opening painting window
   Sdl.SDL_Event ev = new Sdl.SDL_Event();
 
    Sdl.SDL_Init(Sdl.SDL_INIT_VIDEO);
    System.IntPtr screen = Sdl.SDL_SetVideoMode(0, 0, 0, Sdl.SDL_ANYFORMAT);
     if (screen == IntPtr.Zero) {
         System.Console.WriteLine("Nem sikerult megnyitni az ablakot!\n");
         return;
     }
    Sdl.SDL_WM_SetCaption("SDL peldaprogram", "SDL peldaprogram");

    //Sets NeightbourHandler
    NeightbourHandler nh = new QuadraticConwayNeightbourHandler();
    if (mesh == MeshType.SQUARE){
      if (neighbourhood == NeighbourhoodType.ULAM) 
        nh = new QuadraticUlamNeightbourHandler();
      else if (neighbourhood == NeighbourhoodType.KNIGHT) 
        nh = new QuadraticKnightNeightbourHandler();
      }
    else if (mesh == MeshType.TRIANGLE){
      if (neighbourhood == NeighbourhoodType.ULAM) 
        nh = new TriangleUlamNeightbourHandler();
      else if (neighbourhood == NeighbourhoodType.CONWAY)
        nh = new TriangleConwayNeightbourHandler();
      else if (neighbourhood == NeighbourhoodType.KNIGHT) 
        nh = new TriangleKnightNeightbourHandler();
    }
    else if (mesh == MeshType.HEXAGON){
      if (neighbourhood == NeighbourhoodType.ULAM) 
        nh = new HexagonUlamNeightbourHandler();
      else if (neighbourhood == NeighbourhoodType.CONWAY)
        nh = new HexagonConwayNeightbourHandler();
      else if (neighbourhood == NeighbourhoodType.KNIGHT) 
        nh = new HexagonKnightNeightbourHandler();
    }

        //Sets MatrixHandler and ColorHandler
    MatrixHandler game = new QuadraticMatrixHandler(random, nh, ageT);
    ColorHandler ch = new ColorHandler(random);

        //Gets sizes of screen
    int width = Screen.PrimaryScreen.Bounds.Width;
    int height = Screen.PrimaryScreen.Bounds.Height;

        //Calculates main datas
    int cellSize = 10;
    const int half = ColorHandler.colorMaxValue/2;
    const int state_number = 2;
    // Itt rajzolj
    int n = width/cellSize;
    int m = height/cellSize;
    int del = 0;
    int delt = max(n, m) * 2;
   
       //Generates random matrix as default 
    double probability = 0.3;
    ModuloIndexableList<ModuloIndexableList<int> > cell_matrix  = 
           game.generate_random_matrix(n,m,probability);
    if (matrix == MatrixType.ONE_POINT){
      cell_matrix = game.generate_matrix(n, m);
    }

        //Adds state rules in order of states
    List<List<int> > rule = new List<List<int> >();
    rule.Add(borns);
    rule.Add(survives);

        //Generating and setting colors
    List<color> colors = ch.generate_colors_();
    int index1 = random.Next(0, colors.Count);
    color c1 = colors[index1];
    Dictionary<color, List<color> > color_matrix = ch.generate_colors();
    List<color> cls = color_matrix[c1];
    int index2 = random.Next(0, cls.Count);
    color col = cls[index2];
    color col1 = white;
    color col2 = black;

    int wt = random.Next(0, 6);
    if (wt == 0) {
      col1 = c1;
      col2 = ch.generate_dark(col);
    }
    else if (wt == 1) {
      col1 = ch.generate_light(col);
      col2 = c1;
    }
    else if (wt == 2) {
      col1 = col;
      col2 = c1;
    }
    else if (wt == 3) {
      col1 = c1;
      col2 = col;
    }
    else if (wt == 4) {
      col1 = c1;
      col2 = ch.generate_light(col);
    }
    if (wt == 5) {
      col1 = ch.generate_dark(col);
      col2 = c1;
    }
    Sdl.SDL_WaitEvent(out ev);
        //Drawing loop
    while (ev.type!=Sdl.SDL_QUIT && ev.type != Sdl.SDL_KEYDOWN){
       if (ev.type == Sdl.SDL_KEYDOWN)
         {
          
          System.Console.WriteLine("Billentyű észlelve.");
          Sdl.SDL_Quit();
        }
      else if (ev.type == Sdl.SDL_MOUSEBUTTONDOWN)
         {
           
          System.Console.WriteLine("Egér észlelve.");
          Sdl.SDL_Quit();
        }
        
        for (int i = 0; i < n; i++){
          for (int j = 0; j < m; j++){
            if (mesh == MeshType.SQUARE){
              short x1 = (short)(i*cellSize + 1);
              short y1 = (short)(j*cellSize + 1);  
              short x2 = (short)((i+1)*cellSize);
              short y2 = (short)((j+1)*cellSize); 
 
            // drawing quadratic mesh with age                
            if (ageT){
              List<color> cols = ch.generate_age_colors();
              if (cell_matrix[i][j] == 0) {
                Tao.Sdl.SdlGfx.boxRGBA(screen, x1, y1, x2, y2,
                (byte)(black.red), (byte)(black.green), (byte)(black.blue), (byte)(black.alpha));
              }
              else {
                int ix = cell_matrix[i][j] % cols.Count;
                if (ix < 0) ix = ix + cols.Count;
                Tao.Sdl.SdlGfx.boxRGBA(screen, x1, y1, x2, y2,
                (byte)((cols[ix]).red), (byte)((cols[ix]).green), (byte)((cols[ix]).blue), (byte)(cols[ix].alpha));
              }
            }
              else {
                // drawing quadratic mesh without age  
              if (cell_matrix[i][j] == 1)
                Tao.Sdl.SdlGfx.boxRGBA(screen, x1, y1, x2, y2,
                (byte)(col2.red), (byte)(col2.green), (byte)(col2.blue), (byte)(col2.alpha));
              else if (cell_matrix[i][j] == 0)
                Tao.Sdl.SdlGfx.boxRGBA(screen, x1, y1, x2, y2,
                (byte)(col1.red), (byte)(col1.green), (byte)(col1.blue), (byte)(col1.alpha));
              }
            }
            else {
            // drawing another mesh 
            List<Tuple<double, double>> points = new List<Tuple<double, double>>();
              if (mesh == MeshType.TRIANGLE) {
                points = calculate_triangle_coordinates(i, j);
              }
              else if (mesh == MeshType.HEXAGON) {
                points = calculate_hexagon_coordinates(i, j);
              }
              short[] vx = new short[points.Count];
              short[] vy = new short[points.Count];
              for (int k = 0; k < points.Count; k++){
                double xx = points[k].Item1;
                double yy = points[k].Item2;
                xx = xx * cellSize;
                if (mesh == MeshType.TRIANGLE){
                  //to have better rates of sides and hights
                  xx = xx * Math.Sqrt(3);
                  //to set the middle into the middle
                  xx = xx + 10 * (1 - Math.Sqrt(3)) * cellSize;
                  yy = yy + 5 * (1 - Math.Sqrt(3)) * cellSize;
                }
                else if (mesh == MeshType.HEXAGON){
                  //to set the middle into the middle
                  xx = xx + 30 * (1 - Math.Sqrt(3)) * cellSize;
                  yy = yy + 3 * (1 - Math.Sqrt(3)) * cellSize;
                }
                yy = yy * cellSize;
                int xt = (int)xx;
                int yt = (int)yy;
                short xs = (short)xt;
                short ys = (short)yt;
                vx[k] = xs;
                vy[k] = ys;
                if ((mesh == MeshType.TRIANGLE) || (mesh == MeshType.HEXAGON)){
                  vx[k] = ys;
                  vy[k] = xs;
                }
              }
              if (ageT){
                // drawing mesh with age  
                List<color> cols = ch.generate_age_colors();
                if (cell_matrix[i][j] == 0) {
                Tao.Sdl.SdlGfx.filledPolygonRGBA (screen, vx, vy, points.Count, 
                   (byte)(black.red), (byte)(black.green), (byte)(black.blue), (byte)(black.alpha));
                }
                else {
                int ix = cell_matrix[i][j] % cols.Count;
                if (ix < 0) ix = ix + cols.Count;
                Tao.Sdl.SdlGfx.filledPolygonRGBA (screen, vx, vy, points.Count, 
                  (byte)((cols[ix]).red), (byte)((cols[ix]).green), (byte)((cols[ix]).blue), (byte)(cols[ix].alpha));
                }
              }
              else {
                // drawing mesh without age  
              if (cell_matrix[i][j] == 1){
              Tao.Sdl.SdlGfx.filledPolygonRGBA (screen, vx, vy, points.Count, 
                (byte)(col2.red), (byte)(col2.green), (byte)(col2.blue), (byte)(col2.alpha));
              }
              else if (cell_matrix[i][j] == 0){
              Tao.Sdl.SdlGfx.filledPolygonRGBA (screen, vx, vy, points.Count, 
                (byte)(col1.red), (byte)(col1.green), (byte)(col1.blue), (byte)(col1.alpha));
              }
              
              }
            }
          }
        }
       
      if (del == delt){
        if (matrix == MatrixType.RANDOM)
          cell_matrix = game.generate_random_matrix(n,m,probability);
        else if (matrix == MatrixType.ONE_POINT){
          cell_matrix = game.generate_matrix(n, m);
        del = 0;
        }
        wt = random.Next(0, 6);
        if (wt == 0) {
          col1 = c1;
          col2 = ch.generate_dark(col);
        }
        else if (wt == 1) {
          col1 = ch.generate_light(col);
          col2 = c1;
        }
        else if (wt == 2) {
          col1 = col;
          col2 = c1;
        }
        else if (wt == 3) {
          col1 = c1;
          col2 = col;
        }
        else if (wt == 4) {
          col1 = c1;
          col2 = ch.generate_light(col);
        }
        if (wt == 5) {
          col1 = ch.generate_dark(col);
          col2 = c1;
        }
      }
      else {
        cell_matrix = game.new_matrix(cell_matrix, rule);
       }

     /* Flips drawings */
     Sdl.SDL_Flip(screen);
     Sdl.SDL_WaitEvent(out ev);
     System.Threading.Thread.Sleep(1000);
        
    del = del + 1;
    }
 
    /* closing window */
    Sdl.SDL_Quit();
    return;
  }
 
  //Calculates drawing coordinates of triangles given by mesh coordinates
  private List<Tuple<double, double>> calculate_triangle_coordinates(int i, int j){
    double x0 = -1;
    double x1 = -1;
    double x2 = -1;
    double y0 = -1;
    double y1 = -1;
    double y2 = -1;
    //Triangle is \| upside down, 
  if (i % 2 == 0) {
      x0 = i/2;
      y0 = 2 * j - 1;
      x1 = i/2;
      y1 = 2 * j + 1;
      x2 = i/2 + 1;
      y2 = 2 * j;
    }
    //Triangle is |\ up
    else if (i % 2 == 1) {
      x0 = i/2;
      y0 = 2 * j + 1;
      x1 = i/2 + 1;
      y1 = 2 * j;
      x2 = i/2 + 1;
      y2 = 2 * j + 2;
    }
    Tuple<double, double> p0 = new Tuple<double, double>(x0, y0);
    Tuple<double, double> p1 = new Tuple<double, double>(x1, y1);
    Tuple<double, double> p2 = new Tuple<double, double>(x2, y2);
    List<Tuple<double, double>> points = new List<Tuple<double, double>>();
    points.Add(p0);
    points.Add(p1);
    points.Add(p2);
    return points;
  }
  
  //Calculates coordinates of hexagons given by coordinates
  private List<Tuple<double, double>> calculate_hexagon_coordinates(int i, int j){
        //Unit is radius of excircle
    double incircle_radius = Math.Sqrt(3)/2;
    double x0, y0, x1, y1, x2, y2, x3, y3, x4, y4, x5, y5;
        //Calculates concave hexagon that has two-fold rotational symmetry
    x0 = i + incircle_radius/2;
    y0 = 2 * incircle_radius * j;
    x1 = i + incircle_radius;
    y1 = 2 * incircle_radius * j + incircle_radius/2;
    x2 = i + incircle_radius;
    y2 = 2 * incircle_radius * j - incircle_radius/2;
    x3 = i - incircle_radius/2;
    y3 = 2 * incircle_radius * j;
    x4 = i - incircle_radius;
    y4 = 2 * incircle_radius * j - incircle_radius/2;
    x5 = i - incircle_radius;
    y5 = 2 * incircle_radius * j + incircle_radius/2;
    if (i % 2 == 1){
      y0 = y0 + incircle_radius;
      y1 = y1 + incircle_radius;
      y2 = y2 + incircle_radius;
      y3 = y3 + incircle_radius;
      y4 = y4 + incircle_radius;
      y5 = y5 + incircle_radius;
    }
    Tuple<double, double> p0 = new Tuple<double, double>(x0, y0);
    Tuple<double, double> p1 = new Tuple<double, double>(x1, y1);
    Tuple<double, double> p2 = new Tuple<double, double>(x2, y2);
    Tuple<double, double> p3 = new Tuple<double, double>(x3, y3);
    Tuple<double, double> p4 = new Tuple<double, double>(x4, y4);
    Tuple<double, double> p5 = new Tuple<double, double>(x5, y5);
    List<Tuple<double, double>> points = new List<Tuple<double, double>>();
    points.Add(p0);
    points.Add(p1);
    points.Add(p2);
    points.Add(p3);
    points.Add(p4);
    points.Add(p5);
    return points;
  }
}