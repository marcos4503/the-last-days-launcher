using MarcosTomaz.ATS;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using The_Last_Days_Launcher.Scripts;

namespace The_Last_Days_Launcher
{
    /*
     * This is the script responsible by the window of the launcher
    */

    public partial class MainWindow : Window
    {
        //Public enums
        public enum LauncherPage
        {
            Home,
            UploadSkin,
            Documentation,
            Preferences,
            About
        }
        public enum LauncherState
        {
            Normal,
            SystemTray
        }

        //Cache variables
        private bool canCloseWindow = true;
        private bool isPlayingGame = false;
        private LauncherPage currentPage = LauncherPage.Home;
        private string currentTaskTitle = "";
        private Process currentGameProcess = null;

        //Private variables
        private System.Windows.Forms.NotifyIcon launcherTrayIcon = null;
        private Preferences preferences = null;
        private string modpackPath = "";

        //Core methods

        public MainWindow()
        {
            //Check if have another process of the launcher already opened. If have, cancel this...
            string processName = Process.GetCurrentProcess().ProcessName;
            Process[] processes = Process.GetProcessesByName(processName);
            if (processes.Length > 1)
            {
                //Warn abou the problem
                MessageBox.Show("O The Last Days Launcher já está em execução!", "Erro");

                //Stop the execution of this instance
                System.Windows.Application.Current.Shutdown();

                //Cancel the execution
                return;
            }

            //Initialize the Window
            InitializeComponent();

            //Get the modpack path
            modpackPath = (Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "/.the-last-days");

            //Prepare the UI
            PrepareTheUI();
        }

        private void PrepareTheUI()
        {
            //Block the window close
            this.Closing += (s, e) =>
            {
                if (canCloseWindow == false)
                {
                    MessageBox.Show("Aguarde a conclusão de todas as tarefas em andamento, antes de fechar o The Last Days Launcher.",
                                    "Erro", MessageBoxButton.OK, MessageBoxImage.Error);
                    e.Cancel = true;
                    return;
                }
                if (isPlayingGame == true)
                {
                    SetLauncherState(LauncherState.SystemTray);
                    e.Cancel = true;
                    return;
                }
            };

            //Load the preferences
            preferences = new Preferences();

            //Show all settings
            pref_patch1.IsChecked = preferences.loadedData.enableBlackWorldAndBlocksPatch;

            //Create the modpack folder
            if (Directory.Exists(modpackPath) == false)
                Directory.CreateDirectory(modpackPath);

            //Reset the cache folder
            if (Directory.Exists((modpackPath + "/Cache")) == true)
                Directory.Delete((modpackPath + "/Cache"), true);

            //Create the folders structure
            if (Directory.Exists((modpackPath + "/Cache")) == false)
                Directory.CreateDirectory((modpackPath + "/Cache"));
            if (Directory.Exists((modpackPath + "/Downloads")) == false)
                Directory.CreateDirectory((modpackPath + "/Downloads"));
            if (Directory.Exists((modpackPath + "/Java")) == false)
                Directory.CreateDirectory((modpackPath + "/Java"));
            if (Directory.Exists((modpackPath + "/Launcher")) == false)
                Directory.CreateDirectory((modpackPath + "/Launcher"));
            if (Directory.Exists((modpackPath + "/Game")) == false)
                Directory.CreateDirectory((modpackPath + "/Game"));

            //Show the launcher version
            launcherVersion.Text = ("v" + GetLauncherVersion());

            //Calculate the value of chance for navarea
            int chanceNavarea = (new Random().Next(0, 100));
            //Calculate the background of the navarea
            if (chanceNavarea >= 0 && chanceNavarea <= 70)
                navareaBackground.Background = new LinearGradientBrush(Color.FromRgb(154, 154, 154), Color.FromRgb(47, 47, 47), new Point(0.5, 0), new Point(0.5, 1));
            if (chanceNavarea > 70 && chanceNavarea < 85)
            {
                navareaBackground.Background = new LinearGradientBrush(Color.FromRgb(249, 178, 105), Color.FromRgb(123, 56, 0), new Point(0.5, 0), new Point(0.5, 1));
                sunBg.Visibility = Visibility.Visible;
            }
            if (chanceNavarea >= 85 && chanceNavarea <= 100)
            {
                navareaBackground.Background = new LinearGradientBrush(Color.FromRgb(103, 154, 210), Color.FromRgb(4, 24, 84), new Point(0.5, 0), new Point(0.5, 1));
                moonBg.Visibility = Visibility.Visible;
            }  

            //Show random wallpaper
            ImageBrush wallpaperBrush = new ImageBrush(new BitmapImage(new Uri(@"pack://application:,,,/Resources/background-image-" + (new Random().Next(1, 4)) + ".png")));
            wallpaperBrush.Stretch = Stretch.UniformToFill;
            backgroundImage.Background = wallpaperBrush;

            //Change the UI do running task state
            taskDisplay.Visibility = Visibility.Collapsed;
            editNick.Opacity = 0.25f;
            editNick.IsHitTestVisible = false;
            profileNick.Text = "Carregando...";
            playButton.IsEnabled = false;
            patchWarnIcon.Visibility = Visibility.Collapsed;

            //Setup the links buttons
            goGitHub.Click += (s, e) => { System.Diagnostics.Process.Start(new ProcessStartInfo { FileName = "https://github.com/marcos4503/the-last-days-launcher", UseShellExecute = true }); };
            goDonate.Click += (s, e) => { System.Diagnostics.Process.Start(new ProcessStartInfo { FileName = "https://www.paypal.com/donate/?hosted_button_id=MVDJY3AXLL8T2", UseShellExecute = true }); };
            goDiscord.Click += (s, e) => { System.Diagnostics.Process.Start(new ProcessStartInfo { FileName = "https://discord.gg/cztusQyqrS", UseShellExecute = true }); };

            //Setup the menu buttons
            goHome.Click += (s, e) => { ChangeLauncherPage(LauncherPage.Home); };
            goSkin.Click += (s, e) => { ChangeLauncherPage(LauncherPage.UploadSkin); };
            goDocs.Click += (s, e) => { ChangeLauncherPage(LauncherPage.Documentation); };
            goPrefs.Click += (s, e) => { ChangeLauncherPage(LauncherPage.Preferences); };
            goAbout.Click += (s, e) => { ChangeLauncherPage(LauncherPage.About); };

            //Prepare the load documentation button
            loadDocsButton.Click += (s, e) => 
            {
                //Disable the load docs button
                loadDocsButton.IsEnabled = false;

                //Prepare the documentation webview
                webviewDocs.EnsureCoreWebView2Async();
                webviewDocs.CoreWebView2InitializationCompleted += (s, e) =>
                {
                    //Clear browsing cache
                    //webviewDocs.CoreWebView2.Profile.ClearBrowsingDataAsync();

                    //Navite to builtin documentation page
                    webviewDocs.CoreWebView2.Navigate("https://marcos4503.github.io/the-last-days-launcher/Repository-Pages/builtin-documentation/Documentation.html");

                    //Change to show the documentation
                    docsWarn.Visibility = Visibility.Collapsed;
                    webviewDocs.Visibility = Visibility.Visible;
                };
            };

            //Prepare the save preferences button
            savePrefsButton.Click += (s, e) => { SavePreferences(); };

            //Update the patch enabled warning
            UpdateThePatchEnabledWarning();

            //Change to home page
            ChangeLauncherPage(LauncherPage.Home);

            //Show versions info
            UpdateLauncherAboutVersionsInfo();

            //Start the patching
            StartPatching();
        }

        private void StartPatching()
        {
            //Inform that can't close the window
            canCloseWindow = false;

            //Change to loading state
            playButton.IsEnabled = false;
            taskDisplay.Visibility = Visibility.Visible;

            //Inform current task
            currentTaskTitle = "Carregando";
            UpdateTaskProgressBar("0-0");

            //Start the task title animator
            AsyncTaskSimplified asyncTask = new AsyncTaskSimplified(this, new string[] { });
            asyncTask.onStartTask_RunMainThread += (callerWindow, startParams) => { };
            asyncTask.onExecuteTask_RunBackground += (callerWindow, startParams, threadTools) =>
            {
                //Prepare the iteration counter
                int iterationCounter = 1;

                //Start the animation loop
                while (true)
                {
                    //If the title is empty, break the loop
                    if (currentTaskTitle == "")
                        break;

                    //If iteration is more than 3, reset
                    if (iterationCounter > 4)
                        iterationCounter = 1;

                    //Do the animation
                    threadTools.ReportNewProgress(iterationCounter.ToString());
                    //Increase the iteration counter
                    iterationCounter += 1;

                    //Wait some time
                    threadTools.MakeThreadSleep(250);
                }

                //Finish the thread...
                return new string[] { "none" };
            };
            asyncTask.onNewProgress_RunMainThread += (callerWindow, newProgress) => 
            {
                //Do the animation
                switch (newProgress)
                {
                    case "1":
                        taskName.Text = (currentTaskTitle);
                        break;
                    case "2":
                        taskName.Text = (currentTaskTitle + ".");
                        break;
                    case "3":
                        taskName.Text = (currentTaskTitle + "..");
                        break;
                    case "4":
                        taskName.Text = (currentTaskTitle + "...");
                        break;
                }
            };
            asyncTask.onDoneTask_RunMainThread += (callerWindow, backgroundResult) => { };
            asyncTask.Execute(AsyncTaskSimplified.ExecutionMode.NewDefaultThread);

            //Do the Java patch
            DoJavaPatch();
        }

        private void DoJavaPatch()
        {
            //Start a thread to download the current version info
            AsyncTaskSimplified asyncTask = new AsyncTaskSimplified(this, new string[] { });
            asyncTask.onStartTask_RunMainThread += (callerWindow, startParams) => { };
            asyncTask.onExecuteTask_RunBackground += (callerWindow, startParams, threadTools) =>
            {
                //Wait some time
                //threadTools.MakeThreadSleep(1000);

                //Try to do the task
                try
                {
                    //Inform java checking
                    currentTaskTitle = "Verificando Java";

                    //Wait some time
                    threadTools.MakeThreadSleep(2500);

                    //Download java info
                    if(true == true)
                    {
                        //Prepare the target download URL
                        string downloadUrl = @"https://marcos4503.github.io/the-last-days-launcher/Repository-Pages/openjdk/current-java-info.json";
                        string saveAsPath = (modpackPath + @"/Cache/current-java-info.json");
                        //Download the current version file
                        HttpClient httpClient = new HttpClient();
                        HttpResponseMessage httpRequestResult = httpClient.GetAsync(downloadUrl).Result;
                        httpRequestResult.EnsureSuccessStatusCode();
                        Stream downloadStream = httpRequestResult.Content.ReadAsStreamAsync().Result;
                        FileStream fileStream = new FileStream(saveAsPath, FileMode.Create, FileAccess.Write, FileShare.None);
                        downloadStream.CopyTo(fileStream);
                        httpClient.Dispose();
                        fileStream.Dispose();
                        fileStream.Close();
                        downloadStream.Dispose();
                        downloadStream.Close();
                    }

                    //Parse the download info file
                    DownloadInfo javaDownloadInfo = new DownloadInfo((modpackPath + @"/Cache/current-java-info.json"));

                    //Get the local java info
                    string localJavaVersion = "";
                    if (File.Exists((modpackPath + @"/Java/local-current-version.txt")) == true)
                        localJavaVersion = File.ReadAllText((modpackPath + @"/Java/local-current-version.txt"));

                    //If the local java version is different from the server, start the java download and install
                    if (localJavaVersion != javaDownloadInfo.loadedData.version)
                    {
                        //Re-create Java folder
                        if (Directory.Exists((modpackPath + @"/Java")) == true)
                            Directory.Delete((modpackPath + @"/Java"), true);
                        Directory.CreateDirectory((modpackPath + @"/Java"));

                        //Notify downloading
                        currentTaskTitle = "Baixando Java";
                        threadTools.ReportNewProgress(("0-" + javaDownloadInfo.loadedData.downloads.Length));

                        //Wait some time
                        threadTools.MakeThreadSleep(2500);

                        //Prepare the list of downloaded files
                        List<string> downloadedFilesList = new List<string>();
                        //Download all java parts
                        for(int i = 0; i < javaDownloadInfo.loadedData.downloads.Length; i++)
                        {
                            //Split download URL parts
                            string[] downloadUriParts = javaDownloadInfo.loadedData.downloads[i].Split("/");
                            //Prepare the save as path
                            string saveAsPath = (modpackPath + @"/Cache/" + downloadUriParts[downloadUriParts.Length - 1]);
                            //Download the current version file
                            HttpClient httpClient = new HttpClient();
                            HttpResponseMessage httpRequestResult = httpClient.GetAsync(javaDownloadInfo.loadedData.downloads[i]).Result;
                            httpRequestResult.EnsureSuccessStatusCode();
                            Stream downloadStream = httpRequestResult.Content.ReadAsStreamAsync().Result;
                            FileStream fileStream = new FileStream(saveAsPath, FileMode.Create, FileAccess.Write, FileShare.None);
                            downloadStream.CopyTo(fileStream);
                            httpClient.Dispose();
                            fileStream.Dispose();
                            fileStream.Close();
                            downloadStream.Dispose();
                            downloadStream.Close();

                            //Add downloaded file to list
                            downloadedFilesList.Add(saveAsPath);

                            //Inform the progress
                            threadTools.ReportNewProgress((((float)(i + 1)) + "-" + javaDownloadInfo.loadedData.downloads.Length));
                        }

                        //Notify install
                        currentTaskTitle = "Instalando Java";
                        threadTools.ReportNewProgress(("0-0"));

                        //Wait some time
                        threadTools.MakeThreadSleep(2500);

                        //Extract downloaded file
                        Process process = new Process();
                        process.StartInfo.FileName = System.IO.Path.Combine(modpackPath, "Launcher", "Resources", "7Zip", "7z.exe");
                        process.StartInfo.WorkingDirectory = System.IO.Path.Combine(modpackPath, "Launcher", "Resources", "7Zip");
                        process.StartInfo.Arguments = "x \"" + downloadedFilesList[0] + "\" -o\"" + (modpackPath + @"/Java") + "\"";
                        process.StartInfo.UseShellExecute = false;
                        process.StartInfo.CreateNoWindow = true;  //<- Hide the process window
                        process.StartInfo.RedirectStandardOutput = true;
                        process.Start();
                        //Wait process finishes
                        process.WaitForExit();

                        //Store the new downloaded java version
                        File.WriteAllText((modpackPath + @"/Java/local-current-version.txt"), javaDownloadInfo.loadedData.version);

                        //Wait some time
                        threadTools.MakeThreadSleep(2500);
                    }

                    //Return a success response
                    return new string[] { "success" };
                }
                catch (Exception ex)
                {
                    //Return a error response
                    return new string[] { "error" };
                }

                //Finish the thread...
                return new string[] { "none" };
            };
            asyncTask.onNewProgress_RunMainThread += (callerWindow, newProgress) =>
            {
                //Inform the progress
                UpdateTaskProgressBar(newProgress);
            };
            asyncTask.onDoneTask_RunMainThread += (callerWindow, backgroundResult) =>
            {
                //Get the thread response
                string threadTaskResponse = backgroundResult[0];

                //If have a response not success, close
                if (threadTaskResponse != "success")
                {
                    CloseLauncherWithError("Houve um problema ao atualizar o Java do Modpack.");
                    return;
                }

                //Do game patch
                DoGamePatch();
            };
            asyncTask.Execute(AsyncTaskSimplified.ExecutionMode.NewDefaultThread);
        }

        private void DoGamePatch()
        {
            //Start a thread to download the current version info
            AsyncTaskSimplified asyncTask = new AsyncTaskSimplified(this, new string[] { });
            asyncTask.onStartTask_RunMainThread += (callerWindow, startParams) => { };
            asyncTask.onExecuteTask_RunBackground += (callerWindow, startParams, threadTools) =>
            {
                //Wait some time
                //threadTools.MakeThreadSleep(1000);

                //Try to do the task
                try
                {
                    //Inform java checking
                    currentTaskTitle = "Verificando Dados de Jogo";

                    //Wait some time
                    threadTools.MakeThreadSleep(2500);

                    //Download game data info
                    if (true == true)
                    {
                        //Prepare the target download URL
                        string downloadUrl = @"https://marcos4503.github.io/the-last-days-launcher/Repository-Pages/game-data/current-game-data-info.json";
                        string saveAsPath = (modpackPath + @"/Cache/current-game-data-info.json");
                        //Download the current version file
                        HttpClient httpClient = new HttpClient();
                        HttpResponseMessage httpRequestResult = httpClient.GetAsync(downloadUrl).Result;
                        httpRequestResult.EnsureSuccessStatusCode();
                        Stream downloadStream = httpRequestResult.Content.ReadAsStreamAsync().Result;
                        FileStream fileStream = new FileStream(saveAsPath, FileMode.Create, FileAccess.Write, FileShare.None);
                        downloadStream.CopyTo(fileStream);
                        httpClient.Dispose();
                        fileStream.Dispose();
                        fileStream.Close();
                        downloadStream.Dispose();
                        downloadStream.Close();
                    }

                    //Parse the download info file
                    DownloadInfo gameDownloadInfo = new DownloadInfo((modpackPath + @"/Cache/current-game-data-info.json"));

                    //Get the local game data info
                    string localGameVersion = "";
                    if (File.Exists((modpackPath + @"/Game/local-current-version.txt")) == true)
                        localGameVersion = File.ReadAllText((modpackPath + @"/Game/local-current-version.txt"));

                    //If the local game data version is different from the server, start the game data download and install
                    if (localGameVersion != gameDownloadInfo.loadedData.version)
                    {
                        //Notify downloading
                        currentTaskTitle = "Baixando Dados de Jogo";
                        threadTools.ReportNewProgress(("0-" + gameDownloadInfo.loadedData.downloads.Length));

                        //Wait some time
                        threadTools.MakeThreadSleep(2500);

                        //Prepare the list of downloaded files
                        List<string> downloadedFilesList = new List<string>();
                        //Download all java parts
                        for (int i = 0; i < gameDownloadInfo.loadedData.downloads.Length; i++)
                        {
                            //Split download URL parts
                            string[] downloadUriParts = gameDownloadInfo.loadedData.downloads[i].Split("/");
                            //Prepare the save as path
                            string saveAsPath = (modpackPath + @"/Cache/" + downloadUriParts[downloadUriParts.Length - 1]);
                            //Download the current version file
                            HttpClient httpClient = new HttpClient();
                            HttpResponseMessage httpRequestResult = httpClient.GetAsync(gameDownloadInfo.loadedData.downloads[i]).Result;
                            httpRequestResult.EnsureSuccessStatusCode();
                            Stream downloadStream = httpRequestResult.Content.ReadAsStreamAsync().Result;
                            FileStream fileStream = new FileStream(saveAsPath, FileMode.Create, FileAccess.Write, FileShare.None);
                            downloadStream.CopyTo(fileStream);
                            httpClient.Dispose();
                            fileStream.Dispose();
                            fileStream.Close();
                            downloadStream.Dispose();
                            downloadStream.Close();

                            //Add downloaded file to list
                            downloadedFilesList.Add(saveAsPath);

                            //Inform the progress
                            threadTools.ReportNewProgress((((float)(i + 1)) + "-" + gameDownloadInfo.loadedData.downloads.Length));
                        }

                        //Notify install
                        currentTaskTitle = "Atualizando Dados de Jogo";
                        threadTools.ReportNewProgress(("0-0"));

                        //Wait some time
                        threadTools.MakeThreadSleep(2500);

                        //Extract downloaded file
                        Process process = new Process();
                        process.StartInfo.FileName = System.IO.Path.Combine(modpackPath, "Launcher", "Resources", "7Zip", "7z.exe");
                        process.StartInfo.WorkingDirectory = System.IO.Path.Combine(modpackPath, "Launcher", "Resources", "7Zip");
                        process.StartInfo.Arguments = "x \"" + downloadedFilesList[0] + "\" -o\"" + (modpackPath + @"/Game") + "\" -y";  //<- Extract to "Game" overwriting existant
                        process.StartInfo.UseShellExecute = false;
                        process.StartInfo.CreateNoWindow = true;  //<- Hide the process window
                        process.StartInfo.RedirectStandardOutput = true;
                        process.Start();
                        //Wait process finishes
                        process.WaitForExit();

                        //Store the new downloaded java version
                        File.WriteAllText((modpackPath + @"/Game/local-current-version.txt"), gameDownloadInfo.loadedData.version);

                        //Wait some time
                        threadTools.MakeThreadSleep(2500);

                        //Notify config
                        currentTaskTitle = "Configurando Dados de Jogo";
                        threadTools.ReportNewProgress(("0-0"));

                        //Wait some time
                        threadTools.MakeThreadSleep(2500);

                        //Open the "prismlauncher.cfg"
                        CfgFile prismLauncherCfg = new CfgFile((modpackPath + @"/Game/prismlauncher.cfg"));

                        //Update the settings
                        prismLauncherCfg.UpdateValue("LastHostname", System.Environment.MachineName);
                        prismLauncherCfg.UpdateValue("IgnoreJavaWizard", "true");
                        prismLauncherCfg.UpdateValue("JavaPath", (modpackPath.Replace("/", "\\") + @"\Java\bin\javaw.exe").Replace("\\", "/"));
                        prismLauncherCfg.UpdateValue("MaxMemAlloc", "8096");
                        prismLauncherCfg.UpdateValue("MinMemAlloc", "2048");
                        prismLauncherCfg.UpdateValue("PermGen", "512");
                        prismLauncherCfg.UpdateValue("CloseAfterLaunch", "true");
                        prismLauncherCfg.UpdateValue("QuitAfterGameStop", "true");
                        prismLauncherCfg.UpdateValue("DownloadsDir", (modpackPath.Replace("/", "\\") + @"\Downloads").Replace("\\", "/"));
                        prismLauncherCfg.UpdateValue("SelectedInstance", "The Last Days");

                        //Save the "prismlauncher.cfg"
                        prismLauncherCfg.Save();

                        //Notify config
                        currentTaskTitle = "Configurando Dados do The Last Days";
                        threadTools.ReportNewProgress(("0-0"));

                        //Wait some time
                        threadTools.MakeThreadSleep(2500);

                        //Open the "instance.cfg"
                        CfgFile instanceCfg = new CfgFile((modpackPath + @"/Game/instances/The Last Days/instance.cfg"));

                        //Update the settings
                        instanceCfg.UpdateValue("JavaPath", (modpackPath.Replace("/", "\\") + @"\Java\bin\javaw.exe").Replace("\\", "/"));
                        instanceCfg.UpdateValue("MaxMemAlloc", "8096");
                        instanceCfg.UpdateValue("MinMemAlloc", "2048");
                        instanceCfg.UpdateValue("PermGen", "512");

                        //Save the "instance.cfg"
                        instanceCfg.Save();
                    }

                    //Return a success response
                    return new string[] { "success" };
                }
                catch (Exception ex)
                {
                    //Return a error response
                    return new string[] { "error" };
                }

                //Finish the thread...
                return new string[] { "none" };
            };
            asyncTask.onNewProgress_RunMainThread += (callerWindow, newProgress) =>
            {
                //Inform the progress
                UpdateTaskProgressBar(newProgress);
            };
            asyncTask.onDoneTask_RunMainThread += (callerWindow, backgroundResult) =>
            {
                //Get the thread response
                string threadTaskResponse = backgroundResult[0];

                //If have a response not success, close
                if (threadTaskResponse != "success")
                {
                    CloseLauncherWithError("Houve um problema ao atualizar os dados de jogo.");
                    return;
                }

                //Do modpack patch
                DoModpackPatch();
            };
            asyncTask.Execute(AsyncTaskSimplified.ExecutionMode.NewDefaultThread);
        }

        private void DoModpackPatch()
        {
            //Start a thread to download the current version info
            AsyncTaskSimplified asyncTask = new AsyncTaskSimplified(this, new string[] { });
            asyncTask.onStartTask_RunMainThread += (callerWindow, startParams) => { };
            asyncTask.onExecuteTask_RunBackground += (callerWindow, startParams, threadTools) =>
            {
                //Wait some time
                //threadTools.MakeThreadSleep(1000);

                //Try to do the task
                try
                {
                    //Inform java checking
                    currentTaskTitle = "Verificando Dados do Modpack";

                    //Wait some time
                    threadTools.MakeThreadSleep(2500);

                    //Download java info
                    if (true == true)
                    {
                        //Prepare the target download URL
                        string downloadUrl = @"https://marcos4503.github.io/the-last-days-launcher/Repository-Pages/modpack-data/current-modpack-info.json";
                        string saveAsPath = (modpackPath + @"/Cache/current-modpack-info.json");
                        //Download the current version file
                        HttpClient httpClient = new HttpClient();
                        HttpResponseMessage httpRequestResult = httpClient.GetAsync(downloadUrl).Result;
                        httpRequestResult.EnsureSuccessStatusCode();
                        Stream downloadStream = httpRequestResult.Content.ReadAsStreamAsync().Result;
                        FileStream fileStream = new FileStream(saveAsPath, FileMode.Create, FileAccess.Write, FileShare.None);
                        downloadStream.CopyTo(fileStream);
                        httpClient.Dispose();
                        fileStream.Dispose();
                        fileStream.Close();
                        downloadStream.Dispose();
                        downloadStream.Close();
                    }

                    //Parse the download info file
                    DownloadInfo modpackDownloadInfo = new DownloadInfo((modpackPath + @"/Cache/current-modpack-info.json"));

                    //Get the local game data info
                    string localModpackVersion = "";
                    if (File.Exists((modpackPath + @"/Game/instances/The Last Days/.minecraft/local-current-version.txt")) == true)
                        localModpackVersion = File.ReadAllText((modpackPath + @"/Game/instances/The Last Days/.minecraft/local-current-version.txt"));

                    //If the local modpack data version is different from the server, start the game data download and install
                    if (localModpackVersion != modpackDownloadInfo.loadedData.version)
                    {
                        //Notify downloading
                        currentTaskTitle = "Baixando Dados do Modpack";
                        threadTools.ReportNewProgress(("0-" + modpackDownloadInfo.loadedData.downloads.Length));

                        //Wait some time
                        threadTools.MakeThreadSleep(2500);

                        //Prepare the list of downloaded files
                        List<string> downloadedFilesList = new List<string>();
                        //Download all java parts
                        for (int i = 0; i < modpackDownloadInfo.loadedData.downloads.Length; i++)
                        {
                            //Split download URL parts
                            string[] downloadUriParts = modpackDownloadInfo.loadedData.downloads[i].Split("/");
                            //Prepare the save as path
                            string saveAsPath = (modpackPath + @"/Cache/" + downloadUriParts[downloadUriParts.Length - 1]);
                            //Download the current version file
                            HttpClient httpClient = new HttpClient();
                            HttpResponseMessage httpRequestResult = httpClient.GetAsync(modpackDownloadInfo.loadedData.downloads[i]).Result;
                            httpRequestResult.EnsureSuccessStatusCode();
                            Stream downloadStream = httpRequestResult.Content.ReadAsStreamAsync().Result;
                            FileStream fileStream = new FileStream(saveAsPath, FileMode.Create, FileAccess.Write, FileShare.None);
                            downloadStream.CopyTo(fileStream);
                            httpClient.Dispose();
                            fileStream.Dispose();
                            fileStream.Close();
                            downloadStream.Dispose();
                            downloadStream.Close();

                            //Add downloaded file to list
                            downloadedFilesList.Add(saveAsPath);

                            //Inform the progress
                            threadTools.ReportNewProgress((((float)(i + 1)) + "-" + modpackDownloadInfo.loadedData.downloads.Length));
                        }

                        //Notify install
                        currentTaskTitle = "Atualizando Dados do Modpack";
                        threadTools.ReportNewProgress(("0-0"));

                        //Wait some time
                        threadTools.MakeThreadSleep(2500);

                        //Create a temp folder for modpack data extraction
                        Directory.CreateDirectory((modpackPath + @"/Cache/ModpackData"));

                        //Extract downloaded file
                        Process process = new Process();
                        process.StartInfo.FileName = System.IO.Path.Combine(modpackPath, "Launcher", "Resources", "7Zip", "7z.exe");
                        process.StartInfo.WorkingDirectory = System.IO.Path.Combine(modpackPath, "Launcher", "Resources", "7Zip");
                        process.StartInfo.Arguments = "x \"" + downloadedFilesList[0] + "\" -o\"" + (modpackPath + @"/Cache/ModpackData") + "\"";
                        process.StartInfo.UseShellExecute = false;
                        process.StartInfo.CreateNoWindow = true;  //<- Hide the process window
                        process.StartInfo.RedirectStandardOutput = true;
                        process.Start();
                        //Wait process finishes
                        process.WaitForExit();

                        //Build a list of unwanted files
                        List<string> unwantedFiles = new List<string>();
                        unwantedFiles.Add(".sl_password");
                        unwantedFiles.Add("icon.png");
                        unwantedFiles.Add("options.txt");
                        unwantedFiles.Add("usercache.json");
                        unwantedFiles.Add("usernamecache.json");
                        unwantedFiles.Add("local-current-version.txt");
                        //Build a list of unwanted folders
                        List<string> unwantedFolders = new List<string>();
                        unwantedFolders.Add("crash-reports");
                        unwantedFolders.Add("logs");
                        unwantedFolders.Add("saves");
                        unwantedFolders.Add("screenshots");
                        unwantedFolders.Add("shaderpacks");
                        //Delete unwanted files from the extracted content of ZIP
                        foreach (string fileName in unwantedFiles)
                            if (File.Exists((modpackPath + @"/Cache/ModpackData/" + fileName)) == true)
                                File.Delete((modpackPath + @"/Cache/ModpackData/" + fileName));
                        //Delete unwanted folders from the extracted content of ZIP
                        foreach (string dirName in unwantedFolders)
                            if (Directory.Exists((modpackPath + @"/Cache/ModpackData/" + dirName)) == true)
                                Directory.Delete((modpackPath + @"/Cache/ModpackData/" + dirName), true);

                        //Prepare the list of folders and files found in the extracted content of ZIP of the modpack data
                        List<string> folderNamesFoundInZip = new List<string>();
                        List<string> fileNamesFoundInZip = new List<string>();
                        //Fill the lists
                        foreach (DirectoryInfo dir in (new DirectoryInfo((modpackPath + @"/Cache/ModpackData"))).GetDirectories())
                            folderNamesFoundInZip.Add(dir.Name);
                        foreach (FileInfo file in (new DirectoryInfo((modpackPath + @"/Cache/ModpackData"))).GetFiles())
                            fileNamesFoundInZip.Add(System.IO.Path.GetFileName(file.FullName));

                        //Delete all folders found in the The Last Days instance, that have name of folders found in ZIP
                        foreach (string folderName in folderNamesFoundInZip)
                            if (Directory.Exists((modpackPath + @"/Game/instances/The Last Days/.minecraft/" + folderName)) == true)
                                Directory.Delete((modpackPath + @"/Game/instances/The Last Days/.minecraft/" + folderName), true);
                        //Delete all files found in the The Last Days instance, that have name of files found in ZIP
                        foreach (string fileName in fileNamesFoundInZip)
                            if (File.Exists((modpackPath + @"/Game/instances/The Last Days/.minecraft/" + fileName)) == true)
                                File.Delete((modpackPath + @"/Game/instances/The Last Days/.minecraft/" + fileName));

                        //Move all folders of the ZIP to the The Last Days instance
                        foreach (string folderName in folderNamesFoundInZip)
                            Directory.Move((modpackPath + @"/Cache/ModpackData/" + folderName), (modpackPath + @"/Game/instances/The Last Days/.minecraft/" + folderName));
                        foreach (string fileName in fileNamesFoundInZip)
                            File.Move((modpackPath + @"/Cache/ModpackData/" + fileName), (modpackPath + @"/Game/instances/The Last Days/.minecraft/" + fileName));

                        //Store the new downloaded modpack data version
                        File.WriteAllText((modpackPath + @"/Game/instances/The Last Days/.minecraft/local-current-version.txt"), modpackDownloadInfo.loadedData.version);

                        //Wait some time
                        threadTools.MakeThreadSleep(2500);
                    }

                    //Return a success response
                    return new string[] { "success" };
                }
                catch (Exception ex)
                {
                    //Return a error response
                    return new string[] { "error" };
                }

                //Finish the thread...
                return new string[] { "none" };
            };
            asyncTask.onNewProgress_RunMainThread += (callerWindow, newProgress) =>
            {
                //Inform the progress
                UpdateTaskProgressBar(newProgress);
            };
            asyncTask.onDoneTask_RunMainThread += (callerWindow, backgroundResult) =>
            {
                //Get the thread response
                string threadTaskResponse = backgroundResult[0];

                //If have a response not success, close
                if (threadTaskResponse != "success")
                {
                    CloseLauncherWithError("Houve um problema ao atualizar os dados do modpack.");
                    return;
                }

                //Do options patch
                DoOptionsPatch();
            };
            asyncTask.Execute(AsyncTaskSimplified.ExecutionMode.NewDefaultThread);
        }

        private void DoOptionsPatch()
        {
            //Start a thread to download the current version info
            AsyncTaskSimplified asyncTask = new AsyncTaskSimplified(this, new string[] { });
            asyncTask.onStartTask_RunMainThread += (callerWindow, startParams) => { };
            asyncTask.onExecuteTask_RunBackground += (callerWindow, startParams, threadTools) =>
            {
                //Wait some time
                //threadTools.MakeThreadSleep(1000);

                //Try to do the task
                try
                {
                    //Inform checking
                    currentTaskTitle = "Baixando Configurações Otimizadas";

                    //Wait some time
                    threadTools.MakeThreadSleep(2500);

                    //Download options info
                    if (true == true)
                    {
                        //Prepare the target download URL
                        string downloadUrl = @"https://marcos4503.github.io/the-last-days-launcher/Repository-Pages/optimized-options/options.txt";
                        string saveAsPath = (modpackPath + @"/Cache/options.txt");
                        //Download the current version file
                        HttpClient httpClient = new HttpClient();
                        HttpResponseMessage httpRequestResult = httpClient.GetAsync(downloadUrl).Result;
                        httpRequestResult.EnsureSuccessStatusCode();
                        Stream downloadStream = httpRequestResult.Content.ReadAsStreamAsync().Result;
                        FileStream fileStream = new FileStream(saveAsPath, FileMode.Create, FileAccess.Write, FileShare.None);
                        downloadStream.CopyTo(fileStream);
                        httpClient.Dispose();
                        fileStream.Dispose();
                        fileStream.Close();
                        downloadStream.Dispose();
                        downloadStream.Close();
                    }
                    //Wait some time
                    threadTools.MakeThreadSleep(1000);
                    //Download options to apply info
                    if (true == true)
                    {
                        //Prepare the target download URL
                        string downloadUrl = @"https://marcos4503.github.io/the-last-days-launcher/Repository-Pages/optimized-options/options-to-apply-in-clients.ini";
                        string saveAsPath = (modpackPath + @"/Cache/options-to-apply-in-clients.ini");
                        //Download the current version file
                        HttpClient httpClient = new HttpClient();
                        HttpResponseMessage httpRequestResult = httpClient.GetAsync(downloadUrl).Result;
                        httpRequestResult.EnsureSuccessStatusCode();
                        Stream downloadStream = httpRequestResult.Content.ReadAsStreamAsync().Result;
                        FileStream fileStream = new FileStream(saveAsPath, FileMode.Create, FileAccess.Write, FileShare.None);
                        downloadStream.CopyTo(fileStream);
                        httpClient.Dispose();
                        fileStream.Dispose();
                        fileStream.Close();
                        downloadStream.Dispose();
                        downloadStream.Close();
                    }

                    //Inform checking
                    currentTaskTitle = "Aplicando Configurações Otimizadas";

                    //Wait some time
                    threadTools.MakeThreadSleep(2500);

                    //Build a dictionary of desired options to apply in the user game install
                    Dictionary<string, string> optionsToApply = new Dictionary<string, string>();
                    //Fill the dictionary of desired options to apply in the user game, using the file obtained from the server
                    foreach(string line in File.ReadAllLines((modpackPath + @"/Cache/options-to-apply-in-clients.ini")))
                    {
                        //If the line contains header, ignore it
                        if (line.Contains("[   ") == true)
                            continue;

                        //If the option name of this line not exists in dictionary, add it
                        if (optionsToApply.ContainsKey(line) == false)
                            optionsToApply.Add(line, "");
                    }

                    //Get all values for all settings to be applied, from the downloaded options
                    string[] downloadedOptionsLines = File.ReadAllLines((modpackPath + @"/Cache/options.txt"));
                    //Read each line
                    foreach(string line in downloadedOptionsLines)
                    {
                        //Split this setting by the key and value
                        string[] lineSplitted = line.Split(':');
                        string key = lineSplitted[0];
                        string value = lineSplitted[1];

                        //If this key don't exists in the dictionary, skip it
                        if (optionsToApply.ContainsKey(key) == false)
                            continue;

                        //Save the value of downloaded options, for the current option to the dictionary
                        optionsToApply[key] = value;
                    }

                    //Apply all settings to be applied, to the local user game options
                    string[] localOptionsLines = File.ReadAllLines((modpackPath + @"/Game/instances/The Last Days/.minecraft/options.txt"));
                    //Read each line and apply the settings
                    for(int i = 0; i < localOptionsLines.Length; i++)
                    {
                        //Split this setting by the key and value
                        string[] lineSplitted = localOptionsLines[i].Split(':');
                        string key = lineSplitted[0];
                        string value = lineSplitted[1];

                        //If this key don't exists in the dictionary, skip it
                        if (optionsToApply.ContainsKey(key) == false)
                            continue;

                        //Change this setting to be the same setting of download options
                        localOptionsLines[i] = (key + ":" + optionsToApply[key]);
                    }
                    //Save the modified options file
                    File.WriteAllLines((modpackPath + @"/Game/instances/The Last Days/.minecraft/options.txt"), localOptionsLines);

                    //Add all options found in downloaded options, that not exists in local game options
                    List<string> localOptionsLinesList = File.ReadAllLines((modpackPath + @"/Game/instances/The Last Days/.minecraft/options.txt")).ToList();
                    //Check each key inside the options to apply
                    foreach(var item in optionsToApply)
                    {
                        //Get the key and value of this option
                        string optionKey = item.Key;
                        string optionValue = item.Value;

                        //Store if found the options in the game options
                        bool foundThisOption = false;
                        //Search the option...
                        foreach(string line in localOptionsLinesList)
                            if(line.Contains(optionKey) == true)
                            {
                                foundThisOption = true;
                                break;
                            }

                        //If found this option, continue to check next option
                        if (foundThisOption == true)
                            continue;

                        //If this option to apply have a empty value, ignore it
                        if (optionValue == "")
                            continue;

                        //If not found this option in local game options, add it to the options
                        localOptionsLinesList.Add((optionKey + ":" + optionValue));
                    }
                    //Save the modified options file
                    File.WriteAllLines((modpackPath + @"/Game/instances/The Last Days/.minecraft/options.txt"), localOptionsLinesList.ToArray());



                    //Return a success response
                    return new string[] { "success" };
                }
                catch (Exception ex)
                {
                    //Return a error response
                    return new string[] { "error" };
                }

                //Finish the thread...
                return new string[] { "none" };
            };
            asyncTask.onNewProgress_RunMainThread += (callerWindow, newProgress) =>
            {
                //Inform the progress
                UpdateTaskProgressBar(newProgress);
            };
            asyncTask.onDoneTask_RunMainThread += (callerWindow, backgroundResult) =>
            {
                //Get the thread response
                string threadTaskResponse = backgroundResult[0];

                //If have a response not success, close
                if (threadTaskResponse != "success")
                {
                    CloseLauncherWithError("Houve um problema ao atualizar as configurações otimizadas.");
                    return;
                }

                //Do cosmetic patch
                DoCosmeticPatch();
            };
            asyncTask.Execute(AsyncTaskSimplified.ExecutionMode.NewDefaultThread);
        }

        private void DoCosmeticPatch()
        {
            //Start a thread to download the current version info
            AsyncTaskSimplified asyncTask = new AsyncTaskSimplified(this, new string[] { });
            asyncTask.onStartTask_RunMainThread += (callerWindow, startParams) => { };
            asyncTask.onExecuteTask_RunBackground += (callerWindow, startParams, threadTools) =>
            {
                //Wait some time
                //threadTools.MakeThreadSleep(1000);

                //Try to do the task
                try
                {
                    //Inform checking
                    currentTaskTitle = "Verificando Cosméticos";

                    //Wait some time
                    threadTools.MakeThreadSleep(2500);

                    //Clear the skins, elytra and capes cache of the game
                    if (Directory.Exists((modpackPath + @"/Game/instances/The Last Days/.minecraft/CustomSkinLoader/caches")) == true)
                        Directory.Delete((modpackPath + @"/Game/instances/The Last Days/.minecraft/CustomSkinLoader/caches"), true);
                    if (Directory.Exists((modpackPath + @"/Game/instances/The Last Days/.minecraft/CustomSkinLoader/ProfileCache")) == true)
                        Directory.Delete((modpackPath + @"/Game/instances/The Last Days/.minecraft/CustomSkinLoader/ProfileCache"), true);
                    if (File.Exists((modpackPath + @"/Game/instances/The Last Days/.minecraft/CustomSkinLoader/CustomSkinLoader.log")) == true)
                        File.Delete((modpackPath + @"/Game/instances/The Last Days/.minecraft/CustomSkinLoader/CustomSkinLoader.log"));

                    //Return a success response
                    return new string[] { "success" };
                }
                catch (Exception ex)
                {
                    //Return a error response
                    return new string[] { "error" };
                }

                //Finish the thread...
                return new string[] { "none" };
            };
            asyncTask.onNewProgress_RunMainThread += (callerWindow, newProgress) =>
            {
                //Inform the progress
                UpdateTaskProgressBar(newProgress);
            };
            asyncTask.onDoneTask_RunMainThread += (callerWindow, backgroundResult) =>
            {
                //Get the thread response
                string threadTaskResponse = backgroundResult[0];

                //If have a response not success, close
                if (threadTaskResponse != "success")
                {
                    CloseLauncherWithError("Houve um problema ao atualizar os dados de cosméticos.");
                    return;
                }

                //Prepare account data
                PrepareAccountsData();
            };
            asyncTask.Execute(AsyncTaskSimplified.ExecutionMode.NewDefaultThread);
        }

        private void PrepareAccountsData()
        {
            //Start a thread to download the current version info
            AsyncTaskSimplified asyncTask = new AsyncTaskSimplified(this, new string[] { });
            asyncTask.onStartTask_RunMainThread += (callerWindow, startParams) => { };
            asyncTask.onExecuteTask_RunBackground += (callerWindow, startParams, threadTools) =>
            {
                //Wait some time
                //threadTools.MakeThreadSleep(1000);

                //Try to do the task
                try
                {
                    //Inform checking
                    currentTaskTitle = "Preparando Dados de Conta";

                    //Wait some time
                    threadTools.MakeThreadSleep(2500);

                    //Load the "accounts.json" of Prism Launcher
                    AccountsData accountsData = new AccountsData((modpackPath + @"/Game/accounts.json"));

                    //If format version is different from "3", cancel
                    if (accountsData.loadedData.formatVersion != 3)
                        return new string[] { "error" };

                    //If don't have accounst, or have more than one account...
                    if(accountsData.loadedData.accounts.Length == 0 || accountsData.loadedData.accounts.Length > 1)
                    {
                        //Prepare the accounts array
                        accountsData.loadedData.accounts = new Account[1];

                        //Fill the account...
                        accountsData.loadedData.accounts[0] = new Account();

                        accountsData.loadedData.accounts[0].active = true;

                        Entitlement entitlement = new Entitlement();
                        entitlement.canPlayMinecraft = true;
                        entitlement.ownsMinecraft = true;
                        accountsData.loadedData.accounts[0].entitlement = entitlement;

                        Profile profile = new Profile();
                        profile.capes = new string[0];
                        profile.id = "bc7e30859100416c8e45faa8c5e9ab50";
                        profile.name = "Player";
                        Skin skin = new Skin();
                        skin.id = "";
                        skin.url = "";
                        skin.variant = "";
                        profile.skin = skin;
                        accountsData.loadedData.accounts[0].profile = profile;

                        accountsData.loadedData.accounts[0].type = "Offline";

                        Ygg ygg = new Ygg();
                        Extra extra = new Extra();
                        extra.clientToken = "e69a929dd832410ba59a63aced159bd5";
                        extra.userName = "Player";
                        ygg.extra = extra;
                        ygg.iat = 1710712809;
                        ygg.token = "offline";
                        accountsData.loadedData.accounts[0].ygg = ygg;

                        //Save the data
                        accountsData.Save();
                    }

                    //Return a success response
                    return new string[] { "success" };
                }
                catch (Exception ex)
                {
                    //Return a error response
                    return new string[] { "error" };
                }

                //Finish the thread...
                return new string[] { "none" };
            };
            asyncTask.onNewProgress_RunMainThread += (callerWindow, newProgress) =>
            {
                //Inform the progress
                UpdateTaskProgressBar(newProgress);
            };
            asyncTask.onDoneTask_RunMainThread += (callerWindow, backgroundResult) =>
            {
                //Get the thread response
                string threadTaskResponse = backgroundResult[0];

                //If have a response not success, close
                if (threadTaskResponse != "success")
                {
                    CloseLauncherWithError("Houve um problema ao preparar os dados de conta.");
                    return;
                }

                //Finish the patching
                FinishPatching();
            };
            asyncTask.Execute(AsyncTaskSimplified.ExecutionMode.NewDefaultThread);
        }

        private void FinishPatching()
        {
            //Update information about versions
            UpdateLauncherAboutVersionsInfo();

            //Hide the task display
            taskDisplay.Visibility = Visibility.Collapsed;

            //Display the account info
            UpdateAccountDisplay();

            //Enable the edit nickname button
            editNick.Opacity = 1.0f;
            editNick.IsHitTestVisible = true;
            //Prepare the edit nickname button
            editNick.Click += (s, e) => { OpenLoginCredentialsEdit(); };

            //Prepare the play button
            playButton.Click += (s, e) =>
            {
                //If don't have a password defined, cancel and open the login credentials edit
                if (File.Exists((modpackPath + @"/Game/instances/The Last Days/.minecraft/.sl_password")) == false)
                {
                    OpenLoginCredentialsEdit();
                    return;
                }

                //Process the patch of glitch of black blocks and world fix
                ProcessThePatchOfWorldAndBlocksBlack();

                //Try to launch the game
                try
                {
                    //Create a new process of the game
                    Process newProcess = new Process();
                    newProcess.StartInfo.FileName = System.IO.Path.Combine(modpackPath, "Game", "prismlauncher.exe");
                    newProcess.StartInfo.WorkingDirectory = System.IO.Path.Combine(modpackPath, "Game");
                    newProcess.StartInfo.Arguments = "--launch \"The Last Days\"";
                    newProcess.Start();

                    //Store a reference for the process
                    currentGameProcess = newProcess;

                    //Disable play button
                    playButton.IsEnabled = false;
                    playBtnText.Text = "JOGANDO";
                    //Disable edit nick button
                    editNick.Opacity = 0.25f;
                    editNick.IsHitTestVisible = false;
                    //Change to system tray state
                    SetLauncherState(LauncherState.SystemTray);
                    //Inform that is playing
                    isPlayingGame = true;

                    //Create a thread to monitor the game process
                    AsyncTaskSimplified asyncTask = new AsyncTaskSimplified(this, new string[] { });
                    asyncTask.onExecuteTask_RunBackground += (callerWindow, startParams, threadTools) =>
                    {
                        //Create a monitor loop
                        while (true)
                        {
                            //Wait some time
                            threadTools.MakeThreadSleep(3000);

                            //If was finished the game process, break the monitor loop
                            if (currentGameProcess.HasExited == true)
                                break;
                        }

                        //Return empty response
                        return new string[] { };
                    };
                    asyncTask.onDoneTask_RunMainThread += (callerWindow, backgroundResult) =>
                    {
                        //Enable play button
                        playButton.IsEnabled = true;
                        playBtnText.Text = "JOGAR";
                        //Enable edit nick button
                        editNick.Opacity = 1.0f;
                        editNick.IsHitTestVisible = true;
                        //Change to normal state
                        SetLauncherState(LauncherState.Normal);
                        //Inform that is not playing
                        isPlayingGame = false;

                        //Clear game process reference
                        currentGameProcess = null;
                    };
                    asyncTask.Execute(AsyncTaskSimplified.ExecutionMode.NewDefaultThread);
                }
                catch (Exception ex) { MessageBox.Show(("Não foi possível iniciar o The Last Days!\n\n" + ex.StackTrace + "\n\n" + ex.Message + "\n\n- Entre em contato pelo servidor do Discord."), "Erro"); }
            };

            //Enable the play button
            playButton.IsEnabled = true;

            //Inform that can close the window
            canCloseWindow = true;
        }

        //Auxiliar methods

        private void UpdateThePatchEnabledWarning()
        {
            //Enable or disable the warning if have patches enabled
            if (preferences.loadedData.enableBlackWorldAndBlocksPatch == true)
                patchWarnIcon.Visibility = Visibility.Visible;
            if (preferences.loadedData.enableBlackWorldAndBlocksPatch == false)
                patchWarnIcon.Visibility = Visibility.Collapsed;
        }

        private void SavePreferences()
        {
            //Store the preferences
            preferences.loadedData.enableBlackWorldAndBlocksPatch = ((bool) pref_patch1.IsChecked);

            //Save the preferences
            preferences.Save();

            //Update the patch enabled warning
            UpdateThePatchEnabledWarning();

            //Inform that was saved
            MessageBox.Show("As Configurações foram salvas com sucesso!", "Pronto", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void OpenLoginCredentialsEdit()
        {
            //Enable the interaction blocker
            interactionBlocker.Visibility = Visibility.Visible;

            //Open the window of Nickname change
            WindowNickChange nickChange = new WindowNickChange(modpackPath);
            nickChange.Closed += (s, e) =>
            {
                interactionBlocker.Visibility = Visibility.Collapsed;
                UpdateAccountDisplay();
            };
            nickChange.Owner = this;
            nickChange.Show();
        }

        private void ChangeLauncherPage(LauncherPage page)
        {
            //Disable all buttons
            goHome.Background = new SolidColorBrush(Color.FromArgb(255, 253, 253, 253));
            goSkin.Background = new SolidColorBrush(Color.FromArgb(255, 253, 253, 253));
            goDocs.Background = new SolidColorBrush(Color.FromArgb(255, 253, 253, 253));
            goPrefs.Background = new SolidColorBrush(Color.FromArgb(255, 253, 253, 253));
            goAbout.Background = new SolidColorBrush(Color.FromArgb(255, 253, 253, 253));

            //Disable all pages
            pageHome.Visibility = Visibility.Collapsed;
            pageSkins.Visibility = Visibility.Collapsed;
            pageDocs.Visibility = Visibility.Collapsed;
            pagePrefs.Visibility = Visibility.Collapsed;
            pageAbout.Visibility = Visibility.Collapsed;

            //If is "Home"
            if(page == LauncherPage.Home)
            {
                goHome.Background = new SolidColorBrush(Color.FromArgb(255, 204, 251, 203));
                pageHome.Visibility = Visibility.Visible;
                pageTitle.Text = "Início";
            }

            //If is "Upload Skin"
            if (page == LauncherPage.UploadSkin)
            {
                goSkin.Background = new SolidColorBrush(Color.FromArgb(255, 204, 251, 203));
                pageSkins.Visibility = Visibility.Visible;
                pageTitle.Text = "Enviar Skin";
            }

            //If is "Documentation"
            if (page == LauncherPage.Documentation)
            {
                goDocs.Background = new SolidColorBrush(Color.FromArgb(255, 204, 251, 203));
                pageDocs.Visibility = Visibility.Visible;
                pageTitle.Text = "Documentação";
            }

            //If is "Preferences"
            if (page == LauncherPage.Preferences)
            {
                goPrefs.Background = new SolidColorBrush(Color.FromArgb(255, 204, 251, 203));
                pagePrefs.Visibility = Visibility.Visible;
                pageTitle.Text = "Configurações";
            }

            //If is "About"
            if (page == LauncherPage.About)
            {
                goAbout.Background = new SolidColorBrush(Color.FromArgb(255, 204, 251, 203));
                pageAbout.Visibility = Visibility.Visible;
                pageTitle.Text = "Sobre";
            }

            //Inform the current page
            currentPage = page;
        }

        private void UpdateLauncherAboutVersionsInfo()
        {
            //Show the updater version
            aboutUpdaterVers.Text = "Não Encontrado";
            if (File.Exists((modpackPath + @"/updater-path.tld")) == true)
            {
                //Get the updater path
                string updaterPath = File.ReadAllText((modpackPath + @"/updater-path.tld"));

                //If the updater is found
                if(File.Exists(updaterPath) == true)
                {
                    //Get updater windows version
                    string rawVersion = FileVersionInfo.GetVersionInfo(updaterPath).FileVersion;

                    //Show the fixed version
                    string[] splittedVersion = rawVersion.Split(".");
                    aboutUpdaterVers.Text = (splittedVersion[0] + "." + splittedVersion[1] + "." + splittedVersion[2]);
                }
            }

            //Show the launcher version
            aboutLauncherVers.Text = GetLauncherVersion();

            //Show the java version
            aboutJavaVers.Text = "Não Instalado Ainda";
            if (File.Exists((modpackPath + @"/Java/local-current-version.txt")) == true)
                aboutJavaVers.Text = File.ReadAllText((modpackPath + @"/Java/local-current-version.txt"));

            //Show game data version
            aboutGameDataVers.Text = "Não Instalado Ainda";
            if (File.Exists((modpackPath + @"/Game/local-current-version.txt")) == true)
                aboutGameDataVers.Text = File.ReadAllText((modpackPath + @"/Game/local-current-version.txt"));

            //Show modpack data version
            aboutModpackVers.Text = "Não Instalado Ainda";
            if (File.Exists((modpackPath + @"/Game/instances/The Last Days/.minecraft/local-current-version.txt")) == true)
                aboutModpackVers.Text = File.ReadAllText((modpackPath + @"/Game/instances/The Last Days/.minecraft/local-current-version.txt"));
        }

        private string GetLauncherVersion()
        {
            //Prepare te storage
            string version = "";

            //Get the version
            string[] versionNumbers = Assembly.GetExecutingAssembly().GetName().Version.ToString().Split('.');
            version = (versionNumbers[0] + "." + versionNumbers[1] + "." + versionNumbers[2]);

            //Return the version
            return version;
        }
    
        private void UpdateTaskProgressBar(string taskProgressbarData)
        {
            //Split the data
            string[] dataSplitted = taskProgressbarData.Split("-");

            //Convert data for float
            float value = float.Parse(dataSplitted[0]);
            float maxValue = float.Parse(dataSplitted[1]);

            //If the value and maxvalue is zero, inform indeterminate
            if (value == 0.0f && maxValue == 0.0f)
            {
                taskProgress.Value = 0.0d;
                taskProgress.Maximum = 100.0d;
                taskProgress.IsIndeterminate = true;
            }

            //If have a progress, render it
            if (value != 0.0f || maxValue != 0.0f)
            {
                taskProgress.Value = value;
                taskProgress.Maximum = maxValue;
                taskProgress.IsIndeterminate = false;
            }

        }

        private void CloseLauncherWithError(string errorMessage)
        {
            //Show error
            MessageBox.Show(errorMessage, "Erro", MessageBoxButton.OK, MessageBoxImage.Error);
            //Inform that can close
            canCloseWindow = true;
            //Close the application
            System.Windows.Application.Current.Shutdown();
        }
    
        private void UpdateAccountDisplay()
        {
            //Load the "accounts.json" of Prism Launcher
            AccountsData accountsData = new AccountsData((modpackPath + @"/Game/accounts.json"));

            //Display the account nickname
            profileNick.Text = accountsData.loadedData.accounts[0].profile.name;
        }
    
        private void SetLauncherState(LauncherState desiredState)
        {
            //If don't have a system tray icon, create it
            if(launcherTrayIcon == null)
            {
                launcherTrayIcon = new System.Windows.Forms.NotifyIcon();
                launcherTrayIcon.Visible = true;
                launcherTrayIcon.Text = "The Last Days Launcher";
                launcherTrayIcon.Icon = new System.Drawing.Icon(@"Resources/system-tray.ico");
                launcherTrayIcon.MouseClick += (s, e) => { SetLauncherState(LauncherState.Normal); };
            }

            //If is desired normal state..
            if(desiredState == LauncherState.Normal)
            {
                //Enable this window
                this.Visibility = Visibility.Visible;

                //Disable the system tray
                launcherTrayIcon.Visible = false;
            }

            //If is desired system tray state...
            if(desiredState == LauncherState.SystemTray)
            {
                //Hide this window
                this.Visibility = Visibility.Collapsed;

                //Enable the system tray
                launcherTrayIcon.Visible = true;
            }
        }
    
        private void ProcessThePatchOfWorldAndBlocksBlack()
        {
            //If the patch is not enabled, remove the patch, if is installed
            if (preferences.loadedData.enableBlackWorldAndBlocksPatch == false)
            {
                if (File.Exists((modpackPath + @"/Game/instances/The Last Days/.minecraft/mods/ADDED - ImmediatelyFast 1.2.21.jar")) == true)
                    File.Delete((modpackPath + @"/Game/instances/The Last Days/.minecraft/mods/ADDED - ImmediatelyFast 1.2.21.jar"));

                if (File.Exists((modpackPath + @"/Game/instances/The Last Days/.minecraft/mods/ADDED - ModernFix 5.18.6.jar")) == true)
                    File.Delete((modpackPath + @"/Game/instances/The Last Days/.minecraft/mods/ADDED - ModernFix 5.18.6.jar"));
            }

            //If the patch is enabled, install the patch, if is not installed
            if (preferences.loadedData.enableBlackWorldAndBlocksPatch == true)
            {
                if (File.Exists((modpackPath + @"/Game/instances/The Last Days/.minecraft/mods/ADDED - ImmediatelyFast 1.2.21.jar")) == false)
                    File.Copy((modpackPath + @"/Game/instances/The Last Days/.minecraft/mod_for_patch/ADDED - ImmediatelyFast 1.2.21.jar"),
                              (modpackPath + @"/Game/instances/The Last Days/.minecraft/mods/ADDED - ImmediatelyFast 1.2.21.jar"));

                if (File.Exists((modpackPath + @"/Game/instances/The Last Days/.minecraft/mods/ADDED - ModernFix 5.18.6.jar")) == false)
                    File.Copy((modpackPath + @"/Game/instances/The Last Days/.minecraft/mod_for_patch/ADDED - ModernFix 5.18.6.jar"),
                              (modpackPath + @"/Game/instances/The Last Days/.minecraft/mods/ADDED - ModernFix 5.18.6.jar"));
            }
        }
    }
}