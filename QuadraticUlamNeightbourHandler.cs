using System.Collections.Generic; 

public class QuadraticUlamNeightbourHandler : NeightbourHandler {

   //Calculates neighbourhood number of one cell
  override public int neightbours_number(ModuloIndexableList<ModuloIndexableList<int> > matrix, int i, int j){
    int l = 0;
    l = l + matrix[i-1][j];  
    l = l + matrix[i+1][j];
    l = l + matrix[i][j-1];
    l = l + matrix[i][j+1];
    

    return l;
  } 
 
}