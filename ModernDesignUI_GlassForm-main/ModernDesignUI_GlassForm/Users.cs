using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModernDesignUI_GlassForm
{
    class Users
    {
        protected string _realname, _password, _usernamelog, _email, _gender;
        protected int _id, level;

        public Users(string realname, string password, string usernamelog, string email, int id):this(usernamelog, password,realname,id)
        {
            _email = email;
        }
        public Users(string usernamelog, string password, string realname, int id)
        {
            _usernamelog = usernamelog;
            _password = password;
            _gender = "Prefer not to say";
            _realname = realname;
            _id = id;
        }

        public string UserNameLog
        {
            get { return _usernamelog; }
            set { _usernamelog = value; }
        }
        public string Password
        {
            get { return _password; }
            set { _password = value; }
        }

        public string RealName
        {
            get { return _realname; }
            set { _realname = value; }
        }

        public string Email
        {
            get { return _email; }
            set { _email = value; }
        }

        public string Gender
        {
            get { return _gender; }
            set { _gender = value; }
        }
        public void PromoteUser()
        {
            level++;
        }
        public void DemoteUser()
        {
            if (level > 0) level--;
        }
        public bool Login(string usernameLog, string password)
        {
            return _usernamelog == usernameLog && _password == password;
        }
    }
}
