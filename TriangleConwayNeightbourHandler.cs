using System.Collections.Generic; 

   //Calculates neighbourhood number of one cell
public class TriangleConwayNeightbourHandler : NeightbourHandler {

  override public int neightbours_number(ModuloIndexableList<ModuloIndexableList<int> > matrix, int i, int j){
    TriangleUlamNeightbourHandler thc = new TriangleUlamNeightbourHandler();
    int l = thc.neightbours_number(matrix, i, j);

      if (i % 4 == 0){
        l = l + matrix[i-2][j-1];  
        l = l + matrix[i-1][j-1];
        l = l + matrix[i][j-1];
        
        l = l + matrix[i-2][j];  
        l = l + matrix[i-1][j+1];
        l = l + matrix[i][j+1];
        
        l = l + matrix[i+2][j-1];  
        l = l + matrix[i+3][j];
        l = l + matrix[i+2][j];
      }
      else if (i % 4 == 1){
        l = l + matrix[i-2][j];  
        l = l + matrix[i-3][j];
        l = l + matrix[i-2][j+1];
        
        l = l + matrix[i+2][j];  
        l = l + matrix[i+1][j-1];
        l = l + matrix[i][j-1];
        
        l = l + matrix[i+2][j+1];  
        l = l + matrix[i+1][j+1];
        l = l + matrix[i][j+1];
      }
      else if (i % 4 == 2){
        l = l + matrix[i-2][j];  
        l = l + matrix[i-1][j-1];
        l = l + matrix[i][j-1];
        
        l = l + matrix[i-2][j+1];  
        l = l + matrix[i-1][j+1];
        l = l + matrix[i][j+1];
        
        l = l + matrix[i+2][j];  
        l = l + matrix[i+3][j];
        l = l + matrix[i+2][j+1];
      }
      else if (i % 4 == 3){
        l = l + matrix[i-1][j-1];  
        l = l + matrix[i-2][j-1];
        l = l + matrix[i-3][j];
        
        l = l + matrix[i][j-1];  
        l = l + matrix[i+1][j-1];
        l = l + matrix[i+2][j];
        
        l = l + matrix[i][j+1];  
        l = l + matrix[i+1][j+1];
        l = l + matrix[i+2][j];
      }
   
    return l;
  } 
 
}