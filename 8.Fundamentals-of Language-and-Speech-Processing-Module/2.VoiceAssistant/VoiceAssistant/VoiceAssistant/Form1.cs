using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Speech.Recognition;
using System.Speech.Synthesis;
using MediaPlayer;

namespace VoiceAssistant
{
    public partial class Form1 : Form
    {
        SpeechRecognitionEngine _recognizer = new SpeechRecognitionEngine();
        SpeechSynthesizer Monica = new SpeechSynthesizer();
        DateTime now = DateTime.Now;
        String userName = Environment.UserName;
        Random rnd = new Random();
        String greetChoice;
        MediaPlayer.MediaPlayer mediaPlayer = new MediaPlayer.MediaPlayer();
        public Form1()
        {
            InitializeComponent();
            _recognizer.SetInputToDefaultAudioDevice();
            _recognizer.LoadGrammar(new Grammar(new GrammarBuilder(new Choices(File.ReadAllLines(@"Commands.txt")))));
            _recognizer.SpeechRecognized += new EventHandler<SpeechRecognizedEventArgs>(_recognizer_SpeechRecognized);
            _recognizer.RecognizeAsync(RecognizeMode.Multiple);
        }

        private void _recognizer_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
        {
            if (e.Result.Text != "" && Monica.State != SynthesizerState.Speaking && Monica.State != SynthesizerState.Paused)
            {
                string time = now.GetDateTimeFormats('t')[0];
                int ranNum;
                string speech = e.Result.Text;
                switch (speech)
                {
                    //BASIC COMMANDS
                    case "Hello":
                    case "Hello Monica":
                        if (now.Hour >= 5 && now.Hour < 12)
                        { Monica.Speak("Good morning " + userName + ", nice to see you again"); }
                        if (now.Hour >= 12 && now.Hour < 18)
                        { Monica.Speak("Good afternoon " + userName + ", nice to see you again"); }
                        if (now.Hour >= 18 && now.Hour < 24)
                        { Monica.Speak("Good evening " + userName + ", nice to see you again"); }
                        if (now.Hour < 5)
                        { Monica.Speak("It's getting late " + userName); }
                        break;
                    case "How are you":
                        Monica.Speak("I'm fine, thanks for asking");
                        break;
                    case "Goodbye":
                    case "Close":
                    case "Exit":
                        Monica.Speak("Goodbye");
                        Application.Exit();
                        break;
                    case "Monica":
                        ranNum = rnd.Next(1, 3);
                        if (ranNum == 1) { greetChoice = ""; Monica.Speak("Yes sir"); }
                        else if (ranNum == 2) { greetChoice = ""; Monica.Speak("Yes?"); }
                        break;
                    case "Thank you":
                        Monica.Speak("No thanks");
                        break;

                    //CONDITIONAL COMMANDS
                    case "What time is it":
                        Monica.Speak(time);
                        break;
                    case "What day is it":
                        Monica.Speak(DateTime.Today.ToString("dddd"));
                        break;
                    case "Whats the date":
                    case "Whats todays date":
                        Monica.Speak(DateTime.Today.ToString("dd-MM-yyyy"));
                        break;

                    //OTHER COMMANDS                
                    case "Out of the way":
                        if (WindowState == FormWindowState.Normal)
                        {
                            WindowState = FormWindowState.Minimized;
                            Monica.Speak("My apologies");
                        }
                        break;
                    case "Come back":
                        if (WindowState == FormWindowState.Minimized)
                        {
                            Monica.Speak("Alright?");
                            WindowState = FormWindowState.Normal;
                        }
                        break;
                    case "Show commands":
                        string[] commands = File.ReadAllLines("Commands.txt");
                        Monica.Speak("Here they are");
                        lstCommands.Items.Clear();
                        lstCommands.SelectionMode = SelectionMode.None;
                        lstCommands.Visible = true;
                        foreach (string command in commands)
                        {
                            lstCommands.Items.Add(command);
                        }
                        break;
                    case "Hide commands":
                        lstCommands.Visible = false;
                        break;
                    case "Read commands":
                        Monica.Speak(File.ReadAllText("Commands.txt"));
                        break;
                    case "Open browser":
                        Monica.Speak("I'm opening your browser right now");
                        Process.Start("IExplore.exe", "http://www.google.com");
                        break;
                    case "Open Email":
                        Monica.Speak("Opening email page");
                        Monica.SpeakAsyncCancelAll();
                        _recognizer.RecognizeAsyncStop();
                        _recognizer.RecognizeAsyncCancel();
                        new Form2().Show();
                        this.Close();
                        break;
                    case "Play music":
                        mediaPlayer.FileName = @"music.mp3";
                        mediaPlayer.Play();
                        break;
                    case "Stop music":
                        mediaPlayer.Stop();
                        break;
                }
            }

        }
    }
}