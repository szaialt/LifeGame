using System.Collections.Generic; 

public class HexagonKnightNeightbourHandler : NeightbourHandler {

   //Calculates neighbourhood number of one cell
  override public int neightbours_number(ModuloIndexableList<ModuloIndexableList<int> > matrix, int i, int j){
  
    int l = matrix[i][j];

    if (i % 2 == 1){
      l = l + matrix[i-3][j];  
      l = l + matrix[i-3][j+1];  
      l = l + matrix[i-2][j+2];
      
      l = l + matrix[i-1][j+3];
      l = l + matrix[i+1][j+3];
      l = l + matrix[i+2][j+2];
      
      l = l + matrix[i+3][j];  
      l = l + matrix[i+3][j+1];  
      l = l + matrix[i+1][j-2];
      
      l = l + matrix[i+1][j-2];
      l = l + matrix[i-2][j-2];
      l = l + matrix[i-1][j-2];
    }
    else if (i % 2 == 0){
      l = l + matrix[i-3][j-1];  
      l = l + matrix[i-3][j];  
      l = l + matrix[i-2][j+2];
      
      l = l + matrix[i-1][j+2];
      l = l + matrix[i+1][j+2];
      l = l + matrix[i+2][j+2];
      
      l = l + matrix[i+3][j];  
      l = l + matrix[i+3][j-1];  
      l = l + matrix[i+1][j-3];
      
      l = l + matrix[i+2][j-2];
      l = l + matrix[i-1][j-3];
      l = l + matrix[i-2][j-2];
    }
    
    else System.Console.WriteLine("False.");
    return l;
  } 
 
}