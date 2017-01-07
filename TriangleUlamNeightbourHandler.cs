using System.Collections.Generic; 

   //Calculates neighbourhood number of one cell
public class TriangleUlamNeightbourHandler : NeightbourHandler {

  override public int neightbours_number(ModuloIndexableList<ModuloIndexableList<int> > matrix, int i, int j){
    int l = 0;
    if (i % 4 == 0){
      l = l + matrix[i-1][j];  
      l = l + matrix[i+1][j-1];
      l = l + matrix[i+1][j];
    }
    else if (i % 4 == 1){
      l = l + matrix[i-1][j];  
      l = l + matrix[i+1][j];
      l = l + matrix[i-1][j+1];
    }
    else if (i % 4 == 2){
      l = l + matrix[i-1][j];  
      l = l + matrix[i+1][j];
      l = l + matrix[i+1][j+1];
    }
    else if (i % 4 == 3){
      l = l + matrix[i-1][j-1];  
      l = l + matrix[i+1][j];
      l = l + matrix[i-1][j];
    }
    
    return l;
  } 
 
}