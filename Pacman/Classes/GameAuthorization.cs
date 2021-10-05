using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

namespace Pacman
{
    class GameAuthorization
    {
        public bool isEmptyString { get; set; }
        public string incorectLogin { get; set; }
        public string incorectPassword { get; set; }

        public string enteredLogin { get; set; }
        public string enteredPassword { get; set; }

        public List<User> usersList { get; private set; }

        public GameAuthorization()
        {
            isEmptyString = false;
            incorectLogin = string.Empty;
            incorectPassword = string.Empty;
            enteredLogin = string.Empty;
            enteredPassword = string.Empty;
            usersList = new List<User>(LoadUsers());
        }
        ~GameAuthorization() { }

        private List<User> LoadUsers()
        {
            try
            {
                BinaryFormatter bf = new BinaryFormatter();

                using (FileStream fs = new FileStream(Resource.UsersPath, FileMode.OpenOrCreate))
                {
                    return (List<User>)bf.Deserialize(fs);
                }
            }
            catch { };
            return new List<User>();
        }

        public bool LogIn()
        {
            if (string.IsNullOrEmpty(enteredLogin)
                || string.IsNullOrEmpty(enteredPassword))
            {
                isEmptyString = true;
                return false;
            }
            else 
            {
                foreach (User item in usersList)
                {
                    if (item.login.Equals(enteredLogin)
                        && item.password.Equals(enteredPassword))
                    {
                        Methods.Save(Resource.CurrentUserPath, FileMode.Create, new User(enteredLogin, enteredPassword));
                        return true;
                    }
                    else if (item.login.Equals(enteredLogin)
                        && !enteredPassword.Equals(item.password))
                    {
                        incorectPassword = "You have entered an incorrect password!";
                        return false;
                    }
                }
                incorectLogin = "User \"" + enteredLogin + "\" not found!";
            }
            return false;
        }

        public bool Registration()
        {
            if (string.IsNullOrEmpty(enteredLogin)
                || string.IsNullOrEmpty(enteredPassword))
            {
                isEmptyString = true;
                return false;
            }
            else
            {
                foreach (User item in usersList)
                {
                    if (item.login.Equals(enteredLogin))
                    {
                        incorectLogin = "User with the nickname \"" +
                            enteredLogin + "\" is already registered!";

                        return false;
                    }
                }

                if (enteredLogin.Length < 4)
                {
                    incorectLogin = "The minimum length of the nickname is 4 characters!";
                    return false;
                }
                if (enteredPassword.Length < 4)
                {
                    incorectPassword = "The minimum length of the password is 4 characters!";
                    return false;
                }

                usersList.Add(new User(enteredLogin, enteredPassword));
                Methods.Save(Resource.UsersPath, FileMode.OpenOrCreate, usersList);

                return true;
            }
        }
    }
}
