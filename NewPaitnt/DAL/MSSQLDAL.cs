using DAL.Models;
using System;
using System.Collections.Generic;

namespace DAL
{
    public class MSSQLDAL : IDAL
    {

        private ContextDAL Context;

        public MSSQLDAL(ContextDAL context) 
        {
            Context = context;
        }

        public void Create(PersonModel item)
        {
            Context.Persons.Add(item);
            Context.SaveChanges();
        }

        public PersonModel Delete(int id)
        {
            PersonModel todoItem = Get(id);

            if (todoItem != null)
            {
                Context.Persons.Remove(todoItem);
                Context.SaveChanges();
            }

            return todoItem;
        }

        public IEnumerable<PersonModel> Get()
        {
            return Context.Persons;
        }

        public PersonModel Get(int id)
        {
            return Context.Persons.Find(id);
        }

        public void Update(PersonModel item)
        {
            Context.Persons.Update(item);
            Context.SaveChanges();
        }
    }
}
