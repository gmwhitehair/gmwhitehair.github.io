/* UserInterface.cs
 * Author: Gabriel Whitehair
 */
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Ksu.Cis300.TextAnalysis
{
    /// <summary>
    /// UserInterface class which handles clicks in the user interface.
    /// </summary>
    public partial class UserInterface : Form
    {
        /// <summary>
        /// Index of the File Name Column.
        /// </summary>
        private const int _fileNameColumn = 0;
        /// <summary>
        /// Index of the Difference Column.
        /// </summary>
        private const int _differenceColumn = 2;
        /// <summary>
        /// Index of the Word Column.
        /// </summary>
        private const int _wordColumn = 0;
        /// <summary>
        /// Difference format string.
        /// </summary>
        private const string _differenceFormat = "N5";
        /// <summary>
        /// Frequency format string.
        /// </summary>
        private const string _frequencyFormat = "N5";
        /// <summary>
        /// Vocabulary width int for max width.
        /// </summary>
        private const int _vocabularyWidth = 10;
        /// <summary>
        /// Headings for uxResults.
        /// </summary>
        private string[] _allFilesHeadings = { "File Name", "Vocabulary", "Difference" };
        /// <summary>
        /// Headings for uxWordFrequencies.
        /// </summary>
        private string[] _selectedHeadings = { "Word", "Frequency" };
        /// <summary>
        /// Headings suffixes for after the heading to indicate sort.
        /// </summary>
        private string[] _headingSuffixes = { "   ", "  ˆ", "  ˇ" };
        /// <summary>
        /// Frequency table that will be returned from the analyzer class.
        /// </summary>
        private Dictionary<string, Dictionary<string, float>> _frequencyTables;
        /// <summary>
        /// ListViewColumn sorter for the results list view.
        /// </summary>
        private ListViewColumnSorter _resultsSorter = new ListViewColumnSorter();
        /// <summary>
        /// ListViewColumnSorter for the frequency list view.
        /// </summary>
        private ListViewColumnSorter _frequencySorter = new ListViewColumnSorter();
        /// <summary>
        /// Private Method 1: SortColumn. Sorts the column based on sortorder, selected column, and listview. Updates headings appropriately. 
        /// </summary>
        /// <param name="listview">uxResults or uxWordFrequencies listview.</param>
        /// <param name="headings">Headings for the particular list view.</param>
        /// <param name="index">Which column we are selecting.</param>
        /// <param name="sortorder">None, ascending, or desceding. Uses to appropriately update the suffixes.</param>
        private void SortColumn(ListView listview, string[] headings, int index, SortOrder sortorder)
        {
            ListViewColumnSorter lvcs = (ListViewColumnSorter) listview.ListViewItemSorter;
            lvcs.SortColumn = index;
            lvcs.Order = sortorder;
            if (sortorder != SortOrder.None)
            {
                listview.Sort();
            }
            for (int i = 0; i < listview.Columns.Count; i++)
            {
                if (i == index)
                {
                    listview.Columns[i].Text = headings[i] + _headingSuffixes[(int)sortorder];
                }
                else
                {
                    listview.Columns[i].Text = headings[i] + _headingSuffixes[(int)SortOrder.None];
                }
            }
        }
        /// <summary>
        /// Constructor for the class. Sets the ListViewItemSorter's appropriately and sorts the columns by column 0. 
        /// </summary>
        public UserInterface()
        {
            InitializeComponent();
            uxResults.ListViewItemSorter = _resultsSorter;
            uxWordFrequencies.ListViewItemSorter = _frequencySorter;
            SortColumn(uxResults, _allFilesHeadings, _fileNameColumn, SortOrder.None);
            SortColumn(uxWordFrequencies, _selectedHeadings, _wordColumn, SortOrder.None);
        }
        /// <summary>
        /// Event Handler 1: Open_Click handles the click to open a folder. It reads in the folder and gets the frequency table from the analyzer class. Then it sorts by column 0 in both listviews.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uxOpen_Click(object sender, EventArgs e)
        {
            try
            {
                if (uxFolderBrowser.ShowDialog() == DialogResult.OK)
                {
                    string path = uxFolderBrowser.SelectedPath;
                    _frequencyTables = Analyzer.GetFrequencyTables(path);
                    uxResults.Items.Clear();
                    AddToListView();
                    SortColumn(uxResults, _allFilesHeadings, _fileNameColumn, SortOrder.Ascending);
                    uxWordFrequencies.Items.Clear();
                    SortColumn(uxWordFrequencies, _selectedHeadings, _wordColumn, SortOrder.None);
                    uxTabs.SelectTab(uxAllFilesTab);
                    uxSelectedFile.Text = "";
                }
            }
            catch (Exception error)
            {
                MessageBox.Show("Error:" + error.ToString(), "Error");
            }
        }

        /// <summary>
        /// Private Method 2: AddToListView Adds the contents of _frequencyTables to the dictionary
        /// </summary>
        private void AddToListView() 
        {
            foreach (KeyValuePair<string, Dictionary<string, float>> kvp in _frequencyTables)
            {
                ListViewItem item = new ListViewItem(kvp.Key);
                item.SubItems.Add($"{kvp.Value.Count,_vocabularyWidth}");
                item.SubItems.Add("");
                uxResults.Items.Add(item);
            }
        }
        /// <summary>
        /// Private Method 3: UpdateAllFiles tab updates the all files tab for the selected file and returns a dictionary with words and freqeuncies for the selected file. 
        /// </summary>
        /// <param name="so">SortOrder for the update.</param>
        /// <param name="column">Column to be sorted.</param>
        /// <returns>Dictionary with words and frequencies for frequencies list view.</returns>
        private void UpdateAllFilesTab(SortOrder so, int column)
        {
            string fileName = uxResults.SelectedItems[0].Text;
            uxSelectedFile.Text = fileName;
            ListViewItem item = uxResults.SelectedItems[0];
            Dictionary<string, float> main = _frequencyTables[fileName];
            foreach (ListViewItem lvi in uxResults.Items)
            {
                Dictionary<string, float> other = _frequencyTables[lvi.SubItems[0].Text];
                string dif = Analyzer.GetDifference(main, other, (int)uxNumberOfWords.Value).ToString(_differenceFormat);
                lvi.SubItems[2].Text = dif;
            }
            if (_resultsSorter.SortColumn == 2)
            {
                SortColumn(uxResults, _allFilesHeadings, column, so);
            }
        }
        /// <summary>
        /// Private Method 4: UpdateSelectedTab tab updates the selected tab for the selected file.
        /// </summary>
        /// <param name="main">Dictionary with words and frequencies.</param>
        /// <param name="so">SortOrder for the listview.</param>
        /// <param name="column">Column to be sorted.</param>
        private void UpdateSelectedTab(SortOrder so, int column)
        {
            string fileName = uxResults.SelectedItems[0].Text;
            Dictionary<string, float> main = _frequencyTables[fileName];
            uxWordFrequencies.Items.Clear();
            uxWordFrequencies.BeginUpdate();
            float thres = (float)uxThreshold.Value;
            foreach (KeyValuePair<string, float> kvp in main)
            {
                if (kvp.Value >= thres)
                {
                    ListViewItem item2 = new ListViewItem(kvp.Key);
                    item2.SubItems.Add(kvp.Value.ToString(_frequencyFormat));
                    uxWordFrequencies.Items.Add(item2);
                }
            }
            SortColumn(uxWordFrequencies, _selectedHeadings, column, so);
            uxWordFrequencies.EndUpdate();
        }
        /// <summary>
        /// Event Handler 2: On the selected file change it will update the differences column in results and update the selected tab with frequencies for the file. 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uxResults_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (uxResults.SelectedItems.Count > 0)
            {
                UpdateAllFilesTab(SortOrder.None, _differenceColumn);
                UpdateSelectedTab(SortOrder.Ascending, _wordColumn);
            }
        }
        /// <summary>
        /// Event Handler 3: On the number of words selected, updates the results and frequencies listviews by calling UpdateAllFilesTab and UpdateSelectedTab.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uxNumberOfWords_ValueChanged(object sender, EventArgs e)
        {
            if (uxSelectedFile.Text != "")
            {
                UpdateAllFilesTab(SortOrder.None, _differenceColumn);
                UpdateSelectedTab(_frequencySorter.Order, _frequencySorter.SortColumn);
            }
        }
        /// <summary>
        /// Event Handler 4: On the results column click, updates the sort order of the column and the heading approriately in the results list view. 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uxResults_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            ChangeColumnSort(e, _resultsSorter, _allFilesHeadings, uxResults);
        }
        /// <summary>
        /// Event Handler 5: On the word frequencies column click, updates the sort order of the column and the heading approriately in the word frequencies list view. 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uxWordFrequencies_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            ChangeColumnSort(e, _frequencySorter, _selectedHeadings, uxWordFrequencies);
        }
        /// <summary>
        /// Private Method 5: ChangeColumnSort changes the headings and sort order when clicking on a column. It deals with previously selected headings and changing the order. It it taken from 
        /// https://docs.microsoft.com/en-us/troubleshoot/developer/visualstudio/csharp/general/sort-listview-by-column in item number 6. 
        /// </summary>
        /// <param name="e">ColumnClickEventArgs used for the column property.</param>
        /// <param name="lvcs">Appropriate ListViewColumnSorter.</param>
        /// <param name="headings">Appropriate list of headings. </param>
        /// <param name="lv">Appropriate ListView. </param>
        private void ChangeColumnSort(ColumnClickEventArgs e, ListViewColumnSorter lvcs, string[] headings, ListView lv)
        {
            int column = e.Column;
            if (e.Column == lvcs.SortColumn)
            {
                if (lvcs.Order == SortOrder.Ascending)
                {
                    lvcs.Order = SortOrder.Descending;
                }
                else
                {
                    lvcs.Order = SortOrder.Ascending;
                }
            }
            else
            {
                lvcs.SortColumn = e.Column;
                lvcs.Order = SortOrder.Ascending;
            }
            SortColumn(lv, headings, column, lvcs.Order);
        }
        /// <summary>
        /// Event Handler 6: Deals with a change to the word frequency threshold. Will update the selected tab apprioprately. 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uxThreshold_ValueChanged(object sender, EventArgs e)
        {
            if (uxSelectedFile.Text != "")
            {
                string fileName = uxResults.SelectedItems[0].Text;
                uxSelectedFile.Text = fileName;
                ListViewItem item = uxResults.SelectedItems[0];
                Dictionary<string, float> main = _frequencyTables[fileName];
                UpdateSelectedTab(_frequencySorter.Order, _frequencySorter.SortColumn);
            }
        }
    }
}
