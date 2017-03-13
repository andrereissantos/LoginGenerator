using System;
using System.Collections.Generic;

namespace LoginGenerator
{
    class Utils
    {
        public Utils()
        {
            this.LoadNames();
        }
        public List<string> AccountNames { get; set; }
        private void LoadNames()
        {
            string path = AppDomain.CurrentDomain.BaseDirectory + "nomes.txt";

            if (!System.IO.File.Exists(path))
                System.IO.File.CreateText(path);

            string[] names = new System.IO.StreamReader(path).ReadToEnd().Split(',');

            AccountNames = new List<string>();

            foreach (var x in names)
            {
                AccountNames.Add(x.Replace("\"",""));
            }
        }
        private bool CheckLogin(string login)
        {
            return AccountNames.Contains(login.ToLower());
        }

        public string GenerateLogin(string fullName)
        {
            //method signature to supress the byRef parameter
            int i = 1;
            return (GenerateLogin(fullName, ref i));
        }
        private string GenerateLogin(string fullName, ref int iteration)
        {
            var login = "";
            fullName = fullName.Trim();
            string[] names = fullName.Split(' ');

            if (fullName.Length == 0)
                return Guid.NewGuid().ToString();

            if (iteration >= names[0].Length)
            {
                var iteration2 = iteration - names[0].Length;

                if((iteration - iteration2 - names[0].Length) == 0)
                {
                    login = names[0] + (1+iteration - names[0].Length).ToString();
                }
                else
                {
                    login = names[names.Length - 1] + names[0].Substring(0, iteration2);
                }
            }
            else
            { 
                login = names[0] + names[names.Length - 1].Substring(0, iteration - 1);
            }

            if (CheckLogin(login.ToLower()))
            {
                iteration++;
                return GenerateLogin(fullName, ref iteration);
            }
            return login;
        }
    }
}
