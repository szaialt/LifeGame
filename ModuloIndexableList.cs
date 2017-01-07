using System;
using System.Collections.Generic;

//Modulo indexable container for 2D torus
//It makes easier to find neighbours of cells at extremes
  public class ModuloIndexableList<T> 
   {
   
    private List<T> list;
     
 
    public T this[int indx]
    {
      get
      {
          T tmp;
         
          int i = indx % list.Count;
          if (i < 0) i = i + list.Count;
            
          tmp = list[i];
           
          return ( tmp );
       }
        set
        {
           int i = indx % list.Count;
           if (i < 0) i = i + list.Count;
           this[i] = value;
             
        }
      }
      
    
     public ModuloIndexableList()
     {
       this.list = new List<T>();
     }

      //We need not all methods of List
      public int Count() {
        return list.Count;
      }
      
      public void Add(T item){
        list.Add(item);
      }
      
   }
