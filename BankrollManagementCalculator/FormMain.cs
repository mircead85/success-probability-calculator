using ResourceBasedSuccessGames;
using ResourceBasedSuccessGames.SpecificGambles;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BankrollManagementCalculator
{
    public partial class FormMain : Form
    {
        private static string blogURL = "http://informatica-computer-science.blogspot.ro/";

        private ProgramData Data;

        private void LoadDefaultData()
        {
            Data = new ProgramData();
            LoadDataIntoControls();
        }

        private bool LoadDataFromControls()
        {
            errorProvider.Clear();

            Data.availableGambles.Clear();

            bool bFailure = false;

            foreach (DataGridViewRow row in dgvAvailableGames.Rows)
            {
                if (row.IsNewRow)
                    continue;
                var gamble = row.Tag as DisplayableGamble;
                if (gamble == null)
                {
                    bFailure = true;
                    row.ErrorText = "This gamble is malformed.";
                }
                else
                {
                    Data.availableGambles.Add(gamble);
                    row.ErrorText = null;
                }
            }

            Data.bHasNoPlayGamble = ckNoPlay.Checked;
            ckNoPlay.Enabled = false;

            Data.bHasExpenses = ckExpenses.Checked;
            if (!double.TryParse(txtExpenses.Text, out Data.amountDue))
            {
                bFailure = true;
                errorProvider.SetError(txtExpenses, "Invalid value.");
            }

            if (!int.TryParse(txtPayFreq.Text, out Data.paymentDueEveryPeriods))
            {
                bFailure = true;
                errorProvider.SetError(txtPayFreq, "Invalid value.");
            }

            Data.paymentPeriod = (Periods)cbPayPeriod.SelectedIndex;

            if(!int.TryParse(txtNoGames.Text, out Data.noGamesPlayable))
            {
                bFailure = true;
                errorProvider.SetError(txtNoGames, "Invalid value.");
            }
            
            Data.playablePeriod = (Periods)cbPlayPeriod.SelectedIndex;

            if(!double.TryParse(txtObjective.Text, out Data.targetBankroll))
            {
                bFailure = true;
                errorProvider.SetError(txtObjective, "Invalid value.");
            }

            if(!int.TryParse(txtSimPeriod.Text, out Data.simulationPeriod))
            {
                bFailure = true;
                errorProvider.SetError(txtSimPeriod, "Invalid value");
            }

            Data.simulationPeriodKind = (Periods)cbSimPeriodType.SelectedIndex;
            Data.simulationObjective = (SimpleGame.Objectives)cbObjectiveKind.SelectedIndex;

            if(!double.TryParse(txtStartingBankroll.Text, out Data.startingBankroll))
            {
                bFailure = true;
                errorProvider.SetError(txtStartingBankroll, "Invalid value.");
            }
            
            if(!int.TryParse(txtPeriodsElapsed.Text, out Data.periodsElapsed))
            {
                bFailure = true;
                errorProvider.SetError(txtPeriodsElapsed, "Invalid value.");
            }

            Data.elapsedKind = (Periods)cbElapsedKind.SelectedIndex;

            if(!double.TryParse(lblFailureProb.Text, out Data.failureProbability))
            {
                Data.failureProbability = -1;
            }

            if(!double.TryParse(lblSuccessProb.Text, out Data.succesProbability))
            {
                Data.succesProbability = -1;
            }

            Data.nextGambleText = lblNextGame.Text;

            return !bFailure;
        }

        private void LoadGambleIntoRow(DisplayableGamble gamble, DataGridViewRow row)
        {
            row.Tag = gamble;
            row.Cells["clmStake"].Value = gamble.Stake.ToString("F");
            row.Cells["clmRake"].Value = gamble.Rake.ToString("F");
            row.Cells["clmRakeIncluded"].Value = "true";
            row.Cells["clmROI"].Value = (gamble.ROI * 100).ToString("F") + "%";
            row.Cells["clmProbability"].Value = (gamble.ProbabilityWin * 100).ToString("F") + "%";
            row.Cells["clmGameType"].Value = gamble.Kind;
            row.Cells["clmComplexGame"].Value = false;
        }

        private HeadsUpGamble LoadHeadsUpGambleFromRowData(DataGridViewRow row)
        {
            double stake = -1;
            double.TryParse(row.Cells["clmStake"].Value as string, out stake);
            double rake = -1;
            double.TryParse(row.Cells["clmRake"].Value as string, out rake);

            bool rakeIncluded = row.Cells["clmRakeIncluded"].Value as string == "true";

            if (stake < 0 || rake < 0)
                return null;

            HeadsUpGamble newGamble = new HeadsUpGamble(stake, rake, rakeIncluded);

            if (row.Cells["clmGameType"].Value as string != newGamble.Kind)
                return null;

            double roi = 0;
            double probability = 0;

            var roitxt = row.Cells["clmROI"].Value as string;
            if(roitxt.Length>0)
                roitxt = roitxt.Substring(0,roitxt.Length-1);
            var probtxt = row.Cells["clmProbability"].Value as string;
            if(probtxt.Length>0)
                probtxt=probtxt.Substring(0,probtxt.Length-1);

            try
            {
                if (double.TryParse(roitxt, out roi))
                {
                    newGamble.ROI = roi / 100.0;
                }
                else if (double.TryParse(probtxt, out probability))
                {
                    newGamble.ProbabilityWin = probability / 100.0;
                }
                else
                {
                    newGamble = null;
                }
            }
            catch (ArgumentException)
            {
                newGamble = null;
            }


            return newGamble;
        }

        private void LoadDataIntoControls()
        {
            dgvAvailableGames.Rows.Clear();

            foreach (var gamble in Data.availableGambles)
            {
                int rowId = dgvAvailableGames.Rows.Add();
                var row = dgvAvailableGames.Rows[rowId];
                LoadGambleIntoRow(gamble, row);
            }

            ckNoPlay.Checked = Data.bHasNoPlayGamble;
            ckNoPlay.Enabled = false;

            ckExpenses.Checked = Data.bHasExpenses;
            txtExpenses.Text = Data.amountDue.ToString("F");
            txtPayFreq.Text = Data.paymentDueEveryPeriods.ToString();
            cbPayPeriod.SelectedIndex = (int)Data.paymentPeriod;

            txtNoGames.Text = Data.noGamesPlayable.ToString();
            cbPlayPeriod.SelectedIndex = (int)Data.playablePeriod;

            txtObjective.Text = Data.targetBankroll.ToString("F");
            txtSimPeriod.Text = Data.simulationPeriod.ToString();
            cbSimPeriodType.SelectedIndex = (int)Data.simulationPeriodKind;
            cbObjectiveKind.SelectedIndex = (int)Data.simulationObjective;

            txtStartingBankroll.Text = Data.startingBankroll.ToString("F");
            txtPeriodsElapsed.Text = Data.periodsElapsed.ToString();
            cbElapsedKind.SelectedIndex = (int)Data.elapsedKind;

            lblFailureProb.Text = Data.failureProbability < 0 ? "-----%" : (100*Data.failureProbability).ToString("F")+"%";
            lblSuccessProb.Text = Data.succesProbability < 0 ? "-----%" : (100*Data.succesProbability).ToString("F")+"%";
            lblNextGame.Text = Data.nextGambleText;
        }

        public FormMain()
        {
            InitializeComponent();
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            var about = new aboutBox();
            if (about.ShowDialog(this) != DialogResult.OK)
            {
                this.Close();
            }

            llWelcome.LinkClicked += llWelcome_LinkClicked;
            LoadDefaultData();
        }

        void llWelcome_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start(blogURL);
        }

        private void label16_Click(object sender, EventArgs e)
        {

        }

        private bool isDigit(char ch)
        {
            if (ch == '0' || ch == '1' || ch == '2' || ch == '3' || ch == '4' || ch == '5' || ch == '6'
                || ch == '7' || ch == '8' || ch == '9')
                return true;
            return false;
        }

        private string validateValue(string amount, bool bProbability, bool bLessThan1 = false)
        {
            if (amount == null)
                return null;

            var str = amount.Trim();
            if (str.Length < 1)
                if (!bProbability)
                    return null;
                else
                    return str;

            char lastChar = str[str.Length - 1];
            if (!isDigit(lastChar))
                str = str.Substring(0, str.Length - 1);
            
            double result = 0;
            if (!double.TryParse(str, out result))
                return null;

            if (lastChar != '%' && bProbability)
            {
                result *= 100;
            }
            
            result = (int)(result * 100) / 100.0;
            
            if (bProbability && bLessThan1)
                if (result<0 || result > 100)
                    return null;

            return result.ToString("F")+(bProbability?"%":"");
        }

        private void dgvAvailableGames_RowValidating(object sender, DataGridViewCellCancelEventArgs e)
        {
            ValidateCell(dgvAvailableGames.Rows[e.RowIndex].Cells[e.ColumnIndex]);
        }

        private void dgvAvailableGames_NewRowNeeded(object sender, DataGridViewRowEventArgs e)
        {
            var row = e.Row;
            row.Tag = new HeadsUpGamble(1,0,false);
            row.Cells["clmStake"].Value = "1.00";
            row.Cells["clmRake"].Value = "0.00";
            row.Cells["clmROI"].Value = "0.00%";
            row.Cells["clmProbability"].Value = "50.00%";
            row.Cells["clmGameType"].Value = "Heads-Up Match";
            row.Cells["clmComplexGame"].Value = false;
        }

        private void dgvAvailableGames_DefaultValuesNeeded(object sender, DataGridViewRowEventArgs e)
        {

        }

        private void dgvAvailableGames_RowDirtyStateNeeded(object sender, QuestionEventArgs e)
        {
            
        }

        private void menuMainMenu_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void ckExpenses_CheckedChanged(object sender, EventArgs e)
        {
            if (ckExpenses.Checked)
                gbExpenses.Enabled = true;
            else
                gbExpenses.Enabled = false;
        }

        private void dgvAvailableGames_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private bool ValidateCell(DataGridViewCell cell)
        {
            var data = dgvAvailableGames.Rows[cell.RowIndex].Cells[cell.ColumnIndex];

            if (data.OwningRow.Cells["clmComplexGame"].Value as string == "true")
                return true;

            string newData = null;
            switch (data.OwningColumn.Name)
            {
                case "clmStake":
                    newData = validateValue(data.Value as string, false);
                    break;
                case "clmRake":
                    newData = validateValue(data.Value as string, false);
                    break;
                case "clmROI":
                    newData = validateValue(data.Value as string, true);
                    break;
                case "clmProbability":
                    newData = validateValue(data.Value as string, true, true);
                    break;
                default:
                    return true;
            }

            if (newData == null)
            {
                data.ErrorText = "Invalid value.";
                return false;
            }
            else
            {
                data.Value = newData;
                data.ErrorText = null;
            }
            return true;
        }

        private void dgvAvailableGames_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
        }

        private void dgvAvailableGames_CellLeave(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgvAvailableGames_CellValidated(object sender, DataGridViewCellEventArgs e)
        {
            ValidateCell(dgvAvailableGames.Rows[e.RowIndex].Cells[e.ColumnIndex]);

            var cell = dgvAvailableGames.Rows[e.RowIndex].Cells[e.ColumnIndex];
            if (cell.Value as string != "")
                if (cell.OwningColumn.Name == "clmProbability")
                    dgvAvailableGames.Rows[e.RowIndex].Cells["clmROI"].Value = "";
                else if (cell.OwningColumn.Name == "clmROI")
                    dgvAvailableGames.Rows[e.RowIndex].Cells["clmProbability"].Value = "";
        }

        private void dgvAvailableGames_RowValidated(object sender, DataGridViewCellEventArgs e)
        {
            var newGamble = LoadHeadsUpGambleFromRowData(dgvAvailableGames.Rows[e.RowIndex]);
            if (newGamble != null)
            {
                dgvAvailableGames.Rows[e.RowIndex].Cells["clmProbability"].Value = (100 * newGamble.ProbabilityWin).ToString("F") + "%";
                dgvAvailableGames.Rows[e.RowIndex].Cells["clmROI"].Value = (100 * newGamble.ROI).ToString("F") + "%";
                dgvAvailableGames.Rows[e.RowIndex].Tag = newGamble;
                dgvAvailableGames.Rows[e.RowIndex].ErrorText = null;
            }
            else
            {
                if (dgvAvailableGames.Rows[e.RowIndex].Cells["clmGameType"].Value as string == HeadsUpGamble.MyKind)
                    dgvAvailableGames.Rows[e.RowIndex].ErrorText = "This gamble is malformed.";
            }
        }

        private void finalizeGo()
        {
            if (!this.InvokeRequired)
            {
                finalize();
                LoadDataIntoControls();
            }
            else
                this.Invoke(new Action(finalizeGo));
        }

        private void btnGo_Click(object sender, EventArgs e)
        {
            try
            {
                if (!LoadDataFromControls())
                    return;
                Task tsk = new Task<bool>(new Func<bool>(Data.FillResult));
                tsk.ContinueWith(new Action<Task>(ts => finalizeGo()));
                this.UseWaitCursor = true;
                tsk.Start();
            }
            catch (Exception E)
            {
                MessageBox.Show(E.ToString(), "Error", MessageBoxButtons.OK);
            }
        }

        private void updateProgress(object sender, int percentage)
        {
            if (!btnCompute.InvokeRequired)
                btnCompute.Text = "Computing... " + percentage.ToString() + "%";
            else
                btnCompute.Invoke(new EventHandler<int>(updateProgress), sender, percentage);
        }

        private void finalize()
        {
            if (!this.InvokeRequired)
            {
                lblComputationTime.Text = Data.Solver.TimeToSolveInMilliseconds / 1000.0 + "s. ";
                this.UseWaitCursor = false;
                btnCompute.Enabled = true;
                btnCompute.Text = "Compute... (this might take a while)";

                lblFailureProb.Text = "-----";
                lblSuccessProb.Text = "-----";
                lblNextGame.Text = "---------";
            }
            else this.Invoke(new Action(finalize));
        }
        
        private void btnCompute_Click(object sender, EventArgs e)
        {
            try
            {
                if (!LoadDataFromControls())
                    return;

                Data.RebuildGame();

                this.UseWaitCursor = true;
                btnCompute.Enabled = false;
                Data.Solver.OnProgressMade += new EventHandler<int>(updateProgress);
                var task = new Task(Data.Solver.Solve);
                task.ContinueWith(new Action<Task>(tsk => finalize()));
                task.Start();
            }
            catch (Exception E)
            {
                MessageBox.Show(E.ToString(), "Error", MessageBoxButtons.OK);
            }
            finally
            {
            }
        }

        private void ShowError(Exception E)
        {
            MessageBox.Show(E.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if(!LoadDataFromControls())
                    return;

                SaveFileDialog dlg = new SaveFileDialog();
                dlg.OverwritePrompt = true;
                dlg.CheckPathExists = true;
                dlg.AddExtension = true;
                dlg.DefaultExt = "sim";

                if (dlg.ShowDialog(this) != DialogResult.OK)
                    return;

                using (var stream = dlg.OpenFile())
                {
                    Data.Solver.OnProgressMade -= new EventHandler<int>(updateProgress);
                    BinaryFormatter bf = new BinaryFormatter();
                    bf.Serialize(stream, Data);
                }

                MessageBox.Show("File saved.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception E)
            {
                ShowError(E);
            }
        }

        private void loadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog dlg = new OpenFileDialog();
                dlg.CheckFileExists = true;
                dlg.AddExtension = true;
                dlg.DefaultExt = "sim";

                if (dlg.ShowDialog(this) != DialogResult.OK)
                    return;

                using (var stream = dlg.OpenFile())
                {
                    BinaryFormatter bf = new BinaryFormatter();
                    Data = (ProgramData) bf.Deserialize(stream);
                    if(Data.Solver != null)
                        Data.Solver.OnProgressMade += new EventHandler<int>(updateProgress);
                }

                LoadDataIntoControls();

                MessageBox.Show("File loaded.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception E)
            {
                ShowError(E);
                LoadDefaultData();
            }
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Bankroll Management Calculator version 1.0.\n Copyright(c) Mircea Digulescu, 2015.", "About", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        private void llWelcome_LinkClicked_1(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }

        private void lblNextGame_Click(object sender, EventArgs e)
        {
            try
            {
                string[] fileNames = new string[]{
                    @"C:\Program Files\Poker Stars.EU\PokerStars.exe",
                    @"C:\Program Files (x86)\Poker Stars.EU\PokerStars.exe",
                    @"C:\Program Files\Poker Stars\PokerStars.exe",
                    @"C:\Program Files (x86)\Poker Stars\PokerStars.exe"};

                string result = null;
                foreach (var fileName in fileNames)
                {
                    try
                    {
                        FileInfo fi = new FileInfo(fileName);
                        if (fi.Exists)
                        {
                            result = fileName;
                            break;
                        }
                    }
                    catch (Exception)
                    { }
                }
                if (result != null)
                    Process.Start(result);
            }
            catch (Exception E)
            {
                ShowError(E);
            }
        }
    }
}
