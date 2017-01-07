using System.Collections.Generic; 

public class QuadraticConwayNeightbourHandler : NeightbourHandler {

   //Calculates neighbourhood number of one cell
  override public int neightbours_number(ModuloIndexableList<ModuloIndexableList<int> > matrix, int i, int j){
    int l = 0;
    for (int ii = i-1; ii < i+2; ii++){
      for (int jj = j-1; jj < j+2; jj++){
        if ((ii != i) || (jj != j)){
          l = l + matrix[ii][jj];
        }
      }  
    }
    return l;
  } 
}