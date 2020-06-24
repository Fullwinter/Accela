using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Data.Entity.Core.EntityClient;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;

namespace AccelaTest
{
    interface IControler
    {
        bool AddPerson(Person person);
        bool AddPerson(int id, string firstName, string lastName);
        bool EditPerson(int id,string firstName, string lastName);
        bool DeletePerson(int id);
        int CountNumberPerson();
        List<Person> ListPersons();
        Person GetPersonById(int id);
    }

    //Controller class 
    public class Controller : IControler
    {
        PersonEntity entities;
        public Controller(PersonEntity testingEntities)
        {
            this.entities = testingEntities;
        }
        public bool AddPerson(int id, string firstName, string lastName)
        {
            Person p = new Person {id=id,  firstName = firstName, lastName = lastName };
            return AddPerson(p);
        }
        public bool AddPerson(Person person)
        {
            entities.Persons.Add(person);
            int i=entities.SaveChanges();
            return i>0;
        }
        public bool EditPerson(Person person)
        {
            Person p = GetPersonById(person.id);
            int i = 0;
            if (p!=null)
            {
                p.firstName = person.firstName;
                p.lastName = person.lastName;
                i= entities.SaveChanges();
            }
            return i>0;
        }
        public bool EditPerson(int id, string firstName, string lastName)
        {
            Person p = new Person {id=id,  firstName = firstName, lastName = lastName };
            return EditPerson(p);
        }
        public bool DeletePerson(int id)
        {
            Person person = GetPersonById(id);
            entities.Persons.Remove(person);
            int i = entities.SaveChanges();
            return i>0;
        }
        public int CountNumberPerson()
        {
            return entities.Persons.Count<Person>();
        }
        public List<Person> ListPersons()
        {
            return (from a in entities.Persons select a).ToList();
        }
        public Person GetPersonById(int id)
        {
            return entities.Persons.Where((x) => x.id == id).FirstOrDefault();
        }
    }


    
    public struct Conection
    {
        public Conection(string initialCatalog, string dataSource, string configConnectionStringName, bool integratedSecurity, string userId, string password)
        {
            this.initialCatalog = initialCatalog;
            this.dataSource = dataSource;
            this.configConnectionStringName = configConnectionStringName;
            this.integratedSecurity = integratedSecurity;
            this.userId = userId;
            this.password = password;
        }
        public string initialCatalog;
        public string dataSource;
        public string configConnectionStringName;
        public string userId;
        public string password;
        public bool integratedSecurity;
    }

    //allow to change the Connection from the Entity Framework
    public static class ConnectionTools
    {
        public static void ChangeDatabase(
            this DbContext source,
            Conection conn)
        {
            try
            {
                var entityCnxStringBuilder = new EntityConnectionStringBuilder(ConfigurationManager.ConnectionStrings[conn.configConnectionStringName].ConnectionString);
                var sqlCnxStringBuilder = new SqlConnectionStringBuilder(entityCnxStringBuilder.ProviderConnectionString);

                sqlCnxStringBuilder.InitialCatalog = conn.initialCatalog;
                sqlCnxStringBuilder.DataSource = conn.dataSource;
                sqlCnxStringBuilder.IntegratedSecurity = conn.integratedSecurity;

                if (!conn.integratedSecurity)
                {
                    sqlCnxStringBuilder.UserID = conn.userId;
                    sqlCnxStringBuilder.Password = conn.password;
                }

                source.Database.Connection.ConnectionString = sqlCnxStringBuilder.ConnectionString;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error Connection with the DB in 'ConnectionTools'", ex.Message.ToString());
            }
        }
    }


    //Auxilar class for work with files
    static class AuxFiles
    {

        public static void InsertfromFile(string filename,Controller control,out string errormessage)
        {
            string urls = filename;
            string[] url = urls.Split('\\');
            string name = url[url.Length - 1];
            string[] names = name.Split('.');
            string extension = names[names.Length - 1];
            errormessage = "";
            try
            {
                Person p;
                if (extension.Equals("xml"))
                {
                    p = Insertfromxml(urls);
                    if (Validator.ValidatePersonData("", p.firstName, p.lastName, out errormessage))
                        control.AddPerson(p);
                    else MessageBox.Show(errormessage, "Incorrect file");
                }
                else if (extension.Equals("json"))
                {
                    p = InsertfromJson(urls);
                    if (Validator.ValidatePersonData("", p.firstName, p.lastName, out errormessage))
                        control.AddPerson(p);
                    else MessageBox.Show(errormessage, "Incorrect file");
                }
                else MessageBox.Show("Not allowed extension", "Incorrect file");
            }
            catch (Exception ex)
            {
                errormessage= "Incorrect file";
            }
        }

        // Read a person from Json
        public static Person InsertfromJson(string file)
        {
            string id="", firstname="", lastName="";
            using (StreamReader r=File.OpenText(file))
            using (JsonTextReader reader=new JsonTextReader(r))
            {
                while(reader.Read())
                {
                    if (reader.Value != null)
                    {
                        switch (reader.Value.ToString())
                        {
                            case "id":
                                reader.Read();
                                id = reader.Value.ToString();
                            break;
                            case "firstName":
                                reader.Read();
                                firstname = reader.Value.ToString();
                            break;
                            case "lastName":
                                reader.Read();
                                lastName = reader.Value.ToString();
                            break;
                        }
                    }
                }
            }
            Person person= new Person{firstName = firstname, lastName= lastName};
            return person;
        }

        //Read a person from xml
        public static Person Insertfromxml(string file)
        {
            string id = "", firstname = "", lastName = "";
            using (XmlReader reader = XmlReader.Create(file))
            {
                while (reader.Read())
                {
                    if (reader.IsStartElement())
                    {
                        switch (reader.Name.ToString())
                        {
                            case "id":
                                id = reader.ReadString();
                                break;
                            case "firstName":
                                firstname = reader.ReadString();
                                break;
                            case "lastName":
                                lastName = reader.ReadString();
                                break;
                        }
                    }
                }
            }
            Person person = new Person { firstName = firstname, lastName = lastName };
            return person;
        }
    }
}
