using System;
using System.Drawing;
using System.Windows.Forms;

//General settings form, expect of live or death rules
class Settings : Form {
  
    //Size in direction x
    private int sizeX;
    //Size in direction y
    private int sizeY;
    
    //Cancelling button
    private CheckBox cancel;
    //OK button
    private CheckBox ok;
    
    //Panel for setting starting matrix
    private Panel matrixPanel;
    private RadioButton pointRb;
    private RadioButton randomRb;
    //Panel for setting starting neighbourhood
    private Panel neighbourhoodPanel;
    private RadioButton ulamRb;
    private RadioButton conwayRb;
    private RadioButton knightRb;
    //Panel for setting starting mesh   
    private Panel meshPanel;
    private RadioButton squareRb;
    private RadioButton triangleRb;
    private RadioButton hexagonRb;

    public Settings() {
        Text = "Beállítások";
        sizeX = 660;
        sizeY = 340;
        Size = new Size(sizeX, sizeY);
        
        //Cancelling button
        cancel = new CheckBox();
        cancel.Text = "Mégsem";
        cancel.Parent = this;
        cancel.Location = new Point(100, 215);
        cancel.BackColor = Color.Coral;
        cancel.Show();
        cancel.Visible = true;
        Controls.Add(cancel);
        
        //Okey button
        ok = new CheckBox();
        ok.Text = "OK";
        ok.Parent = this;
        ok.Location = new Point(400, 215);
        ok.BackColor = Color.Coral;
        ok.Show();
        ok.Visible = true;
        Controls.Add(ok);
        
        //Labels of panels
        Label matrixLabel = new Label();
        matrixLabel.Parent = this;
        matrixLabel.Text = "Kezdőmátrix";
        matrixLabel.Location = new Point(30, 30);
        matrixLabel.BackColor = Color.Coral;
        
        Label neighbourhoodLabel = new Label();
        neighbourhoodLabel.Parent = this;
        neighbourhoodLabel.Text = "Szomszédság";
        neighbourhoodLabel.Location = new Point(240, 30);
        neighbourhoodLabel.BackColor = Color.Coral;
        
        Label meshLabel = new Label();
        meshLabel.Parent = this;
        meshLabel.Text = "Rács";
        meshLabel.Location = new Point(450, 30);
        meshLabel.BackColor = Color.Coral;
        
        //Starting matrix is empty, expect of the middle point
        pointRb = new RadioButton();
        pointRb.Parent = this;
        pointRb.Location = new Point(30, 30);
        pointRb.Text = "Egy pont";
        pointRb.Checked = false;

        //Strationg matrix is filled by random
        randomRb = new RadioButton();
        randomRb.Parent = this;
        randomRb.Location = new Point(30, 60);
        randomRb.Text = "Véletlen";
        randomRb.Checked = false;
        
        matrixPanel = new Panel();
        matrixPanel.Parent = this;
        matrixPanel.Location = new Point(30, 30);
        matrixPanel.Text = "";
        matrixPanel.BackColor = Color.Coral;
        matrixPanel.Controls.Add(pointRb);
        matrixPanel.Controls.Add(randomRb);
        matrixPanel.AutoSize = true;
        
        //Neighbours are cells joining by side
        ulamRb = new RadioButton();
        ulamRb.Parent = this;
        ulamRb.Location = new Point(150, 30);
        ulamRb.Text = "Ulam";
        ulamRb.Checked = false;
        
        //Neighbours are cells joining by side or by diagonally
        conwayRb = new RadioButton();
        conwayRb.Parent = this;
        conwayRb.Location = new Point(150, 60);
        conwayRb.Text = "Conway";
        conwayRb.Checked = false;
        
        //Neighbours are cells at knight move
        knightRb = new RadioButton();
        knightRb.Parent = this;
        knightRb.Location = new Point(150, 90);
        knightRb.Text = "Lóugrás";
        knightRb.Checked = false;
        
        neighbourhoodPanel = new Panel();
        neighbourhoodPanel.Parent = this;
        neighbourhoodPanel.Location = new Point(150, 30);
        neighbourhoodPanel.Text = "";
        neighbourhoodPanel.BackColor = Color.Coral;
        neighbourhoodPanel.Controls.Add(ulamRb);
        neighbourhoodPanel.Controls.Add(conwayRb);
        neighbourhoodPanel.Controls.Add(knightRb);
        neighbourhoodPanel.AutoSize = true;
        
        //Square mesh
        squareRb = new RadioButton();
        squareRb.Parent = this;
        squareRb.Location = new Point(240, 30);
        squareRb.Text = "Négyzetrács";
        squareRb.Checked = false;
        
        //Triangle mesh
        triangleRb = new RadioButton();
        triangleRb.Parent = this;
        triangleRb.Location = new Point(240, 60);
        triangleRb.Text = "Háromszögrács";
        triangleRb.Checked = false;
      
        //Hexagon mesh
        hexagonRb = new RadioButton();
        hexagonRb.Parent = this;
        hexagonRb.Location = new Point(240, 90);
        hexagonRb.Text = "Hatszögrács";
        hexagonRb.Checked = false;
      
        meshPanel = new Panel();
        meshPanel.Parent = this;
        meshPanel.Location = new Point(240, 30);
        meshPanel.Text = "";
        meshPanel.BackColor = Color.Coral;
        meshPanel.Controls.Add(squareRb);
        meshPanel.Controls.Add(triangleRb);  
        meshPanel.Controls.Add(hexagonRb);  
        meshPanel.AutoSize = true;
      
      //The eventhandler of the buttons is the function OnChanged(object sender, EventArgs e)
        cancel.CheckedChanged += new EventHandler(OnChanged);
        ok.CheckedChanged += new EventHandler(OnChanged);
        Paint += new PaintEventHandler(OnPaint);
        CenterToScreen();
    }

    void OnPaint(object sender, PaintEventArgs e)
    {      
        Graphics g = e.Graphics;
            
        g.FillRectangle(Brushes.Coral, 0, 0, sizeX, sizeY);

        g.Dispose();
        
    }
      
    void OnChanged(object sender, EventArgs e)
    {
    CheckBox clickedButton = sender as CheckBox;
    //CheckBox clickedButton = (CheckBox)sender;
    if (clickedButton == null) // just to be on the safe side
        return;

    //Cancel closes the window
    if (cancel.Checked)
    {
      Close();
    }
    //OK sends the information
    else if(ok.Checked)
    {
      //Sending information to the next form, 
      //that saves and gives away it.
      MatrixType matrix = MatrixType.RANDOM;
      NeighbourhoodType neighbourhood = NeighbourhoodType.CONWAY;
      MeshType mesh = MeshType.SQUARE;
    
      if (pointRb.Checked){
        matrix = MatrixType.ONE_POINT;
      }
      else if (randomRb.Checked){
        matrix = MatrixType.RANDOM;
      }
      if (ulamRb.Checked){
        neighbourhood = NeighbourhoodType.ULAM;
      }
      else if (conwayRb.Checked){
        neighbourhood = NeighbourhoodType.CONWAY;
      }
      else if (knightRb.Checked){
        neighbourhood = NeighbourhoodType.KNIGHT;
      }
      if (squareRb.Checked){
        mesh = MeshType.SQUARE;
      }
      else if (triangleRb.Checked){
        mesh = MeshType.TRIANGLE;
      }
      else if (hexagonRb.Checked){
        mesh = MeshType.HEXAGON;
      }
      
      RuleSettings rules = new RuleSettings(matrix, neighbourhood, mesh);
      rules.ShowDialog();
      this.Visible = false;
      this.Hide();
      this.Dispose();
    }
      
    
    // Ha az előbbiek felsorolási típusok lesznek, akkor itt konstruáljuk meg
    // az él-hal szabály párbeszédablakát
    }
    
    void OnExit(object sender, EventArgs e) {
        Close();
    }
}

class MApplication {
    public static void Main() {
        Application.Run(new Settings());
    }
}
