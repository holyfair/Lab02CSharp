using KMALab02BlahovProgramingInCSharp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KMALab02BlahovProgramingInCSharp.DataStorage
{
    internal interface IDataStorage
    {
        bool PersonExists(string email);

        Person GetPersonByEmail(string email);

        void RemovePerson(Person person);
        void AddPerson(Person person);
        List<Person> PersonsList { get; }
    }
}
