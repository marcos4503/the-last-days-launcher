using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using The_Last_Days_Launcher.Scripts;

namespace The_Last_Days_Launcher
{
    /*
     * This is the script responsible by the Nickname change of the Launcher
    */

    public partial class WindowNickChange : Window
    {
        //Cache variables
        private bool hasErrorInNickname = false;
        private bool hasErrorInPassword = false;

        //Private variables
        private string modpackPath = "";
        private AccountsData accountsData = null;

        //Core methods

        public WindowNickChange(string modpackPath)
        {
            //Initialize the Window
            InitializeComponent();

            //Store the data
            this.modpackPath = modpackPath;

            //Prepare the UI
            PrepareTheUI();
        }

        private void PrepareTheUI()
        {
            //Load the "accounts.json" of Prism Launcher
            accountsData = new AccountsData((modpackPath + @"/Game/accounts.json"));

            //Show the current nickname
            nickname.textBox.Text = accountsData.loadedData.accounts[0].profile.name;
            //Show the current password, if have the password file
            if (File.Exists((modpackPath + @"/Game/instances/The Last Days/.minecraft/.sl_password")) == true)
                password.textBox.Text = File.ReadAllText((modpackPath + @"/Game/instances/The Last Days/.minecraft/.sl_password"));

            //Prepare the validation rules for nickname
            nickname.RegisterOnTextChangedValidationCallback((currentInput) =>
            {
                //Prepare the value to return
                string toReturn = "";

                //Check if is empty, cancel here
                if (currentInput == "")
                    toReturn = "O campo não pode estar vazio!";
                //If is not empty...
                if (currentInput != "")
                {
                    //Check if is too long
                    if (currentInput.Length > 16)
                        toReturn = "O Nome de Usuário é muito longo.";
                    //Check if is too short
                    if (currentInput.Length < 3)
                        toReturn = "O Nome de Usuário é muito curto.";
                    //Check if contains spaces
                    if (currentInput.Contains(" ") == true)
                        toReturn = "O Nome de Usuário não pode conter espaços";
                    //Check if have only allowed characters
                    if (Regex.IsMatch(currentInput, @"^[a-zA-Z0-9_]+$") == false)
                        toReturn = "O Nome de Usuário só pode conter caracteres de A à Z, de 0 à 9, e underlines.";
                }

                //Inform error
                if (toReturn == "")
                    hasErrorInNickname = false;
                if (toReturn != "")
                    hasErrorInNickname = true;
                //Handle the button availability
                HandleTheFinishButtonAvailability();

                //Return the value
                return toReturn;
            });

            //Prepare the validation rules for password
            password.RegisterOnTextChangedValidationCallback((currentInput) => 
            {
                //Prepare the value to return
                string toReturn = "";

                //Check if is empty, cancel here
                if (currentInput == "")
                    toReturn = "O campo não pode estar vazio!";
                //If is not empty...
                if (currentInput != "")
                {
                    //Check if is too long
                    if (currentInput.Length > 32)
                        toReturn = "A senha está muito longa.";
                    //Check if is too short
                    if (currentInput.Length < 8)
                        toReturn = "A senha está muito curta.";
                }

                //Inform error
                if (toReturn == "")
                    hasErrorInPassword = false;
                if (toReturn != "")
                    hasErrorInPassword = true;
                //Handle the button availability
                HandleTheFinishButtonAvailability();

                //Return the value
                return toReturn;
            });

            //Force first validation of fields
            nickname.hasError();
            password.hasError();

            //Prepare the finish button
            finish.Click += (s, e) => { FinishEdit(); };
        }

        private void HandleTheFinishButtonAvailability()
        {
            //If have errors, disable the finish button
            if (hasErrorInNickname == true || hasErrorInPassword == true)
                finish.IsEnabled = false;

            //If don't have errors, enable the finish button
            if (hasErrorInNickname == false && hasErrorInPassword == false)
                finish.IsEnabled = true;
        }

        private void FinishEdit()
        {
            //If has erros on fields, cancel
            if (nickname.hasError() == true || password.hasError() == true)
                return;

            //Change the username on the "accounts.json" file and save
            accountsData.loadedData.accounts[0].active = true;
            accountsData.loadedData.accounts[0].profile.id = CreateMD5((nickname.textBox.Text + "_default")).ToLower();
            accountsData.loadedData.accounts[0].profile.name = nickname.textBox.Text;
            accountsData.loadedData.accounts[0].ygg.extra.clientToken = CreateMD5((nickname.textBox.Text + "_yggdrasil")).ToLower();
            accountsData.loadedData.accounts[0].ygg.extra.userName = nickname.textBox.Text;
            accountsData.loadedData.accounts[0].ygg.iat = CreateYggDrasilIAT(nickname.textBox.Text);

            //Save the nickname change
            accountsData.Save();

            //Save the password
            File.WriteAllText((modpackPath + @"/Game/instances/The Last Days/.minecraft/.sl_password"), password.textBox.Text);

            //Close this window
            this.Close();
        }

        //Auxiliar methods

        public static string CreateMD5(string input)
        {
            // Use input string to calculate MD5 hash
            using (System.Security.Cryptography.MD5 md5 = System.Security.Cryptography.MD5.Create())
            {
                byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(input);
                byte[] hashBytes = md5.ComputeHash(inputBytes);

                return Convert.ToHexString(hashBytes); // .NET 5 +

                // Convert the byte array to hexadecimal string prior to .NET 5
                // StringBuilder sb = new System.Text.StringBuilder();
                // for (int i = 0; i < hashBytes.Length; i++)
                // {
                //     sb.Append(hashBytes[i].ToString("X2"));
                // }
                // return sb.ToString();
            }
        }
    
        public static long CreateYggDrasilIAT(string input)
        {
            //Prepare the value to return
            long toReturn = 0;

            //Create the final string
            string finalString = (input + "_yggdrasil");

            //Create a loop foreach string character
            foreach(char c in finalString)
            {
                //Convert to hexadecimal
                string hex = Convert.ToByte(c).ToString();

                //Convert hexadecimal to int
                int number = Convert.ToInt32(hex, 16);

                //Increment on the value to return
                toReturn += number;
            }

            //Multiply the final number
            toReturn = toReturn * 85000l;

            //Return the value
            return toReturn;
        }
    }
}
