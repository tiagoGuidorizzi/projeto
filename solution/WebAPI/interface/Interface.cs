using System;  
using System.Collections.Generic;  
using System.Linq; 

public interface IRepository<T> {
    IEnumerable<T> GetAll();
    void Add(T entity);
}