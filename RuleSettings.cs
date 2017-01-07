using System;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;

class RuleSettings : Form {

    //Saved information for the MainDrawing
    private MatrixType matrix;
    private NeighbourhoodType neighbourhood;
    private MeshType mesh;

    //Size in direction x
    private int sizeX;
    //Size in direction y
    private int sizeY;
    
    //Cancelling button
    private CheckBox cancel;
    //OK button
    private CheckBox ok;
    
    //Rule setting CheckBoxes
    //CheckBoxes for the new living cells
    //How many neighbours must have a cell to become alive
    private CheckBox birth1;
    private CheckBox birth2;
    private CheckBox birth3;
    private CheckBox birth4;
    private CheckBox birth5;
    private CheckBox birth6;
    private CheckBox birth7;
    private CheckBox birth8;
    private CheckBox birth9;
    private CheckBox birth10;
    private CheckBox birth11;
    private CheckBox birth12;
    
    //CheckBoxes for the surviving cells
    //How many neighbours must have a cell to remain alive
    private CheckBox survive1;
    private CheckBox survive2;
    private CheckBox survive3;
    private CheckBox survive4;
    private CheckBox survive5;
    private CheckBox survive6;
    private CheckBox survive7;
    private CheckBox survive8;
    private CheckBox survive9;    
    private CheckBox survive10;
    private CheckBox survive11;
    private CheckBox survive12;   
    
    //Setting to show age of living cells
    private CheckBox age;
  
    public RuleSettings(MatrixType matrix = MatrixType.RANDOM, 
                NeighbourhoodType neighbourhood = NeighbourhoodType.CONWAY, 
                MeshType mesh = MeshType.SQUARE) {
        //Saves information for MainDrawing
        this.matrix = matrix;
        this.neighbourhood = neighbourhood;
        this.mesh = mesh;
        
        Text = "Életjáték él-hal szabályainak beállításai";
        sizeX = 700;
        sizeY = 340;
        Size = new Size(sizeX, sizeY);
       
        cancel = new System.Windows.Forms.CheckBox(); 
        cancel.Appearance = System.Windows.Forms.Appearance.Button; 
        cancel.Text = "Mégsem";
        cancel.Parent = this;
        cancel.Location = new Point(560, 150);
        cancel.BackColor = Color.Coral;
        cancel.Show();
        cancel.Visible = true;
        Controls.Add(cancel);
        
        ok = new System.Windows.Forms.CheckBox(); 
        ok.Appearance = System.Windows.Forms.Appearance.Button; 
        ok.Text = "OK";
        ok.Parent = this;
        ok.Location = new Point(560, 240);
        ok.BackColor = Color.Coral;
        ok.Show();
        ok.Visible = true;
        Controls.Add(ok);
        
        //Labelse for panels
        string birthLabelText = "A születő sejtek szomszédai";
        string surviveLabelText = "A túlélő sejtek szomszédai";
        
        
        Label birth = new Label();
        birth.Parent = this;
        birth.Text = birthLabelText;
        birth.Location = new Point(30, 30);
        birth.BackColor = Color.Coral;

        Label survive = new Label();
        survive.Parent = this;
        survive.Text = surviveLabelText;
        survive.Location = new Point(270, 30);
        survive.BackColor = Color.Coral;
        
        birth1 = new CheckBox();
        birth1.Parent = this;
        birth1.Location = new Point(30, 90);
        birth1.Text = "1";
        birth1.Checked = false;
        birth1.BackColor = Color.Coral;

        birth2 = new CheckBox();
        birth2.Parent = this;
        birth2.Location = new Point(30, 120);
        birth2.Text = "2";
        birth2.Checked = false;
        birth2.BackColor = Color.Coral;
        
        birth3 = new CheckBox();
        birth3.Parent = this;
        birth3.Location = new Point(30, 150);
        birth3.Text = "3";
        birth3.Checked = false;
        birth3.BackColor = Color.Coral;
        
        birth4 = new CheckBox();
        birth4.Parent = this;
        birth4.Location = new Point(30, 180);
        birth4.Text = "4";
        birth4.Checked = false;
        birth4.BackColor = Color.Coral;

        birth5 = new CheckBox();
        birth5.Parent = this;
        birth5.Location = new Point(30, 210);
        birth5.Text = "5";
        birth5.Checked = false;
        birth5.BackColor = Color.Coral;
        
        birth6 = new CheckBox();
        birth6.Parent = this;
        birth6.Location = new Point(30, 240);
        birth6.Text = "6";
        birth6.Checked = false;
        birth6.BackColor = Color.Coral;
        
        birth7 = new CheckBox();
        birth7.Parent = this;
        birth7.Location = new Point(150, 90);
        birth7.Text = "7";
        birth7.Checked = false;
        birth7.BackColor = Color.Coral;

        birth8 = new CheckBox();
        birth8.Parent = this;
        birth8.Location = new Point(150, 120);
        birth8.Text = "8";
        birth8.Checked = false;
        birth8.BackColor = Color.Coral;

        birth9 = new CheckBox();
        birth9.Parent = this;
        birth9.Location = new Point(150, 150);
        birth9.Text = "9";
        birth9.Checked = false;
        birth9.BackColor = Color.Coral;
        
        birth10 = new CheckBox();
        birth10.Parent = this;
        birth10.Location = new Point(150, 180);
        birth10.Text = "10";
        birth10.Checked = false;
        birth10.BackColor = Color.Coral;

        birth11 = new CheckBox();
        birth11.Parent = this;
        birth11.Location = new Point(150, 210);
        birth11.Text = "11";
        birth11.Checked = false;
        birth11.BackColor = Color.Coral;
        
        birth12 = new CheckBox();
        birth12.Parent = this;
        birth12.Location = new Point(150, 240);
        birth12.Text = "12";
        birth12.Checked = false;
        birth12.BackColor = Color.Coral;
        
        
        
        
        
        
        survive1 = new CheckBox();
        survive1.Parent = this;
        survive1.Location = new Point(270, 90);
        survive1.Text = "1";
        survive1.Checked = false;
        survive1.BackColor = Color.Coral;

        survive2 = new CheckBox();
        survive2.Parent = this;
        survive2.Location = new Point(270, 120);
        survive2.Text = "2";
        survive2.Checked = false;
        survive2.BackColor = Color.Coral;
        
        survive3 = new CheckBox();
        survive3.Parent = this;
        survive3.Location = new Point(270, 150);
        survive3.Text = "3";
        survive3.Checked = false;
        survive3.BackColor = Color.Coral;
        
        survive4 = new CheckBox();
        survive4.Parent = this;
        survive4.Location = new Point(270, 180);
        survive4.Text = "4";
        survive4.Checked = false;
        survive4.BackColor = Color.Coral;

        survive5 = new CheckBox();
        survive5.Parent = this;
        survive5.Location = new Point(270, 210);
        survive5.Text = "5";
        survive5.Checked = false;
        survive5.BackColor = Color.Coral;
        
        survive6 = new CheckBox();
        survive6.Parent = this;
        survive6.Location = new Point(270, 240);
        survive6.Text = "6";
        survive6.Checked = false;
        survive6.BackColor = Color.Coral;
        
        survive7 = new CheckBox();
        survive7.Parent = this;
        survive7.Location = new Point(390, 90);
        survive7.Text = "7";
        survive7.Checked = false;
        survive7.BackColor = Color.Coral;

        survive8 = new CheckBox();
        survive8.Parent = this;
        survive8.Location = new Point(390, 120);
        survive8.Text = "8";
        survive8.Checked = false;
        survive8.BackColor = Color.Coral;
        
        survive9 = new CheckBox();
        survive9.Parent = this;
        survive9.Location = new Point(390, 150);
        survive9.Text = "9";
        survive9.Checked = false;
        survive9.BackColor = Color.Coral;
        
        survive10 = new CheckBox();
        survive10.Parent = this;
        survive10.Location = new Point(390, 180);
        survive10.Text = "10";
        survive10.Checked = false;
        survive10.BackColor = Color.Coral;

        survive11 = new CheckBox();
        survive11.Parent = this;
        survive11.Location = new Point(390, 210);
        survive11.Text = "11";
        survive11.Checked = false;
        survive11.BackColor = Color.Coral;
        
        survive12 = new CheckBox();
        survive12.Parent = this;
        survive12.Location = new Point(390, 240);
        survive12.Text = "12";
        survive12.Checked = false; 
        survive12.BackColor = Color.Coral;
       
        age = new CheckBox();
        age.Parent = this;
        age.Location = new Point(500, 90);
        age.Text = "Kor szerinti\nszínezés";
        age.Checked = false; 
        age.BackColor = Color.Coral;
  
        //Setting the EventHandlers
        cancel.CheckedChanged += new EventHandler(OnCancelChanged);
        ok.CheckedChanged += new EventHandler(OnOkChanged);

        Paint += new PaintEventHandler(OnPaint);
        
        CenterToScreen();
    }

void OnPaint(object sender, PaintEventArgs e)
    {      
        Graphics g = e.Graphics;
            
        g.FillRectangle(Brushes.Coral, 0, 0, sizeX, sizeY);

        g.Dispose();
        
        cancel.Show();
        cancel.Visible = true;
        
        ok.Show();
        ok.Visible = true;
        
    }
 
    void OnCancelChanged(object sender, EventArgs e)
    {

      if (cancel.Checked)
      {
        Close();
      }
    }
    
    void OnOkChanged(object sender, EventArgs e) {


    if (ok.Checked)
    {

       //List of numbers of neighbours of borning and surviving cells
       List<int> borns = new List<int>();
       List<int> survives = new List<int>();
       
       bool ageT = false;
     
       if (birth1.Checked){borns.Add(1);}
       if (birth2.Checked){borns.Add(2);}
       if (birth3.Checked){borns.Add(3);}
       if (birth4.Checked){borns.Add(4);}
       if (birth5.Checked){borns.Add(5);}
       if (birth6.Checked){borns.Add(6);}
       if (birth7.Checked){borns.Add(7);}
       if (birth8.Checked){borns.Add(8);}
       if (birth9.Checked){borns.Add(9);}
       if (birth10.Checked){borns.Add(10);}
       if (birth11.Checked){borns.Add(11);}
       if (birth12.Checked){borns.Add(12);}
     
       if (survive1.Checked){survives.Add(1);}
       if (survive2.Checked){survives.Add(2);}
       if (survive3.Checked){survives.Add(3);}
       if (survive4.Checked){survives.Add(4);}
       if (survive5.Checked){survives.Add(5);}
       if (survive6.Checked){survives.Add(6);}
       if (survive7.Checked){survives.Add(7);}
       if (survive8.Checked){survives.Add(8);}
       if (survive9.Checked){survives.Add(9);}
       if (survive10.Checked){survives.Add(10);}
       if (survive11.Checked){survives.Add(11);}
       if (survive12.Checked){survives.Add(12);}
     
       if (age.Checked){ageT = true;}
       
       //The class MainDrawing is the central class that draws with SDL
       MainDrawing drawing = new MainDrawing(matrix, //= MatrixType.RANDOM, 
                  neighbourhood, //= NeighbourhoodType.CONWAY, 
                  mesh, //= MeshType.SQUARE,
                  borns, //= {2, 3},
                  survives, //= {2},
                  ageT //= false
                 );
     //Start drawing
     drawing.Drawing();
    }

    }
    
    
  }

