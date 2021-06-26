using DAL.Models;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DAL
{
    public class MSSQLDAL : IDAL
    {

        private ContextDAL Context;

        public MSSQLDAL(ContextDAL context) 
        {
            Context = context;
        }

        public void Create(UserRegistrationData userRegistrationData)
        {

            if (Get(userRegistrationData.Login) == null)
            {
                PersonModel person = new PersonModel()
                {
                    Name = userRegistrationData.Name,
                    Lastname = userRegistrationData.LastName,
                    Email = userRegistrationData.Login,
                    Password = userRegistrationData.Password,
                    Admin = false,
                    RegisterDate = DateTime.Now,
                    LastVisitDate = DateTime.Now
                };

                Context.Persons.Add(person);
                Context.SaveChanges();
            }
            else
            {
                throw new Exception("User exist!");
            }
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

        public PersonModel Get(string email)
        {
            var person = Context.Persons.Where(s => s.Email == email).FirstOrDefault<PersonModel>();
            return person;
        }

        public void UpdatePassword(UserAutorizationData item)
        {
            PersonModel personModel = Get(item.Login);

            if (personModel != null)
            {
                personModel.Password = item.Password;
                Context.Persons.Update(personModel);
                Context.SaveChanges();
            }
            else 
            {
                throw new Exception("User not found(");
            }
        }
    }
}
