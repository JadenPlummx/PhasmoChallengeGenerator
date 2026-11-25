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

        // Stores how difficult each action is to complete (1-10).
        // The ratings match the actions in actionList by their position.
        int[] actionDifficultyList = {
            5, 4, 7, 3, 6,
            5, 4, 6, 5, 7,
            4, 6, 5, 3, 2
        };

        // Stores how much each consequence affects the investigation (1-10).
        // The ratings match the consequences in consequenceList by their position.
        int[] consequenceImpactList = {
            4, 3, 5, 7, 8,
            5, 6, 4, 6, 3,
            7, 4, 2, 2, 2
        };

        // Used to randomly select actions and consequences.
        Random randomInstance = new Random();

        // This updates the timers every second.
        private DispatcherTimer ticker = new DispatcherTimer();

        // Stores the challenges that are currently active.
        List<Rules> activeRules = new List<Rules>();

        // I spent 40 minutes trying to figure out why the completed challanges weren't showing up on the screen. I forgot to add this variable to keep track of how many challenges have been completed. :(
        private int completedRuleCount = 0;

        // This Keeps track of which challenge mode is currently selected. 
        bool severityModeEnabled = false;

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
            UpdateModeButtons();
        }

        private Rules CreateRandomRule(int timeInSeconds)
        {
            int randomAction = randomInstance.Next(actionList.Length);
            int randomConsequence = randomInstance.Next(consequenceList.Length);

            // Creates a severity challenge if Severity Mode is selected.
            if (severityModeEnabled)
            {
                return new SeverityRules(
                    timeInSeconds,
                    actionList[randomAction],
                    consequenceList[randomConsequence],
                    actionDifficultyList[randomAction],
                    consequenceImpactList[randomConsequence]);
            }

            // Otherwise, creates a regular challenge.
            return new StandardRules(
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
                    completedRuleCount++;
                
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
        /// Switches the challenges back to Standard Mode.
        /// </summary>
        private void StandardModeButton_Click(object sender, RoutedEventArgs e)
        {
            // Prevents resetting the challenges if Standard Mode is already selected.
            if (!severityModeEnabled)
            {
                return;
            }

            severityModeEnabled = false;

            activeRules[0] = CreateRandomRule(300);
            activeRules[1] = CreateRandomRule(600);
            activeRules[2] = CreateRandomRule(900);

            DisplayRules();
            UpdateModeButtons();
        }


        /// <summary>
        /// This Updates the appearance of the mode buttons so you can tell whats selected.
        /// </summary>
        private void UpdateModeButtons()
        {
            if (severityModeEnabled)
            {
                severityModeButton.Background = Brushes.DodgerBlue;
                standardModeButton.Background = Brushes.DimGray;
            }
            else
            {
                standardModeButton.Background = Brushes.DodgerBlue;
                severityModeButton.Background = Brushes.DimGray;
            }

            standardModeButton.Foreground = Brushes.White;
            severityModeButton.Foreground = Brushes.White;
        }


        /// <summary>
        /// Switches the challenges to Severity Mode.
        /// </summary>
        private void SeverityModeButton_Click(object sender, RoutedEventArgs e)
        {
            // Prevents resetting the challenges if Severity Mode is already selected.
            if (severityModeEnabled)
            {
                return;
            }

            severityModeEnabled = true;

            activeRules[0] = CreateRandomRule(300);
            activeRules[1] = CreateRandomRule(600);
            activeRules[2] = CreateRandomRule(900);

            DisplayRules();
            UpdateModeButtons();
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

            // Changes the displayed icons and information based on the selected mode.
            if (severityModeEnabled)
            {
                // Hide the regular ghost icons.
                standardIconOne.Visibility = Visibility.Collapsed;
                standardIconTwo.Visibility = Visibility.Collapsed;
                standardIconThree.Visibility = Visibility.Collapsed;

                // Show the severity information.
                rankImageOne.Visibility = Visibility.Visible;
                rankImageTwo.Visibility = Visibility.Visible;
                rankImageThree.Visibility = Visibility.Visible;

                severityDisplayOne.Visibility = Visibility.Visible;
                severityDisplayTwo.Visibility = Visibility.Visible;
                severityDisplayThree.Visibility = Visibility.Visible;

                // Updates the rank information for each challenge.
                DisplaySeverity((SeverityRules)activeRules[0], rankImageOne, rankNameOne, severityScoreOne);
                DisplaySeverity((SeverityRules)activeRules[1], rankImageTwo, rankNameTwo, severityScoreTwo);
                DisplaySeverity((SeverityRules)activeRules[2], rankImageThree, rankNameThree, severityScoreThree);
            }
            else
            {
                // Show the regular ghost icons.
                standardIconOne.Visibility = Visibility.Visible;
                standardIconTwo.Visibility = Visibility.Visible;
                standardIconThree.Visibility = Visibility.Visible;

                // Hide the severity information.
                rankImageOne.Visibility = Visibility.Collapsed;
                rankImageTwo.Visibility = Visibility.Collapsed;
                rankImageThree.Visibility = Visibility.Collapsed;

                severityDisplayOne.Visibility = Visibility.Collapsed;
                severityDisplayTwo.Visibility = Visibility.Collapsed;
                severityDisplayThree.Visibility = Visibility.Collapsed;
            }
            
            UpdateRuleCounts();
        }

        
        // Updates the number of active and completed challenges shown on screen.
        private void UpdateRuleCounts()
        {
            activeRuleCountText.Text = $"Active Challenges: {activeRules.Count}";
            completedRuleCountText.Text = $"Completed Challenges: {completedRuleCount}";
        }

        // Displays the appropriate hunter rank and image for a severity challenge.
        private void DisplaySeverity(SeverityRules rule, Image rankImage, TextBlock rankName, TextBlock severityScore)
        {
            int severity = rule.SeverityLevel;

            if (severity <= 2)
            {
                rankName.Text = "Rookie Hunter";
                rankImage.Source = new BitmapImage(new Uri("pack://application:,,,/Images/Level1.jpg"));
            }
            else if (severity <= 4)
            {
                rankName.Text = "Amateur Hunter";
                rankImage.Source = new BitmapImage(new Uri("pack://application:,,,/Images/Level2.jpg"));
            }
            else if (severity <= 6)
            {
                rankName.Text = "Professional Hunter";
                rankImage.Source = new BitmapImage(new Uri("pack://application:,,,/Images/Level3.jpg"));
            }
            else if (severity <= 8)
            {
                rankName.Text = "Expert Hunter";
                rankImage.Source = new BitmapImage(new Uri("pack://application:,,,/Images/Level4.jpg"));
            }
            else
            {
                rankName.Text = "Master Hunter";
                rankImage.Source = new BitmapImage(new Uri("pack://application:,,,/Images/Level5.jpg"));
            }

            // Displays the numerical severity level.
            severityScore.Text = $"Severity: {severity}/10";
        }
    }
}
