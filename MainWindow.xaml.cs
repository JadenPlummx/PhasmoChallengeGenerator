// ============================================================================
// Project Name: PhasmoChallengeGenerator
// Description: Handles the main window and functionality of my Phasmophobia challenge generator.
// Author: Jaden Plummer
// Date: November 4, 2026
// ============================================================================

using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System;
using System.Collections.Generic;
using System.Windows.Threading;

namespace PhasmoChallengeGenerator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        // Stores the possible ghost hunting actions.
        string[] actionList = {
            "Use the Spirit Box to communicate with the ghost.",
            "Try to get a response from the Ghost Writing Book.",
            "Take a photo of the ghost.",
            "Use the EMF Reader to search for activity.",
            "Find the ghost room without using a thermometer.",
            "Use the DOTS Projector to look for ghost movement.",
            "Try to identify the ghost using fingerprints.",
            "Spend time investigating with only your flashlight.",
            "Use a Crucifix to protect yourself from a hunt.",
            "Search for evidence without using the main lights.",
            "Try to get the ghost to interact with an object.",
            "Investigate the ghost room without speaking.",
            "Complete an objective on the optional objectives list.",
            "Walk backwards for the next 30 seconds.",
            "Pretend you're a professional ghost hunter for one minute."
        };

        // Stores the possible consequences.
        string[] consequenceList = {
            "You cannot use your flashlight for 60 seconds.",
            "You must leave the ghost room for 30 seconds.",
            "You cannot use the Spirit Box for the next 2 minutes.",
            "You must investigate alone for 60 seconds.",
            "You cannot use sprint until the next challenge.",
            "You must leave one piece of equipment in the truck.",
            "You cannot turn on any lights for 60 seconds.",
            "You must put away your EMF Reader for 2 minutes.",
            "You cannot use the thermometer for the next challenge.",
            "You must stay inside the truck for 30 seconds.",
            "You must complete the next challenge without sprinting.",
            "You cannot use your head-mounted camera for 60 seconds.",
            "You must speak in a dramatic whisper for 1 minute.",
            "You must announce every piece of evidence like a news reporter.",
            "You must apologize to the ghost before your next investigation."
        };

        // Used to randomly select actions and consequences.
        Random randomInstance = new Random();

        // This updates the timers every second.
        private DispatcherTimer ticker = new DispatcherTimer(
        
        public MainWindow()
        {
            InitializeComponent();
        }
    }
