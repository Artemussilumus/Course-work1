using System;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;

namespace WinFormsApp2
{
    public partial class Form1 : Form
    {
        //private string xmlFilePath = @"C:\Users\user\source\repos\WinFormsApp2\WinFormsApp2\bin\Debug\net6.0-windows\RadioSessions.xml";
        private string xmlFilePath;
        private List<Session> sessions;

        public Form1()
        {
            InitializeComponent();
        }

        private void LoadData()
        {
            if (string.IsNullOrEmpty(xmlFilePath))
            {
                MessageBox.Show("Please select an XML file first.");
                return;
            }

            DataSet ds = new DataSet();
            ds.ReadXml(xmlFilePath);
            // Check if the DataSet contains any tables
            if (ds.Tables.Count == 0)
            {
                // If no tables are present, create an empty DataTable with the necessary columns
                DataTable emptyDt = new DataTable();
                emptyDt.Columns.Add("UserName");
                emptyDt.Columns.Add("Frequency");
                emptyDt.Columns.Add("Date");
                emptyDt.Columns.Add("StartTime");
                emptyDt.Columns.Add("EndTime");
                emptyDt.Columns.Add("Amount");
                dataGridView1.DataSource = emptyDt;

                sessions = new List<Session>();
                MessageBox.Show("No data found in the file. A new session table has been created.");
                return;
            }
            DataTable dt = ds.Tables[0];

            sessions = new List<Session>();

            foreach (DataRow row in dt.Rows)
            {
                sessions.Add(new Session
                {
                    UserName = row["UserName"].ToString(),
                    Frequency = row["Frequency"].ToString(),
                    Date = row["Date"].ToString(),
                    StartTime = row["StartTime"].ToString(),
                    EndTime = row["EndTime"].ToString(),
                    Amount = row["Amount"].ToString()
                });
            }

            // Sort the sessions by UserName using Quick Sort
            QuickSort.Sort(sessions, 0, sessions.Count - 1);

            // Convert the sorted list back to a DataTable
            DataTable sortedTable = new DataTable();
            sortedTable.Columns.Add("UserName");
            sortedTable.Columns.Add("Frequency");
            sortedTable.Columns.Add("Date");
            sortedTable.Columns.Add("StartTime");
            sortedTable.Columns.Add("EndTime");
            sortedTable.Columns.Add("Amount");

            foreach (var session in sessions)
            {
                sortedTable.Rows.Add(session.UserName, session.Frequency, session.Date, session.StartTime, session.EndTime, session.Amount);
            }

            // Bind the sorted DataTable to the DataGridView
            dataGridView1.DataSource = sortedTable;
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            // Validate UserName
            if (string.IsNullOrWhiteSpace(txtUserName.Text))
            {
                MessageBox.Show("UserName cannot be empty.");
                return;
            }

            // Validate Frequency
            if (!double.TryParse(txtFrequency.Text, out double frequency))
            {
                MessageBox.Show("Frequency must be a valid number.");
                return;
            }

            // Validate Date
            if (!DateTime.TryParse(txtDate.Text, out DateTime date))
            {
                MessageBox.Show("Date must be a valid date.");
                return;
            }

            // Validate StartTime
            if (!TimeSpan.TryParse(txtStartTime.Text, out TimeSpan startTime))
            {
                MessageBox.Show("Start Time must be a valid time.");
                return;
            }

            // Validate EndTime
            if (!TimeSpan.TryParse(txtEndTime.Text, out TimeSpan endTime))
            {
                MessageBox.Show("End Time must be a valid time.");
                return;
            }

            // Ensure EndTime is after StartTime
            if (endTime <= startTime)
            {
                MessageBox.Show("End Time must be after Start Time.");
                return;
            }

            // Validate Amount
            if (!int.TryParse(txtAmount.Text, out int amount))
            {
                MessageBox.Show("Amount must be a valid integer.");
                return;
            }

            // If all validations pass, create the session
            XmlDocument doc = new XmlDocument();
            doc.Load(xmlFilePath);

            XmlNode root = doc.DocumentElement;

            XmlElement newSession = doc.CreateElement("Session");

            XmlElement userName = doc.CreateElement("UserName");
            userName.InnerText = txtUserName.Text;
            newSession.AppendChild(userName);

            XmlElement frequencyElement = doc.CreateElement("Frequency");
            frequencyElement.InnerText = txtFrequency.Text;
            newSession.AppendChild(frequencyElement);

            XmlElement dateElement = doc.CreateElement("Date");
            dateElement.InnerText = txtDate.Text;
            newSession.AppendChild(dateElement);

            XmlElement startTimeElement = doc.CreateElement("StartTime");
            startTimeElement.InnerText = txtStartTime.Text;
            newSession.AppendChild(startTimeElement);

            XmlElement endTimeElement = doc.CreateElement("EndTime");
            endTimeElement.InnerText = txtEndTime.Text;
            newSession.AppendChild(endTimeElement);

            XmlElement amountElement = doc.CreateElement("Amount");
            amountElement.InnerText = txtAmount.Text;
            newSession.AppendChild(amountElement);

            root.AppendChild(newSession);
            doc.Save(xmlFilePath);
            LoadData();
            MessageBox.Show("Session created successfully!");
        }

        private void Update_Click(object sender, EventArgs e)
        {


            XmlDocument doc = new XmlDocument();
            doc.Load(xmlFilePath);

            XmlNode sessionToUpdate = doc.SelectSingleNode($"//Session[UserName='{txtUserName.Text}']");

            if (sessionToUpdate != null)
            {
                sessionToUpdate["Frequency"].InnerText = txtFrequency.Text;
                sessionToUpdate["Date"].InnerText = txtDate.Text;
                sessionToUpdate["StartTime"].InnerText = txtStartTime.Text;
                sessionToUpdate["EndTime"].InnerText = txtEndTime.Text;
                sessionToUpdate["Amount"].InnerText = txtAmount.Text;
                doc.Save(xmlFilePath);
                LoadData();
            }

        }

        private void Delete_Click(object sender, EventArgs e)
        {

            {
                XmlDocument doc = new XmlDocument();
                doc.Load(xmlFilePath);

                XmlNode sessionToDelete = doc.SelectSingleNode($"//Session[UserName='{txtUserName.Text}']");

                if (sessionToDelete != null)
                {
                    sessionToDelete.ParentNode.RemoveChild(sessionToDelete);
                    doc.Save(xmlFilePath);
                    LoadData();
                }
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {

        }

        private void Searchbutton_Click(object sender, EventArgs e)
        {
            string userName = txtSearch.Text;

            int index = BinarySearch.Search(sessions, userName);

            if (index != -1)
            {
                // Highlight the found session in the DataGridView
                dataGridView1.ClearSelection();
                dataGridView1.Rows[index].Selected = true;
                dataGridView1.FirstDisplayedScrollingRowIndex = index;
                MessageBox.Show($"User '{userName}' found at index {index}.");
            }
            else
            {
                MessageBox.Show($"User '{userName}' not found.");
            }
        }

        private void AmountPerMinute_Click(object sender, EventArgs e)
        {
            // Check if sessions list is empty
            if (sessions == null || sessions.Count == 0)
            {
                MessageBox.Show("No sessions available to calculate.");
                return;
            }

            // Create a new DataTable to store the calculation results
            DataTable resultsTable = new DataTable();
            resultsTable.Columns.Add("UserName");
            resultsTable.Columns.Add("Frequency");
            resultsTable.Columns.Add("Date");
            resultsTable.Columns.Add("StartTime");
            resultsTable.Columns.Add("EndTime");
            resultsTable.Columns.Add("Amount");
            resultsTable.Columns.Add("AmountPerMinute");

            foreach (var session in sessions)
            {
                TimeSpan duration = DateTime.Parse(session.EndTime).Subtract(DateTime.Parse(session.StartTime));
                double totalMinutes = duration.TotalMinutes;
                double amountPerMinute = totalMinutes > 0 ? double.Parse(session.Amount) / totalMinutes : 0;

                DataRow row = resultsTable.NewRow();
                row["UserName"] = session.UserName;
                row["Frequency"] = session.Frequency;
                row["Date"] = session.Date;
                row["StartTime"] = session.StartTime;
                row["EndTime"] = session.EndTime;
                row["Amount"] = session.Amount;
                row["AmountPerMinute"] = amountPerMinute;

                resultsTable.Rows.Add(row);
            }

            // Bind the results DataTable to the DataGridView
            dataGridView1.DataSource = resultsTable;
        }

        private void FilterByTimeButton_Click(object sender, EventArgs e)
        {
            // Get the date and time range from the TextBoxes
            string filterDate = txtFilterDate.Text;
            string filterTimeFrom = txtFilterTimeFrom.Text;
            string filterTimeTo = txtFilterTimeTo.Text;

            // Validate the input date and times
            if (!DateTime.TryParse(filterDate, out DateTime fromDate))
            {
                MessageBox.Show("Filter Date must be a valid date.");
                return;
            }

            if (!TimeSpan.TryParse(filterTimeFrom, out TimeSpan timeFrom))
            {
                MessageBox.Show("Filter Time From must be a valid time.");
                return;
            }

            if (!TimeSpan.TryParse(filterTimeTo, out TimeSpan timeTo))
            {
                MessageBox.Show("Filter Time To must be a valid time.");
                return;
            }

            // Combine date and time for filtering
            DateTime fromDateTime = fromDate.Date + timeFrom;
            DateTime toDateTime = fromDate.Date + timeTo;

            // Check if sessions list is empty
            if (sessions == null || sessions.Count == 0)
            {
                MessageBox.Show("No sessions available to search.");
                return;
            }

            // Create a new list to store the filtered sessions
            List<Session> filteredSessions = new List<Session>();

            // Iterate over the sessions and filter based on the date and time range
            foreach (var session in sessions)
            {
                DateTime sessionDate;
                DateTime startTime;
                DateTime endTime;

                if (DateTime.TryParse(session.Date, out sessionDate) &&
                    DateTime.TryParse(session.StartTime, out startTime) &&
                    DateTime.TryParse(session.EndTime, out endTime))
                {
                    if (sessionDate.Date == fromDate.Date && startTime.TimeOfDay >= timeFrom && endTime.TimeOfDay <= timeTo)
                    {
                        filteredSessions.Add(session);
                    }
                }
            }

            if (filteredSessions.Count == 0)
            {
                MessageBox.Show("No sessions found within the specified range.");
                return;
            }

            // Create a new DataTable to display the filtered results
            DataTable filteredTable = new DataTable();
            filteredTable.Columns.Add("UserName");
            filteredTable.Columns.Add("Frequency");
            filteredTable.Columns.Add("Date");
            filteredTable.Columns.Add("StartTime");
            filteredTable.Columns.Add("EndTime");
            filteredTable.Columns.Add("Amount");

            foreach (var session in filteredSessions)
            {
                filteredTable.Rows.Add(session.UserName, session.Frequency, session.Date, session.StartTime, session.EndTime, session.Amount);
            }

            // Bind the filtered DataTable to the DataGridView
            dataGridView1.DataSource = filteredTable;
        }

        private void btnSearchMonthStats_Click(object sender, EventArgs e)
        {
            // Get the month number from the TextBox
            if (!int.TryParse(txtMonthNumber.Text, out int monthNumber) || monthNumber < 1 || monthNumber > 12)
            {
                MessageBox.Show("Please enter a valid month number (1-12).");
                return;
            }

            // Check if sessions list is empty
            if (sessions == null || sessions.Count == 0)
            {
                MessageBox.Show("No sessions available to search.");
                return;
            }

            // Get the previous year
            int previousYear = DateTime.Now.Year - 1;

            // Initialize counters
            int sessionCount = 0;
            double totalDuration = 0;

            // Iterate over the sessions to find matching sessions
            foreach (var session in sessions)
            {
                if (DateTime.TryParse(session.Date, out DateTime sessionDate) &&
                    DateTime.TryParse(session.StartTime, out DateTime startTime) &&
                    DateTime.TryParse(session.EndTime, out DateTime endTime))
                {
                    if (sessionDate.Year == previousYear && sessionDate.Month == monthNumber)
                    {
                        sessionCount++;
                        totalDuration += (endTime - startTime).TotalMinutes;
                    }
                }
            }

            // Calculate average duration
            double averageDuration = sessionCount > 0 ? totalDuration / sessionCount : 0;

            // Display the results
            MessageBox.Show($"Sessions in {monthNumber}/{previousYear}: {sessionCount}\nAverage Duration: {averageDuration} minutes");
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void btnFindSession_Click(object sender, EventArgs e)
        {
            try
            {
                // Завантаження XML файлу
                XDocument doc = XDocument.Load("RadioSessions.xml");

                // Поточний місяць і рік
                int currentMonth = DateTime.Now.Month;
                int currentYear = DateTime.Now.Year;

                // Парсинг сеансів
                var sessions = doc.Descendants("Session")
                    .Select(s => new
                    {
                        StartTime = DateTime.Parse(s.Element("StartTime").Value),
                        EndTime = DateTime.Parse(s.Element("EndTime").Value)
                    })
                    .Where(s => s.StartTime.Month == currentMonth && s.StartTime.Year == currentYear)
                    .ToList();

                if (sessions.Count == 0)
                {
                    MessageBox.Show("Немає сеансів у поточному місяці.");
                    return;
                }

                // Знаходження найкоротшого сеансу
                var shortestSession = sessions
                    .Select(s => new
                    {
                        Duration = (s.EndTime - s.StartTime).TotalSeconds,
                        StartTime = s.StartTime,
                        EndTime = s.EndTime
                    })
                    .OrderBy(s => s.Duration)
                    .First();

                // Відображення результату
                MessageBox.Show($"Найкоротший сеанс тривав {shortestSession.Duration} секунд.");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Виникла помилка: {ex.Message}");
            }
        }

        private void btnCreateMonthlyReport_Click(object sender, EventArgs e)
        {
            // Get the previous month and year
            DateTime now = DateTime.Now;
            DateTime previousMonth = now.AddMonths(-1);
            int previousMonthYear = previousMonth.Year;
            int previousMonthNumber = previousMonth.Month;

            // Check if sessions list is empty
            if (sessions == null || sessions.Count == 0)
            {
                MessageBox.Show("No sessions available to create a report.");
                return;
            }

            // Initialize a StringBuilder to hold the report content
            StringBuilder reportContent = new StringBuilder();
            reportContent.AppendLine("UserName, Frequency, Date, StartTime, EndTime, Duration (minutes)");

            // Iterate over the sessions to find sessions from the previous month
            foreach (var session in sessions)
            {
                if (DateTime.TryParse(session.Date, out DateTime sessionDate) &&
                    DateTime.TryParse(session.StartTime, out DateTime startTime) &&
                    DateTime.TryParse(session.EndTime, out DateTime endTime))
                {
                    if (sessionDate.Year == previousMonthYear && sessionDate.Month == previousMonthNumber)
                    {
                        double duration = (endTime - startTime).TotalMinutes;
                        reportContent.AppendLine($"{session.UserName}, {session.Frequency}, {sessionDate:yyyy-MM-dd}, {startTime:HH:mm}, {endTime:HH:mm}, {duration}");
                    }
                }
            }

            // Define the report file path
            string reportFilePath = $"SessionReport_{previousMonthYear}_{previousMonthNumber}.txt";

            // Save the report to a file
            File.WriteAllText(reportFilePath, reportContent.ToString());

            // Inform the user that the report has been created
            MessageBox.Show($"Report for {previousMonth.ToString("MMMM yyyy")} created successfully at {reportFilePath}");
        }

        private void btnChooseFilePath_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "XML Files (*.xml)|*.xml|All Files (*.*)|*.*";
                openFileDialog.Title = "Select a File for Sessions";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    xmlFilePath = openFileDialog.FileName;
                    // Load the data from the selected file
                    LoadData();
                }
            }
        }

        private void btnCreateFilePath_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = "XML Files (*.xml)|*.xml|All Files (*.*)|*.*";
                saveFileDialog.Title = "Select or Create a File for Sessions";
                saveFileDialog.DefaultExt = "xml";
                saveFileDialog.AddExtension = true;

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    xmlFilePath = saveFileDialog.FileName;

                    // Check if the file exists, if not create a new one
                    if (!File.Exists(xmlFilePath))
                    {
                        // Create a new XML file with a root element
                        XmlDocument doc = new XmlDocument();
                        XmlElement root = doc.CreateElement("RadioSessions");
                        doc.AppendChild(root);
                        doc.Save(xmlFilePath);
                        MessageBox.Show($"New file created at {xmlFilePath}");
                    }

                    // Load the data from the selected file
                    LoadData();
                }
            }
        }
    }
}
public class Session
{
    public string UserName { get; set; }
    public string Frequency { get; set; }
    public string Date { get; set; }
    public string StartTime { get; set; }
    public string EndTime { get; set; }
    public string Amount { get; set; }
}
public class QuickSort
{
    public static void Sort(List<Session> sessions, int left, int right)
    {
        if (left < right)
        {
            int pivotIndex = Partition(sessions, left, right);
            Sort(sessions, left, pivotIndex - 1);
            Sort(sessions, pivotIndex + 1, right);
        }
    }

    private static int Partition(List<Session> sessions, int left, int right)
    {
        Session pivot = sessions[right];
        int i = left - 1;

        for (int j = left; j < right; j++)
        {
            if (string.Compare(sessions[j].UserName, pivot.UserName, StringComparison.Ordinal) < 0)
            {
                i++;
                Swap(sessions, i, j);
            }
        }

        Swap(sessions, i + 1, right);
        return i + 1;
    }

    private static void Swap(List<Session> sessions, int i, int j)
    {
        Session temp = sessions[i];
        sessions[i] = sessions[j];
        sessions[j] = temp;
    }
}
public class BinarySearch
{
    public static int Search(List<Session> sessions, string userName)
    {
        int left = 0;
        int right = sessions.Count - 1;

        while (left <= right)
        {
            int mid = (left + right) / 2;
            int comparison = string.Compare(sessions[mid].UserName, userName, StringComparison.Ordinal);

            if (comparison == 0)
            {
                return mid; // Found
            }
            else if (comparison < 0)
            {
                left = mid + 1; // Search right half
            }
            else
            {
                right = mid - 1; // Search left half
            }
        }

        return -1; // Not found
    }
}
