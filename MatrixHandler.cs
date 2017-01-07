using System.Collections.Generic;

//The MatrixHandler defines and handles the matrix step by step
public abstract class MatrixHandler {
  //Generates random matrix
  public abstract ModuloIndexableList <ModuloIndexableList<int> > generate_random_matrix(int n, int m, double probability);
  //Generates empty matrix with one living cell
  public abstract ModuloIndexableList <ModuloIndexableList<int> > generate_matrix(int n, int m);
  //Calculates new matrix from the given one with help of given rule
  public abstract ModuloIndexableList<ModuloIndexableList<int> > new_matrix(ModuloIndexableList<ModuloIndexableList<int> > cell_matrix, List<List<int> > rule);
}