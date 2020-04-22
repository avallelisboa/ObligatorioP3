using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Obligatorio1.Models.BL
{
    public abstract class User
    {
        private string _password;

        public int Id { get; private set; }
        public string Role { get; private set; }


        protected User(int id, string password, string role) {Id = id; _password = password; Role = role;}

        private Tuple<bool,string> isPasswordValid()
        {
            string password = this._password;

            bool isValid = false;
            string message = "La contraseña debe tener mínimo 6 caracteres, 1 mayúscula, 1 minúscula y 1 número";

            if (password.Length >= 6 && password.Any(ch => char.IsUpper(ch)) && password.Any(ch => char.IsLower(ch)) && password.Any(ch => char.IsNumber(ch)))
            {
                isValid = true;
                message = "La contraseña es correcta";
            }

            Tuple<bool, string> result = new Tuple<bool, string>(isValid, message);
            return result;
        }

        private Tuple<bool, string> isIdValid()
        {
            int id = this.Id;
            string message = "La cédula debe tener 7 u 8 dígitos";
            bool isValid = false;

            int digits = digitsNumber(id);
            if (digits == 7 || digits == 8)
            {
                isValid = true;
                message = "La cédula es correcta";
            }

            Tuple<bool, string> result = new Tuple<bool, string>(isValid, message);
            return result;

            int digitsNumber(int n)
            {
                int d = 1;

                while (n >= 10)
                {
                    n /= 10;
                    d++;
                }

                return d;
            }
        }

        protected Tuple<bool, string> isUserValid()
        {
            string message = "";
            bool isValid = true;
            
            var idValid = isIdValid();
            var passwordValid = isPasswordValid();

            if (!idValid.Item1) isValid = false;
            else if (!passwordValid.Item1) isValid = false;

            message += idValid.Item2 + "\n";
            message += passwordValid.Item2;

            Tuple<bool, string> result = new Tuple<bool, string>(isValid, message);
            return result;
        }

        public IEnumerable<Product> GetProductsCollection()
        {
            throw new NotImplementedException();
        }
    }
}