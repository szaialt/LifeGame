using System.Collections.Generic; 

public class QuadraticKnightNeightbourHandler : NeightbourHandler {

  //Calculates neighbourhood number of one cell
  override public int neightbours_number(ModuloIndexableList<ModuloIndexableList<int> > matrix, int i, int j){
    int l = 0;
   
    l = l + matrix[i][j];
    l = l + matrix[i-2][j-1];  
    l = l + matrix[i-2][j+1];
    l = l + matrix[i+2][j-1];
    l = l + matrix[i+2][j+1];
    l = l + matrix[i-1][j-2];  
    l = l + matrix[i+1][j-2];  
    l = l + matrix[i-1][j+2];  
    l = l + matrix[i+1][j+2];  

    return l;
  } 
 
}