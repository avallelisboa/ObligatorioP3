using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Obligatorio1.Models.BL
{
    public abstract class User
    {
        public string Password { get; private set; }
        public int Id { get; private set; }
        public string Role { get; private set; }


        protected User(int id, string password, string role) {Id = id; Password = password; Role = role;}

        private Tuple<bool,string> isPasswordValid()
        {
            bool isValid = false;
            string message = "La contraseña debe tener mínimo 6 caracteres, 1 mayúscula, 1 minúscula y 1 número";

            if (Password.Length >= 6 && Password.Any(ch => char.IsUpper(ch)) && Password.Any(ch => char.IsLower(ch)) && Password.Any(ch => char.IsNumber(ch)))
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

            int digits = Utilities.digitsNumber(id);
            if (digits == 7 || digits == 8)
            {
                isValid = true;
                message = "La cédula es correcta";
            }

            Tuple<bool, string> result = new Tuple<bool, string>(isValid, message);
            return result;
        }


        public Tuple<bool, string> isUserValid()
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