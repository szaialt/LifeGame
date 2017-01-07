using Tao.Sdl;
using System;
using System.Collections.Generic; 
using System.Linq;

public class QuadraticMatrixHandler : MatrixHandler {

  //static List<List<int> > rule;
  Random random;
  NeightbourHandler nh;
  bool ageT;
  
  public QuadraticMatrixHandler(Random random, NeightbourHandler nh, bool ageT) {
    this.random = random;
    this.nh = nh;
    this.ageT = ageT;
  }

  //Generates random matrix
override public ModuloIndexableList <ModuloIndexableList<int> > generate_random_matrix(int n, int m, double probability){
  ModuloIndexableList<ModuloIndexableList<int> > matrix = new ModuloIndexableList<ModuloIndexableList<int> >();
  
  for (int i = 0; i < n; i++){
    ModuloIndexableList<int> v = new ModuloIndexableList<int>();
    for (int j = 0; j < m; j++){
    //conversion to number inter 0 and 1 
       double r = random.NextDouble();
       if (r < probability){
         v.Add(1);
       }
       else {
         v.Add(0);
       }
    }
    matrix.Add(v);
  }
  return matrix;
} 

  //Generates empty matrix with one living cell
override public ModuloIndexableList <ModuloIndexableList<int> > generate_matrix(int n, int m){
  ModuloIndexableList<ModuloIndexableList<int> > matrix = new ModuloIndexableList<ModuloIndexableList<int> >();
  //Coordinates of middle points
  int n2 = n/2;
  int m2 = m/2;
  for (int i = 0; i < n; i++){
    ModuloIndexableList<int> v = new ModuloIndexableList<int>();
    for (int j = 0; j < m; j++){
       if ((i == n2) && (j == m2)){
         v.Add(1);
       }
       else {
         v.Add(0);
       }
    }
    matrix.Add(v);
  }
  return matrix;
} 
 
  //Calculates new matrix from the given one with help of given rule
override public ModuloIndexableList<ModuloIndexableList<int> > new_matrix(ModuloIndexableList<ModuloIndexableList<int> > cell_matrix, List<List<int> > rule){
  ModuloIndexableList<ModuloIndexableList<int> > matrix = new ModuloIndexableList<ModuloIndexableList<int> >();
  int m = cell_matrix[0].Count();
  int n = cell_matrix.Count();
  
  for (int i = 0; i < n; i++){
    ModuloIndexableList<int> v = new ModuloIndexableList<int>();
    for (int j = 0; j < m; j++){
      if ((ageT) && (nh.live(cell_matrix, rule, i, j) > 0))
      //Calculates age of living cells
         v.Add(cell_matrix[i][j] + nh.live(cell_matrix, rule, i, j)); 
       else
       //Calculates only if the cell will live
         v.Add(nh.live(cell_matrix, rule, i, j));  

    }
    matrix.Add(v);
  }
  return matrix;
}


}