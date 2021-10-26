using GalaxyLib.AppCommands;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace GalaxyWindow
{
    /// <summary>
    /// Interaction logic for KeyConfigWindow.xaml
    /// </summary>
    public partial class KeyConfigWindow : Window
    {
        private KeyMap _map;
        private DataTable _table;

        public KeyConfigWindow(KeyMap map)
        {
            _map = map;
            DataTable dt = map;
            _table = dt;

            InitializeComponent();

            DataGrid.ItemsSource = dt.DefaultView;
        }

        private void KeyConfigWindow_OnClosing(object sender, CancelEventArgs e)
        {
            var dict = ToDictionary(_table);

            if (!_map.ValidateGestures(dict, GetPossibleKeys(), out var firstInvalid))
            {
                MessageBox.Show(this, $"Gestures are bad. Not gonna save. For Example: {firstInvalid}");
                return;
            }

            _map.SaveGestures(dict);
        }

        private IDictionary<string, string> ToDictionary(DataTable dt)
        {
            IDictionary<string, string> dict = new Dictionary<string, string>();

            for (var i = 0; i < dt.Rows.Count; i++)
            {
                var key = dt.Rows[i]["Feature"].ToString();
                var value = dt.Rows[i]["Gesture"].ToString();

                if (key == null)
                    continue;

                dict.Add(key, value);
            }

            return dict;
        }

        private List<string> GetPossibleKeys()
        {
            return Enum.GetValues(typeof(Key)).Cast<Key>().Select(x => x.ToString()).ToList();
        }
    }
}
