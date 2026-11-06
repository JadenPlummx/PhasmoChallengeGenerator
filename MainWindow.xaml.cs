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
            "If you use the Spirit Box to communicate with the ghost...",
            "If you try to get a response from the Ghost Writing Book...",
            "If you take a photo of the ghost...",
            "If you use the EMF Reader to search for activity...",
            "If you find the ghost room without using a thermometer...",
            "If you use the DOTS Projector to look for ghost movement...",
            "If you try to identify the ghost using fingerprints...",
            "If you investigate using only your flashlight...",
            "If you use a Crucifix to protect yourself from a hunt...",
            "If you search for evidence without using the main lights...",
            "If you try to get the ghost to interact with an object...",
            "If you investigate the ghost room without speaking...",
            "If you complete an optional objective...",
            "If you walk backwards for the next 30 seconds...",
            "If you pretend you're a professional ghost hunter for one minute..."
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
            "You cannot use the thermometer until the next challenge.",
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
        private DispatcherTimer ticker = new DispatcherTimer();

        // Stores the challenges that are currently active.
        List<Rules> activeRules = new List<Rules>();
        
        public MainWindow()
        {
            InitializeComponent();
        }
         private void WindowLoaded(object sender, RoutedEventArgs e)
        {

        activeRules.Add(CreateRandomRule(300));
        activeRules.Add(CreateRandomRule(600));
        activeRules.Add(CreateRandomRule(900));

        DisplayRules();
        
         // Timer ticks every second
            ticker.Interval = TimeSpan.FromSeconds(1);

        // Connected the timer along with the second pass method
            ticker.Tick += SecondPass;

        // Start the timer (hopefully the ghosts don't attack you).
            ticker.Start();
        }

        private Rules CreateRandomRule(int timeInSeconds)
        {
            int randomAction = randomInstance.Next(actionList.Length);
            int randomConsequence = randomInstance.Next(consequenceList.Length);

            return new Rules(
            timeInSeconds,
            actionList[randomAction],
            consequenceList[randomConsequence]);
        }

        /// <summary>
        /// Updates all active challenges every second.
        /// </summary>
        private void SecondPass(object sender, EventArgs e)
        {
            // Decreases the remaining time for each active challenge.
            for (int i = 0; i < activeRules.Count; i++)
            {
                activeRules[i].TimerTick();

                // Checks whether the challenge has expired.
                if (activeRules[i].IsExpired())
                {
                    if (i == 0)
                    {
                        activeRules[i] = CreateRandomRule(300);
                    }
                    else if (i == 1)
                    {
                        activeRules[i] = CreateRandomRule(600);
                    }
                    else if (i == 2)
                    {
                        activeRules[i] = CreateRandomRule(900);
                    }
                }
            }

            // Updates the challenge information shown on screen.
            DisplayRules();
        }

        /// <summary>
        /// Pauses or resumes all challenge timers.
        /// </summary>
        private void PauseButton_Click(object sender, RoutedEventArgs e)
        {
            if (ticker.IsEnabled)
            {
                ticker.Stop();
                pauseButton.Content = "Resume All Timers";
            }
            else
            {
                ticker.Start();
                pauseButton.Content = "Pause All Timers";
            }
        }

         /// <summary>
         /// Generates a new challenge for Rule 1.
         /// </summary>
         private void RerollOne_Click(object sender, RoutedEventArgs e)
         {
             activeRules[0] = CreateRandomRule(300);
             DisplayRules();
         }

 /// <summary>
 /// Generates a new challenge for Rule 2.
 /// </summary>
 private void RerollTwo_Click(object sender, RoutedEventArgs e)
 {
     activeRules[1] = CreateRandomRule(600);
     DisplayRules();
 }

 /// <summary>
 /// Generates a new challenge for Rule 3.
 /// </summary>
 private void RerollThree_Click(object sender, RoutedEventArgs e)
 {
     activeRules[2] = CreateRandomRule(900);
     DisplayRules();
 }

         // Displays the active challenges on the screen.
        private void DisplayRules()
        {
            timerOne.Text = activeRules[0].Time;
            actionOne.Text = activeRules[0].Action;
            consequenceOne.Text = activeRules[0].Consequence;

            timerTwo.Text = activeRules[1].Time;
            actionTwo.Text = activeRules[1].Action;
            consequenceTwo.Text = activeRules[1].Consequence;

            timerThree.Text = activeRules[2].Time;
            actionThree.Text = activeRules[2].Action;
            consequenceThree.Text = activeRules[2].Consequence;
        }
    }
}
