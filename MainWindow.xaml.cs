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

        };

        // Stores the possible consequences.
        string[] consequenceList = {

        };

        // Used to randomly select actions and consequences.
        Random randomInstance = new Random();

        public MainWindow()
        {
            InitializeComponent();
        }
    }
