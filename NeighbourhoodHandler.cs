using System.Collections.Generic; 

//Calculates neighbourhood
public abstract class NeightbourHandler
{
   public NeightbourHandler()
   {
      // Code to initialize the class goes here.
   }

   //Calculates neighbourhood number of one cell
  abstract public int neightbours_number(ModuloIndexableList<ModuloIndexableList<int> > matrix, int i, int j);
   
  //Is the state of given cell living (1) or dead (0)
  //The program can display age of cells, hence the numbers
  public int live(ModuloIndexableList<ModuloIndexableList<int> > matrix, List<List<int> > rule, int i, int j){
    //Rows of rule correspond the states
    int n = neightbours_number(matrix, i, j);
    if (matrix[i][j] > 0){
      if (rule[1].Contains(n)) return 1;
      else return 0;
    }
    else if (matrix[i][j] == 0){
      if (rule[0].Contains(n)) return 1;
        else return 0;
      }
    else return 0;
  } 
}
