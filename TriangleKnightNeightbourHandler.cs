using System.Collections.Generic; 

public class TriangleKnightNeightbourHandler : NeightbourHandler {

   //Calculates neighbourhood number of one cell
  override public int neightbours_number(ModuloIndexableList<ModuloIndexableList<int> > matrix, int i, int j){
    TriangleUlamNeightbourHandler thc = new TriangleUlamNeightbourHandler();
    int l = thc.neightbours_number(matrix, i, j);

      if (i % 4 == 0){
        l = l + matrix[i-3][j-1];  
        l = l + matrix[i-3][j];
        l = l + matrix[i+1][j+1];
        
        l = l + matrix[i+3][j+1];  
        l = l + matrix[i+1][j-2];
        l = l + matrix[i+3][j-1];
      }
      else if (i % 4 == 1){
        l = l + matrix[i-3][j-1];  
        l = l + matrix[i-1][j-1];
        l = l + matrix[i+3][j];
        
        l = l + matrix[i+3][j+1];  
        l = l + matrix[i-3][j+1];
        l = l + matrix[i-1][j+2];
        
      }
      else if (i % 4 == 2){
        l = l + matrix[i-3][j+1];  
        l = l + matrix[i-3][j];
        l = l + matrix[i+1][j+2];
        
        l = l + matrix[i+3][j+1];  
        l = l + matrix[i+1][j-1];
        l = l + matrix[i+3][j-1];
        
      }
      else if (i % 4 == 3){
        l = l + matrix[i-3][j-1];  
        l = l + matrix[i-1][j-2];
        l = l + matrix[i+3][j];
        
        l = l + matrix[i+3][j-1];  
        l = l + matrix[i-3][j+1];
        l = l + matrix[i-1][j+1];
        
      }

    return l;
  } 
 
}