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
     * This class manage the download info of a JSON
    */

    public class DownloadInfo
    {
        //Classes of script
        public class LoadedData
        {
            //*** Data to be saved ***//

            public string version = "";
            public string[] downloads = new string[0];
        }

        //Private variables
        private string filePath = "";

        //Public variables
        public LoadedData loadedData = null;

        //Core methods

        public DownloadInfo(string filePath)
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
}
