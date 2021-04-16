using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Windows.Forms;
using mEXTRADROPSedit.Core;

namespace mEXTRADROPSedit.UI
{
    public partial class Main : Form
    {
        private enum FileWorkerJob
        {
            New,
            Load,
            Save
        }

        public Main()
        {
            InitializeComponent();

            this.Text = "mEXTRADROPSedit - " + Program.Path;

            // Fill the two choices for the entry type dropdown.
            entryTypeDropdown.Items.Add(ExtraDropType.Replace);
            entryTypeDropdown.Items.Add(ExtraDropType.Addon);

            // Add the placeholder text to the search textbox.
            searchTextbox.Text = "Item / Monster ID";
            searchTextbox.ForeColor = System.Drawing.Color.Gray;
        }

        /// <summary>
        /// Handler for Menu->File->Load. Loads a file.
        /// </summary>
        private void loadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Check that we aren't still loading/saving a file.
            if (fileWorker.IsBusy)
            {
                return;
            }

            // Use a standardized open file dialog.
            OpenFileDialog openFile = new OpenFileDialog();
            openFile.Title = "Open";
            openFile.Filter = ".sev Files|*.sev|All Files|*.*";

            try
            {
                if (openFile.ShowDialog() == DialogResult.OK)
                {
                    Stream fileStream = openFile.OpenFile();
                    fileWorker.RunWorkerAsync(Tuple.Create(FileWorkerJob.Load, fileStream));
                    Program.Path = openFile.FileName;

                    // Update UI.
                    this.Text = "mEXTRADROPSedit - " + Program.Path;
                }
            }
            catch (ArgumentNullException)
            {
                // Occurs if the file name is null, in which case we can simply discard it so the user can select again.
            }
            catch (EndOfStreamException)
            {
                // Occurs if we reach the end of the file earlier than expected. This probably means the file was 
                // corrupted.
                MessageBox.Show(
                    "File appears to be corrupted.",
                    "Unable to read file",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
            catch (NotSupportedException ex)
            {
                // Occurs if the file version number doesn't seem correct. The version number is returned in the 
                // exception message.
                MessageBox.Show(
                    "Version " + ex.Message + " is not supported.",
                    "Unable to read file",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        /// <summary>
        /// Handler for Menu->File->Save. Saves to the currently loaded file.
        /// </summary>
        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Check that we aren't still loading/saving a file.
            if (fileWorker.IsBusy)
            {
                return;
            }

            // If path is not an existing file, then it means no file is loaded. So we will Save As instead.
            if (!File.Exists(Program.Path))
            {
                saveAsToolStripMenuItem_Click(sender, e);
            }
            else
            {
                try
                {
                    Stream fileStream = new FileStream(Program.Path, FileMode.Create, FileAccess.Write);
                    fileWorker.RunWorkerAsync(Tuple.Create(FileWorkerJob.Save, fileStream));
                }
                catch
                {
                    // File can't be used for any number of reasons, so we will use Save As instead.
                    saveAsToolStripMenuItem_Click(sender, e);
                }
            }
        }

        /// <summary>
        /// Handler for Menu->File->Save As. Saves to a new file and makes it the currently loaded file.
        /// </summary>
        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Check that we aren't still loading/saving a file.
            if (fileWorker.IsBusy)
            {
                return;
            }

            // Use standardized Save As dialog.
            SaveFileDialog saveFile = new SaveFileDialog();
            saveFile.Title = "Save As";
            saveFile.Filter = ".sev Files|*.sev|All Files|*.*";

            if (saveFile.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    Stream fileStream = saveFile.OpenFile();
                    fileWorker.RunWorkerAsync(Tuple.Create(FileWorkerJob.Save, fileStream));
                    Program.Path = saveFile.FileName;

                    // Update UI.
                    this.Text = "mEXTRADROPSedit - " + Program.Path;
                }
                catch
                {
                    MessageBox.Show(
                        "Error saving file.",
                        "Unable to save file",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error
                    );
                }
                
            }
        }

        /// <summary>
        /// Handler for Menu->File->New. Loads a blank ExtraDropTable.
        /// </summary>
        private void newToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            // Check that we aren't still loading/saving a file.
            if (fileWorker.IsBusy)
            {
                return;
            }

            fileWorker.RunWorkerAsync(Tuple.Create<FileWorkerJob, Stream>(FileWorkerJob.New, null));
            Program.Path = "new";

            // Update UI.
            this.Text = "mEXTRADROPSedit - " + Program.Path;
        }

        /// <summary>
        /// Background worker for loading and saving files.
        /// </summary>
        private void fileWorker_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            Tuple<FileWorkerJob, Stream> arguments = e.Argument as Tuple<FileWorkerJob, Stream>;
            if (arguments != null)
            {
                if (arguments.Item1 == FileWorkerJob.Load || arguments.Item1 == FileWorkerJob.New)
                {
                    statusLabel.Text = "Loading...";

                    if (arguments.Item1 == FileWorkerJob.Load)
                    {
                        Program.Table = new ExtraDropTable(arguments.Item2);
                        arguments.Item2.Dispose();
                    }
                    else if (arguments.Item1 == FileWorkerJob.New)
                    {
                        Program.Table = new ExtraDropTable();
                    }


                    // Update UI.
                    this.Invoke(new MethodInvoker(delegate ()
                    {
                        // Clear all existing values first.
                        entryNameTextBox.Clear();
                        entryTypeDropdown.SelectedIndex = 0;

                        // Entries list.
                        entriesListBox.Items.Clear();

                        // Monsters group.
                        monstersListBox.Items.Clear();
                        monstersIdTextBox.Clear();

                        // Drop items group.
                        dropItemsListBox.Items.Clear();
                        dropItemsIdTextBox.Clear();
                        dropItemsProbabilityTextBox.Clear();

                        // Drop num probabilities group.
                        entryDrop0Textbox.Clear();
                        entryDrop1Textbox.Clear();
                        entryDrop2Textbox.Clear();
                        entryDrop3Textbox.Clear();
                        entryDrop4Textbox.Clear();
                        entryDrop5Textbox.Clear();
                        entryDrop6Textbox.Clear();
                        entryDrop7Textbox.Clear();

                        // Now add in entries.
                        foreach (ExtraDropEntry entry in Program.Table.Entries)
                        {
                            entriesListBox.Items.Add(entry);
                        }
                    }));
                }
                else if (arguments.Item1 == FileWorkerJob.Save)
                {
                    statusLabel.Text = "Saving...";
                    Program.Table.Serialize(arguments.Item2);
                    arguments.Item2.Dispose();
                }
            }
        }

        /// <summary>
        /// Handler for when the background worker completed its task.
        /// </summary>
        private void fileWorker_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            statusLabel.Text = "Ready";
        }

        private void newEntryMenuItem_Click(object sender, EventArgs e)
        {
            entriesListBox.Items.Add(Program.Table.NewEntry());
        }

        private void cloneEntryMenuItem_Click(object sender, EventArgs e)
        {
            if (entriesListBox.SelectedItem != null)
            {
                entriesListBox.Items.Add(Program.Table.CloneEntry(entriesListBox.SelectedIndex));
            }
        }

        private void deleteEntryMenuItem_Click(object sender, EventArgs e)
        {
            if (entriesListBox.SelectedItem != null)
            {
                Program.Table.DeleteEntry(entriesListBox.SelectedIndex);
                entriesListBox.Items.RemoveAt(entriesListBox.SelectedIndex);
            }
        }

        private void entriesListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListBox listBox = sender as ListBox;
            if (listBox != null)
            {
                ExtraDropEntry entry = listBox.SelectedItem as ExtraDropEntry;
                if (entry != null)
                {
                    // Name.
                    entryNameTextBox.Text = entry.Name;

                    // Type.
                    entryTypeDropdown.SelectedItem = entry.Type;

                    // Drop num probabilities.
                    entryDrop0Textbox.Text = entry.GetDropProbability(0).ToString("0.0###############");
                    entryDrop1Textbox.Text = entry.GetDropProbability(1).ToString("0.0###############");
                    entryDrop2Textbox.Text = entry.GetDropProbability(2).ToString("0.0###############");
                    entryDrop3Textbox.Text = entry.GetDropProbability(3).ToString("0.0###############");
                    entryDrop4Textbox.Text = entry.GetDropProbability(4).ToString("0.0###############");
                    entryDrop5Textbox.Text = entry.GetDropProbability(5).ToString("0.0###############");
                    entryDrop6Textbox.Text = entry.GetDropProbability(6).ToString("0.0###############");
                    entryDrop7Textbox.Text = entry.GetDropProbability(7).ToString("0.0###############");

                    // Monsters.
                    monstersListBox.Items.Clear();
                    monstersIdTextBox.Clear();
                    foreach (int monsterId in entry.Monsters)
                    {
                        monstersListBox.Items.Add(monsterId);
                    }

                    // Drop Items.
                    dropItemsListBox.Items.Clear();
                    dropItemsIdTextBox.Clear();
                    dropItemsProbabilityTextBox.Clear();
                    foreach (ExtraDropItem item in entry.DropItems)
                    {
                        dropItemsListBox.Items.Add(item);
                    }
                    entryDropItemsGroup.Text = string.Format("Drop Items ({0}/256)", entry.DropItems.Count);
                }
            }
        }

        /// <summary>
        /// Handler for when the entry name text box is editted. Here, we will only update the entry name in the entry
        /// and not the UI. This is simply to be consistent with the monster and item textbox behaviours.
        /// </summary>
        private void entryNameTextBox_TextChanged(object sender, EventArgs e)
        {
            TextBox textBox = sender as TextBox;
            if (textBox != null)
            {
                ExtraDropEntry entry = entriesListBox.SelectedItem as ExtraDropEntry;
                if (entry != null)
                {
                    string name = textBox.Text;
                    entry.SetName(name);
                }
            }
        }

        /// <summary>
        /// Handler for when the user leaves focus on the entry name text box. Now we actually update the UI. This is
        /// simply to be consistent with the monster and item textbox behaviours.
        /// </summary>
        private void entryNameTextBox_Leave(object sender, EventArgs e)
        {
            ExtraDropEntry entry = entriesListBox.SelectedItem as ExtraDropEntry;
            if (entry != null)
            {
                // Needed to update the name in the ListBox as well.
                entriesListBox.Items[entriesListBox.SelectedIndex] = entry;
            }
        }

        private void entryTypeDropdown_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox dropDown = sender as ComboBox;
            if (dropDown != null)
            {
                ExtraDropEntry entry = entriesListBox.SelectedItem as ExtraDropEntry;
                if (entry != null)
                {
                    try
                    {
                        ExtraDropType type = (ExtraDropType) dropDown.SelectedItem;
                        entry.SetType(type);
                    }
                    catch (InvalidCastException)
                    {
                        MessageBox.Show(
                            "Error attempting to change type",
                            "Error",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error
                        );
                    }
                }
            }
        }

        /// <summary>
        /// Handler to handle all drop num textbox TextChanged events.
        /// </summary>
        /// <param name="sender">The textbox that sent the event.</param>
        /// <param name="i">The drop num to change.</param>
        private void dropNumTextbox_TextChanged(object sender, int i)
        {
            TextBox textBox = sender as TextBox;
            if (textBox != null)
            {
                // We'll only update the probability if it is actually a valid float. This is because numbers tend to
                // take more than one keystrokes to type and can be easily typed incorrectly.
                float probability;
                if (float.TryParse(textBox.Text, out probability))
                {
                    ExtraDropEntry entry = entriesListBox.SelectedItem as ExtraDropEntry;
                    if (entry != null)
                    {
                        entry.SetDropProbability(i, probability);
                    }
                }
            }
        }

        private void entryDrop0Textbox_TextChanged(object sender, EventArgs e)
        {
            dropNumTextbox_TextChanged(sender, 0);
        }

        private void entryDrop1Textbox_TextChanged(object sender, EventArgs e)
        {
            dropNumTextbox_TextChanged(sender, 1);
        }

        private void entryDrop2Textbox_TextChanged(object sender, EventArgs e)
        {
            dropNumTextbox_TextChanged(sender, 2);
        }

        private void entryDrop3Textbox_TextChanged(object sender, EventArgs e)
        {
            dropNumTextbox_TextChanged(sender, 3);
        }

        private void entryDrop4Textbox_TextChanged(object sender, EventArgs e)
        {
            dropNumTextbox_TextChanged(sender, 4);
        }

        private void entryDrop5Textbox_TextChanged(object sender, EventArgs e)
        {
            dropNumTextbox_TextChanged(sender, 5);
        }

        private void entryDrop6Textbox_TextChanged(object sender, EventArgs e)
        {
            dropNumTextbox_TextChanged(sender, 6);
        }

        private void entryDrop7Textbox_TextChanged(object sender, EventArgs e)
        {
            dropNumTextbox_TextChanged(sender, 7);
        }

        private void monstersListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListBox listBox = sender as ListBox;
            if (listBox != null && listBox.SelectedItem != null)
            {
                monstersIdTextBox.Text = listBox.SelectedItem.ToString();
            }
        }


        /// <summary>
        /// Handler for when the monster id text box is editted. Here, we will only update the item id in the entry
        /// and not the UI. This is because updating the UI forces the id to get formatted, which makes it hard to type.
        /// </summary>
        private void monstersIdTextBox_TextChanged(object sender, EventArgs e)
        {
            TextBox textBox = sender as TextBox;
            if (textBox != null)
            {
                // We'll only update the id if it is actually a valid int. This is because numbers tend to take more 
                // than one keystrokes to type and can be easily typed incorrectly.
                int monsterId;
                if (int.TryParse(textBox.Text, out monsterId))
                {
                    ExtraDropEntry entry = entriesListBox.SelectedItem as ExtraDropEntry;
                    if (entry != null)
                    {
                        entry.EditMonster(monstersListBox.SelectedIndex, monsterId);
                    }
                }
            }
        }

        /// <summary>
        /// Handler for when the user leaves focus on the monster id text box. Now we actually update the UI.
        /// </summary>
        private void monstersIdTextBox_Leave(object sender, EventArgs e)
        {
            ExtraDropEntry entry = entriesListBox.SelectedItem as ExtraDropEntry;
            if (entry != null && monstersListBox.SelectedItem != null && monstersListBox.SelectedIndex >= 0)
            {
                // This ensures the list updates as well.
                monstersListBox.Items[monstersListBox.SelectedIndex] = entry.Monsters[monstersListBox.SelectedIndex];
            }
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ExtraDropEntry entry = entriesListBox.SelectedItem as ExtraDropEntry;
            if (entry != null)
            {
                monstersListBox.Items.Add(entry.NewMonster());
            }
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ExtraDropEntry entry = entriesListBox.SelectedItem as ExtraDropEntry;
            if (entry != null && monstersListBox.SelectedItem != null && monstersListBox.SelectedIndex >= 0)
            {
                entry.DeleteMonster(monstersListBox.SelectedIndex);

                // This ensures the list updates as well.
                monstersListBox.Items.RemoveAt(monstersListBox.SelectedIndex);
            }
        }

        private void dropItemsListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListBox listBox = sender as ListBox;
            if (listBox != null && listBox.SelectedItem != null && listBox.SelectedIndex >= 0)
            {
                ExtraDropItem item = listBox.SelectedItem as ExtraDropItem;
                if (item != null)
                {
                    dropItemsIdTextBox.Text = item.Id.ToString();
                    dropItemsProbabilityTextBox.Text = item.Probability.ToString("0.0###############");
                }
            }
        }

        /// <summary>
        /// Handler for when the drop item id text box is editted. Here, we will only update the item id in the entry
        /// and not the UI. This is because updating the UI forces the id to get formatted, which makes it hard to type.
        /// </summary>
        private void dropItemsIdTextBox_TextChanged(object sender, EventArgs e)
        {
            TextBox textBox = sender as TextBox;
            if (textBox != null)
            {
                // We'll only update the id if it is actually a valid int. This is because numbers tend to take more 
                // than one keystrokes to type and can be easily typed incorrectly.
                uint itemId;
                if (uint.TryParse(textBox.Text, out itemId))
                {
                    ExtraDropEntry entry = entriesListBox.SelectedItem as ExtraDropEntry;
                    if (entry != null)
                    {
                        ExtraDropItem item = dropItemsListBox.SelectedItem as ExtraDropItem;
                        if (item != null)
                        {
                            entry.EditItemId(dropItemsListBox.SelectedIndex, itemId);
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Handler for when the user leaves focus on the drop item id text box. Now we actually update the UI.
        /// </summary>
        private void dropItemsIdTextBox_Leave(object sender, EventArgs e)
        {
            ExtraDropEntry entry = entriesListBox.SelectedItem as ExtraDropEntry;
            if (entry != null)
            {
                ExtraDropItem item = dropItemsListBox.SelectedItem as ExtraDropItem;
                if (item != null && dropItemsListBox.SelectedItem != null && dropItemsListBox.SelectedIndex >= 0)
                {
                    // This ensures the list updates as well.
                    dropItemsListBox.Items[dropItemsListBox.SelectedIndex] = item;
                }
            }
        }

        /// <summary>
        /// Handler for when the drop item probability text box is editted. Here, we will only update the probability in
        /// the entry and not the UI. This is because updating the UI forces the probability to get formatted, which 
        /// makes it hard to type.
        /// </summary>
        private void dropItemsProbabilityTextBox_TextChanged(object sender, EventArgs e)
        {
            TextBox textBox = sender as TextBox;
            if (textBox != null)
            {
                // We'll only update the id if it is actually a valid int. This is because numbers tend to take more 
                // than one keystrokes to type and can be easily typed incorrectly.
                float probability;
                if (float.TryParse(textBox.Text, out probability))
                {
                    ExtraDropEntry entry = entriesListBox.SelectedItem as ExtraDropEntry;
                    if (entry != null)
                    {
                        ExtraDropItem item = dropItemsListBox.SelectedItem as ExtraDropItem;
                        if (item != null)
                        {
                            entry.EditItemProbability(dropItemsListBox.SelectedIndex, probability);
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Handler for when the user leaves focus on the drop item probability text box. Now we actually update the UI.
        /// </summary>
        private void dropItemsProbabilityTextBox_Leave(object sender, EventArgs e)
        {
            ExtraDropEntry entry = entriesListBox.SelectedItem as ExtraDropEntry;
            if (entry != null)
            {
                ExtraDropItem item = dropItemsListBox.SelectedItem as ExtraDropItem;
                if (item != null && dropItemsListBox.SelectedItem != null && dropItemsListBox.SelectedIndex >= 0)
                {
                    // This ensures the list updates as well.
                    dropItemsListBox.Items[dropItemsListBox.SelectedIndex] = item;
                }
            }
        }

        private void newToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            ExtraDropEntry entry = entriesListBox.SelectedItem as ExtraDropEntry;
            if (entry != null)
            {
                try
                {
                    dropItemsListBox.Items.Add(entry.NewItem());

                    entryDropItemsGroup.Text = string.Format("Drop Items ({0}/256)", entry.DropItems.Count);
                }
                catch (OverflowException)
                {
                    MessageBox.Show(
                        "Cannot have more than 256 drop items.",
                        "Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error
                    );
                }
            }
        }

        private void deleteToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            ExtraDropEntry entry = entriesListBox.SelectedItem as ExtraDropEntry;
            if (entry != null)
            {
                entry.DeleteItem(dropItemsListBox.SelectedIndex);

                // This ensures the list updates as well.
                dropItemsListBox.Items.RemoveAt(dropItemsListBox.SelectedIndex);

                entryDropItemsGroup.Text = string.Format("Drop Items ({0}/256)", entry.DropItems.Count);
            }
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutBox box = new AboutBox();
            box.ShowDialog();
        }

        /// <summary>
        /// Handler for Menu->Tools->Check Probabilities. This will verify whether the probabilities add up to 1.
        /// </summary>
        private void checkProbabilitiesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ExtraDropEntry entry = entriesListBox.SelectedItem as ExtraDropEntry;
            if (entry != null)
            {
                bool allClear = true;

                if (!entry.IsDropNumProbabilitiesCorrect())
                {
                    allClear = false;

                    DialogResult result = MessageBox.Show(
                        "The drop num probabilities of the current entry does not add up to 1.0.\n" +
                        "Would you like to fix this automatically?",
                        "Drop Num Probabilities",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Warning
                    );

                    if (result == DialogResult.Yes)
                    {
                        entry.FixDropNumProbabilities();

                        // Force refres drop num probabilities.
                        entryDrop0Textbox.Text = entry.GetDropProbability(0).ToString("0.0###############");
                        entryDrop1Textbox.Text = entry.GetDropProbability(1).ToString("0.0###############");
                        entryDrop2Textbox.Text = entry.GetDropProbability(2).ToString("0.0###############");
                        entryDrop3Textbox.Text = entry.GetDropProbability(3).ToString("0.0###############");
                        entryDrop4Textbox.Text = entry.GetDropProbability(4).ToString("0.0###############");
                        entryDrop5Textbox.Text = entry.GetDropProbability(5).ToString("0.0###############");
                        entryDrop6Textbox.Text = entry.GetDropProbability(6).ToString("0.0###############");
                        entryDrop7Textbox.Text = entry.GetDropProbability(7).ToString("0.0###############");
                    }
                }

                if (!entry.IsDropItemsProbabilitiesCorrect())
                {
                    allClear = false;

                    DialogResult result = MessageBox.Show(
                        "The drop items probabilities of the current entry does not add up to 1.0.\n" +
                        "Would you like to fix this automatically?",
                        "Drop Items Probabilities",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Warning
                    );

                    if (result == DialogResult.Yes)
                    {
                        entry.FixDropItemsProbabilities();

                        // Refresh drop items probabilities.
                        dropItemsListBox.Items.Clear();
                        dropItemsIdTextBox.Clear();
                        dropItemsProbabilityTextBox.Clear();
                        foreach (ExtraDropItem item in entry.DropItems)
                        {
                            dropItemsListBox.Items.Add(item);
                        }
                    }
                }

                if (allClear)
                {
                    MessageBox.Show(
                        "No problems found.",
                        "All Clear!",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.None
                    );
                }
                
            }
        }

        /// <summary>
        /// Remove the placeholder text when entering focus.
        /// </summary>
        private void searchTextbox_Enter(object sender, EventArgs e)
        {
            TextBox textBox = sender as TextBox;
            if (textBox != null && textBox.Text == "Item / Monster ID")
            {
                textBox.Clear();
                textBox.ForeColor = System.Drawing.Color.Black;
            }
        }

        /// <summary>
        /// Add a placeholder text when leaving focus if the textbox is blank.
        /// </summary>
        private void searchTextbox_Leave(object sender, EventArgs e)
        {
            TextBox textBox = sender as TextBox;
            if (textBox != null && textBox.Text == "")
            {
                textBox.Text = "Item / Monster ID";
                textBox.ForeColor = System.Drawing.Color.Gray;
            }
        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            // We parse the id as a long because monster ids are int while item ids are uint. This way we can fit both.
            long id;
            if (long.TryParse(searchTextbox.Text, out id))
            {
                bool noChanges = true;

                int entryOffset = 0;
                int monsterOffset = 0;
                int itemOffset = 0;

                if (entriesListBox.SelectedItem != null)
                {
                    entryOffset = entriesListBox.SelectedIndex;
                }

                if (monstersListBox.SelectedItem != null)
                {
                    monsterOffset = monstersListBox.SelectedIndex;
                }

                if (dropItemsListBox.SelectedItem != null)
                {
                    itemOffset = dropItemsListBox.SelectedIndex;
                }

                // This do-while loop allows us to keep searching down wards every time we press the search button. 
                // We set a flag noChanges that becomes false if the SelectedIndex of either the entry list, monster
                // list or item list moves. This would imply we found a new item, and we stop the loop. However, if
                // nothing changes, then it means we just found the exact same item. In which case, we increment the 
                // offset and the do-while loop forces another search. This will still terminate however, since 
                // eventually indices.Item1 which represents the entry index will become -1, and a message box will
                // display which also sets noChanges to false.
                do
                {
                    Tuple<int, int, int> indices = Program.Table.FindEntry(id, entryOffset, monsterOffset, itemOffset);

                    if (indices.Item1 != -1)
                    {
                        if (indices.Item1 != entriesListBox.SelectedIndex)
                        {
                            entriesListBox.SelectedIndex = indices.Item1;
                            noChanges = false;
                        }

                        if (indices.Item2 != -1 && indices.Item2 != monstersListBox.SelectedIndex)
                        {
                            monstersListBox.SelectedIndex = indices.Item2;
                            noChanges = false;
                            monsterOffset = 0;
                        }
                        else
                        {
                            monsterOffset++;
                        }

                        if (indices.Item3 != -1 && indices.Item3 != dropItemsListBox.SelectedIndex)
                        {
                            dropItemsListBox.SelectedIndex = indices.Item3;
                            noChanges = false;
                            itemOffset = 0;
                        }
                        else
                        {
                            itemOffset++;
                        }
                    }
                    else
                    {
                        MessageBox.Show(
                            "Reached end of table with no results.",
                            "No results",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.None
                        );
                        noChanges = false;
                    }

                } while (noChanges);
            }
        }
    }
}