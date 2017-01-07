using System.Collections.Generic; 

   //Calculates neighbourhood number of one cell
public class HexagonUlamNeightbourHandler : NeightbourHandler {

  override public int neightbours_number(ModuloIndexableList<ModuloIndexableList<int> > matrix, int i, int j){
    int l = 0;
    if (i % 2 == 1){
      l = l + matrix[i-1][j];  
      l = l + matrix[i-1][j+1];  
      l = l + matrix[i][j-1];
      l = l + matrix[i][j+1];
      l = l + matrix[i+1][j];
      l = l + matrix[i+1][j+1];
    }
    else if (i % 2 == 0){
      l = l + matrix[i-1][j-1];  
      l = l + matrix[i-1][j];  
      l = l + matrix[i][j-1];
      l = l + matrix[i][j+1];
      l = l + matrix[i+1][j-1];
      l = l + matrix[i+1][j];
    }
    
    else System.Console.WriteLine("False.");
    return l;
  } 
 
}