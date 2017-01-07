using System.Collections.Generic; 

   //Calculates neighbourhood number of one cell
public class HexagonConwayNeightbourHandler : NeightbourHandler {

  override public int neightbours_number(ModuloIndexableList<ModuloIndexableList<int> > matrix, int i, int j){
  HexagonUlamNeightbourHandler hhc = new HexagonUlamNeightbourHandler();
    int l = hhc.neightbours_number(matrix, i, j);

    if (i % 2 == 1){
      l = l + matrix[i-2][j];  
      l = l + matrix[i-1][j-1];  
      l = l + matrix[i-1][j+2];
      l = l + matrix[i+1][j-1];
      l = l + matrix[i+1][j+2];
      l = l + matrix[i+1][j];
    }
    else if (i % 2 == 0){
      l = l + matrix[i-2][j];  
      l = l + matrix[i-1][j-2];  
      l = l + matrix[i-1][j+1];
      l = l + matrix[i+1][j-2];
      l = l + matrix[i+1][j+1];
      l = l + matrix[i+1][j];
    }
    
    else System.Console.WriteLine("False.");
    return l;
  } 
 
}