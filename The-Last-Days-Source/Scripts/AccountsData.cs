using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace The_Last_Days_Launcher.Scripts
{
    /*
     * This class manage the load and save of Accounts data of the Prism Launcher
    */

    public class AccountsData
    {
        //Classes of script
        public class LoadedData
        {
            //*** Data to be saved ***//

            public Account[] accounts = new Account[0];
            public int formatVersion = 0;
        }

        //Private variables
        private string filePath = "";

        //Public variables
        public LoadedData loadedData = null;

        //Core methods

        public AccountsData(string filePath)
        {
            //Check if save file exists
            bool saveExists = File.Exists(filePath);

            //Store the file path
            this.filePath = filePath;

            //If have a save file, load it
            if (saveExists == true)
                Load();
            //If a save file don't exists, create it
            if (saveExists == false)
                Save();
        }

        private void Load()
        {
            //Load the data
            string loadedDataString = File.ReadAllText(filePath);

            //Convert it to a loaded data object
            loadedData = JsonConvert.DeserializeObject<LoadedData>(loadedDataString);
        }

        //Public methods

        public void Save()
        {
            //If the loaded data is null, create one
            if (loadedData == null)
                loadedData = new LoadedData();

            //Save the data
            File.WriteAllText(filePath, JsonConvert.SerializeObject(loadedData));

            //Load the data to update loaded data
            Load();
        }
    }

    /*
     * Auxiliar classes
     * 
     * Classes that are objects that will be used, only to organize data inside 
     * "LoadedData" object in the saves.
    */

    public class Account
    {
        public bool active = false;
        public Entitlement entitlement = null;
        public Profile profile = null;
        public string type = "";
        public Ygg ygg = null;
    }

    public class Entitlement
    {
        public bool canPlayMinecraft = false;
        public bool ownsMinecraft = false;
    }

    public class Profile
    {
        public string[] capes = new string[0];
        public string id = "";
        public string name = "";
        public Skin skin = null;
    }

    public class Skin
    {
        public string id = "";
        public string url = "";
        public string variant = "";
    }

    public class Ygg
    {
        public Extra extra = null;
        public long iat = 0l;
        public string token = "";
    }

    public class Extra
    {
        public string clientToken = "";
        public string userName = "";
    }
}