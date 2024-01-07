using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Speech.Recognition;
using System.Speech.Synthesis;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VoiceAssistant
{
    public partial class Form2 : Form
    {
        SpeechRecognitionEngine _recognizer = new SpeechRecognitionEngine();
        SpeechSynthesizer Monica = new SpeechSynthesizer();
        public Form2()
        {
            InitializeComponent();
            _recognizer.SetInputToDefaultAudioDevice();
            _recognizer.LoadGrammar(new Grammar(new GrammarBuilder(new Choices(File.ReadAllLines(@"EmailCommands.txt")))));
            _recognizer.SpeechRecognized += new EventHandler<SpeechRecognizedEventArgs>(_recognizer_SpeechRecognized);
            _recognizer.RecognizeAsync(RecognizeMode.Multiple);
        }

        private static string _currentText = string.Empty;
        private void _recognizer_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
        {
            if (e.Result.Text != "" && Monica.State != SynthesizerState.Speaking && Monica.State != SynthesizerState.Paused)
            {
                string speech = e.Result.Text;
                switch (speech)
                {
                    case "Goodbye":
                    case "Close":
                    case "Exit":
                        Monica.Speak("Closing email page");
                        Monica.SpeakAsyncCancelAll();
                        _recognizer.RecognizeAsyncStop();
                        _recognizer.RecognizeAsyncCancel();
                        new Form1().Show();
                        this.Close();
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
                    case "Receiver":
                        textBox1.Focus();
                        _currentText = "Receiver";
                        break;
                    case "Subject":
                        textBox2.Focus();
                        _currentText = "Subject";
                        break;
                    case "Text":
                        richTextBox1.Focus();
                        _currentText = "Text";
                        break;
                    case "Send":
                        if (string.IsNullOrEmpty(textBox1.Text))
                        {
                            Monica.Speak("Please enter receiver");
                        }
                        else if (string.IsNullOrEmpty(textBox2.Text))
                        {
                            Monica.Speak("Please enter subject");
                        }
                        else if (string.IsNullOrEmpty(richTextBox1.Text))
                        {
                            Monica.Speak("Please enter text");
                        }
                        else
                        {
                            textBox1.Clear();
                            textBox2.Clear();
                            richTextBox1.Clear();
                            Monica.Speak("Email sent successfully.");
                        }
                        break;
                    default:
                        if (_currentText == "Receiver")
                        {
                            textBox1.Text = speech;
                        }
                        else if (_currentText == "Subject")
                        {
                            textBox2.Text = speech;
                        }
                        else if (_currentText == "Text")
                        {
                            richTextBox1.Text = speech;
                        }

                        _currentText = "";
                        break;
                }
            }

        }
    }
}
