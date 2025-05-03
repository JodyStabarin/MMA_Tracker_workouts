using Microsoft.Data.Sql;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using OxyPlot;
using OxyPlot.Axes;
using OxyPlot.Series;
using OxyPlot.WindowsForms;
using System.Windows.Forms;
namespace MMA_Tracker
{
	public partial class Form1 : Form
	{
		string connString = Config.GetConnectionString("DefaultConnection");

		private int _Duration;
		private string _Type;
		private string _Intensity;
		private string _Notes;

		private PlotView plotView;
		public Form1()
		{
			InitializeComponent();

			plotView = new PlotView
			{
				Dock = DockStyle.Fill,
			};

			this.Controls.Add(plotView);
		}

		private void Form1_Load(object sender, EventArgs e)
		{
			comboBoxLanguages.Items.AddRange("English", "Italiano");
			comboBoxLanguages.SelectedIndex = 0;
			DataGriedViewRefresh();
			InitializeGraphDuration();
			InitializeGraphType();
			InitializeGraphIntensity();
			CharProgress.Visible = false;
			ChartType.Visible = false;
			ChartIntensity.Visible = false;
			ButtonReport.Visible = false;
			ButtonLogWorkout.BorderRadius = 10;
			comboBoxDuration.Items.AddRange("15", "30", "45", "60", "75", "90", "105", "120");
			comboBoxChart.SelectedIndex = 0;
		}

		private void ButtonLogWorkout_Click(object sender, EventArgs e)
		{
			DataGriedViewHistory.Rows.Clear();
			try
			{
				_Duration = int.Parse(comboBoxDuration.Text);
				_Type = comboBoxType.Text;
				_Intensity = comboBoxIntensity.Text;
				_Notes = TextBoxNotes.Text;


				using (SqlConnection conn = new SqlConnection(connString))
				{
					conn.Open();
					SqlCommand cmd = new SqlCommand("INSERT INTO Data (Date, Duration, Type, Intensity, Notes) VALUES (@Date, @Duration, @Type, @Intensity, @Notes)", conn);
					cmd.Parameters.AddWithValue("@Date", DateTime.Now);
					cmd.Parameters.AddWithValue("@Duration", _Duration);
					cmd.Parameters.AddWithValue("@Type", _Type);
					cmd.Parameters.AddWithValue("@Intensity", _Intensity);
					cmd.Parameters.AddWithValue("@Notes", _Notes);
					cmd.ExecuteNonQuery();
				}

				DataGriedViewRefresh();
				InitializeGraphDuration();
				InitializeGraphType();
				InitializeGraphIntensity();
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}
		public void DataGriedViewRefresh()
		{
			try
			{
				using (SqlConnection conn = new SqlConnection(connString))
				{
					conn.Open();
					SqlCommand cmd = new SqlCommand("SELECT * FROM Data ORDER BY Date DESC", conn);
					SqlDataReader reader = cmd.ExecuteReader();
					while (reader.Read())
					{
						DataGriedViewHistory.Rows.Add(
							reader["Id"].ToString(),
							reader["Date"].ToString(),
							reader["Duration"].ToString(),
							reader["Type"].ToString(),
							reader["Intensity"].ToString(),
							reader["Notes"].ToString()
						);
					}
					reader.Close();
				}
				DataGriedViewHistory.Refresh();
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);

			}
		}
		private void InitializeGraphDuration()
		{
			var model = new PlotModel { Title = "Training Duration" };

			var serie = new LineSeries
			{
				Title = "Duration",
				MarkerType = MarkerType.Circle,
				MarkerSize = 4,
				MarkerFill = OxyColors.SkyBlue
			};
			DateTime date;
			int duration;
			try
			{
				using (SqlConnection conn = new SqlConnection(connString))
				{
					conn.Open();
					SqlCommand cmd = new SqlCommand("SELECT * FROM Data ORDER BY Date DESC", conn);
					SqlDataReader reader = cmd.ExecuteReader();
					while (reader.Read())
					{
						date = reader.GetDateTime(reader.GetOrdinal("Date"));
						duration = reader.GetInt32(reader.GetOrdinal("Duration"));

						serie.Points.Add(new DataPoint(DateTimeAxis.ToDouble(date), duration));
					}

					reader.Close();
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}

			model.Series.Add(serie);

			model.Axes.Add(new DateTimeAxis
			{
				Position = AxisPosition.Bottom,
				StringFormat = "dd/MM",
				Title = "Date"
			});

			model.Axes.Add(new LinearAxis
			{
				Position = AxisPosition.Left,
				Title = "Duration (min)"
			});
			CharProgress.Model = model;




		}
		private Dictionary<string, int> typeCountsType = new Dictionary<string, int>();
		private void InitializeGraphType()
		{
			var model = new PlotModel { Title = "Workout Types" };

			var categoryAxis = new CategoryAxis { Position = AxisPosition.Left, Title = "Type" };
			var valueAxis = new LinearAxis
			{
				Position = AxisPosition.Bottom,
				Title = "Count",
				Minimum = 0,
				MajorStep = 1,
				MinorStep = 1,
				AbsoluteMinimum = 0,
				StringFormat = "0"
			};


			var series = new BarSeries { Title = "Sessions", FillColor = OxyColors.SkyBlue };

			typeCountsType.Clear();
			try
			{
				using (SqlConnection conn = new SqlConnection(connString))
				{
					conn.Open();
					var cmd = new SqlCommand("SELECT * FROM Data ORDER BY Date DESC", conn);
					var reader = cmd.ExecuteReader();

					while (reader.Read())
					{
						string type = reader.GetString(reader.GetOrdinal("Type"));
						if (typeCountsType.ContainsKey(type))
							typeCountsType[type]++;
						else
							typeCountsType[type] = 1;
					}

					reader.Close();
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}

			foreach (var kvp in typeCountsType)
			{
				categoryAxis.Labels.Add(kvp.Key);
				series.Items.Add(new BarItem { Value = kvp.Value });
			}

			model.Axes.Add(categoryAxis);
			model.Axes.Add(valueAxis);
			model.Series.Add(series);

			ChartType.Model = model;
		}

		private Dictionary<string, int> typeCountsIntensity = new Dictionary<string, int>();
		private void InitializeGraphIntensity()
		{
			var model = new PlotModel { Title = "Intensity Types" };

			var categoryAxis = new CategoryAxis { Position = AxisPosition.Left, Title = "Intensity" };

			var valueAxis = new LinearAxis
			{
				Position = AxisPosition.Bottom,
				Title = "Count",
				Minimum = 0,
				MajorStep = 1,
				MinorStep = 1,
				AbsoluteMinimum = 0,
				StringFormat = "0"
			};

			var series = new BarSeries { Title = "Intensity", FillColor = OxyColors.SkyBlue };

			typeCountsIntensity.Clear();
			try
			{
				using (SqlConnection conn = new SqlConnection(connString))
				{
					conn.Open();
					var cmd = new SqlCommand("SELECT * FROM Data ORDER BY Date DESC", conn);
					var reader = cmd.ExecuteReader();

					while (reader.Read())
					{
						string intensity = reader.GetString(reader.GetOrdinal("Intensity"));
						if (typeCountsIntensity.ContainsKey(intensity))
							typeCountsIntensity[intensity]++;
						else
							typeCountsIntensity[intensity] = 1;
					}

					reader.Close();
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}

			foreach (var kvp in typeCountsIntensity)
			{
				categoryAxis.Labels.Add(kvp.Key);
				series.Items.Add(new BarItem { Value = kvp.Value });
			}

			model.Axes.Add(categoryAxis);
			model.Axes.Add(valueAxis);
			model.Series.Add(series);

			ChartIntensity.Model = model;
		}


		private void switchteme_CheckedChanged(object sender, EventArgs e)
		{

		}

		private void comboBoxChart_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (comboBoxChart.SelectedIndex == 0)
			{
				ChartType.Visible = false;
				CharProgress.Visible = true;
				ChartIntensity.Visible = false;
				ButtonReport.Visible = false;
			}
			if (comboBoxChart.SelectedIndex == 1)
			{
				CharProgress.Visible = false;
				ChartIntensity.Visible = false;
				ChartType.Visible = true;
				ButtonReport.Visible = true;
			}
			if (comboBoxChart.SelectedIndex == 2)
			{
				CharProgress.Visible = false;
				ChartType.Visible = false;
				ChartIntensity.Visible = true;
				ButtonReport.Visible = true;
			}
		}

		private void DataGriedViewHistory_CellContentClick(object sender, DataGridViewCellEventArgs e)
		{
			if (e.ColumnIndex == DataGriedViewHistory.Columns["Delete"].Index && e.RowIndex >= 0)
			{
				int id = Convert.ToInt32(DataGriedViewHistory.Rows[e.RowIndex].Cells["Id"].Value);
				try
				{
					using (SqlConnection conn = new SqlConnection(connString))
					{
						conn.Open();
						SqlCommand cmd = new SqlCommand("DELETE FROM Data WHERE Id = @Id", conn);
						cmd.Parameters.AddWithValue("@Id", id);
						cmd.ExecuteNonQuery();

					}
				}
				catch (Exception ex)
				{
					MessageBox.Show(ex.Message);
				}
				DataGriedViewHistory.Rows.Clear();
				DataGriedViewRefresh();
				InitializeGraphIntensity();
				InitializeGraphDuration();
				InitializeGraphType();
			}
			if (e.ColumnIndex == DataGriedViewHistory.Columns["Notes"].Index && e.RowIndex >= 0)
			{
				MessageBox.Show(DataGriedViewHistory.Rows[e.RowIndex].Cells["Notes"].Value.ToString());
			}
		}

		private void ButtonReport_Click(object sender, EventArgs e)
		{
			if (comboBoxChart.SelectedIndex == 0)
			{

			}
			if (comboBoxChart.SelectedIndex == 1)
			{
				if (comboBoxLanguages.SelectedIndex == 0)
				{
					if (typeCountsType.Count == 0)
					{
						MessageBox.Show("No data available for report.");
						return;
					}

					var MaxType = typeCountsType.OrderByDescending(kvp => kvp.Value).First();

					var neglected = typeCountsType.Where(kvp => kvp.Value < 2).Select(kvp => kvp.Key).ToList();
					string messaggio = "According to the graph";
					messaggio += $"\nYou've done more {MaxType.Key.ToLower()} ({MaxType.Value} sessions).";

					if (neglected.Any())
					{
						messaggio += "\nYou overlooked it: " + string.Join(", ", neglected.Select(t => t.ToLower())) + ".";
					}

					MessageBox.Show(messaggio, "Training Report", MessageBoxButtons.OK, MessageBoxIcon.Information);
				}
				if (comboBoxLanguages.SelectedIndex == 1)
				{
					if (typeCountsType.Count == 0)
					{
						MessageBox.Show("Nessun dato disponibile per il report.");
						return;
					}

					var MaxType = typeCountsType.OrderByDescending(kvp => kvp.Value).First();

					var neglected = typeCountsType.Where(kvp => kvp.Value < 2).Select(kvp => kvp.Key).ToList();
					string messaggio = "Secondo il grafico";
					messaggio += $"\nHai fatto più {MaxType.Key.ToLower()} ({MaxType.Value} sessioni).";

					if (neglected.Any())
					{
						messaggio += "\nHai trascurato: " + string.Join(", ", neglected.Select(t => t.ToLower())) + ".";
					}

					MessageBox.Show(messaggio, "Report Allenamento", MessageBoxButtons.OK, MessageBoxIcon.Information);

				}
			}
			if (comboBoxChart.SelectedIndex == 2)
			{
				if (comboBoxLanguages.SelectedIndex == 0)
				{
					if (typeCountsIntensity.Count == 0)
					{
						MessageBox.Show("No data available for report.");
						return;
					}

					var MaxType = typeCountsIntensity.OrderByDescending(kvp => kvp.Value).First();

					var neglected = typeCountsIntensity.Where(kvp => kvp.Value < 2).Select(kvp => kvp.Key).ToList();
					string message = "According to the graph";
					message += $"\nMost of your sessions were at **{MaxType.Key.ToLower()} intensity** ({MaxType.Value} sessions).";

					if (neglected.Any())
					{
						message += "\nYou’ve done very few sessions at: " + string.Join(", ", neglected.Select(t => t.ToLower())) + ".";
					}

					MessageBox.Show(message, "Training Report", MessageBoxButtons.OK, MessageBoxIcon.Information);
				}
				if (comboBoxLanguages.SelectedIndex == 1)
				{
					if (typeCountsIntensity.Count == 0)
					{
						MessageBox.Show("Nessun dato disponibile per il report.");
						return;
					}

					var MaxType = typeCountsIntensity.OrderByDescending(kvp => kvp.Value).First();

					var neglected = typeCountsIntensity.Where(kvp => kvp.Value < 2).Select(kvp => kvp.Key).ToList();
					string message = "Secondo il grafico";
					message += $"\nLa maggior parte delle tue sessioni sono state con intensità **{MaxType.Key.ToLower()}** ({MaxType.Value} sessioni).";

					if (neglected.Any())
					{
						message += "\nHai fatto molto poche sessioni con intensità: " + string.Join(", ", neglected.Select(t => t.ToLower())) + ".";
					}

					MessageBox.Show(message, "Report Allenamento", MessageBoxButtons.OK, MessageBoxIcon.Information);

				}

			}
		}

		private void comboBoxLanguages_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (comboBoxLanguages.SelectedIndex == 0)
			{
				comboBoxIntensity.Items.Clear();
				comboBoxType.Items.Clear();
				comboBoxChart.Items.Clear();
				comboBoxType.Items.AddRange("Cardio", "Sparring", "Striking", "Grappling");
				comboBoxIntensity.Items.AddRange("Low", "Medium", "High");
				comboBoxChart.Items.AddRange("Duration", "Type", "Intensity");
				labelTrainingHistory.Text = "Training History";
				LabelLogWorkout.Text = "Log Workout";
				LabelProgress.Text = "Progress";
				LabelLanguages.Text = "Languages";
				ButtonLogWorkout.Text = "Log Workout";
				LabelDuration.Text = "Duration (min)";
				LabelType.Text = "Type";
				LabelIntensity.Text = "Intensity";
				LabelNotes.Text = "Notes";
				comboBoxChart.Refresh();
				comboBoxIntensity.Refresh();
				comboBoxType.Refresh();
				DataGriedViewHistory.Columns["Date"].HeaderText = "Date";
				DataGriedViewHistory.Columns["Duration"].HeaderText = "Duration";
				DataGriedViewHistory.Columns["Type"].HeaderText = "Type";
				DataGriedViewHistory.Columns["Intensity"].HeaderText = "Intensity";
				DataGriedViewHistory.Columns["Notes"].HeaderText = "Notes";
				DataGriedViewHistory.Columns["Delete"].HeaderText = "Delete";

			}
			if (comboBoxLanguages.SelectedIndex == 1)
			{
				comboBoxIntensity.Items.Clear();
				comboBoxType.Items.Clear();
				comboBoxChart.Items.Clear();
				comboBoxType.Items.AddRange("Cardio", "Sparring", "Striking", "Grappling");
				comboBoxIntensity.Items.AddRange("Basso", "Medio", "Alto");
				comboBoxChart.Items.AddRange("Durata", "Tipo", "Intensità");
				labelTrainingHistory.Text = "Storia allenamenti";
				LabelLogWorkout.Text = "Inserisci l'allenamento";
				LabelProgress.Text = "Progressi";
				LabelLanguages.Text = "Lingua";
				ButtonLogWorkout.Text = "Inserisci l'allenamento";
				LabelDuration.Text = "Durata (min)";
				LabelType.Text = "Tipo";
				LabelIntensity.Text = "Intensità";
				LabelNotes.Text = "Note";
				comboBoxChart.Refresh();
				comboBoxIntensity.Refresh();
				comboBoxType.Refresh();
				DataGriedViewHistory.Columns["Date"].HeaderText = "Data";
				DataGriedViewHistory.Columns["Duration"].HeaderText = "Durata";
				DataGriedViewHistory.Columns["Type"].HeaderText = "Tipo";
				DataGriedViewHistory.Columns["Intensity"].HeaderText = "Intensità";
				DataGriedViewHistory.Columns["Notes"].HeaderText = "Note";
				DataGriedViewHistory.Columns["Delete"].HeaderText = "Elimina";
			}
		}

		private void buttonRefreshData_Click(object sender, EventArgs e)
		{
			DataGriedViewRefresh();
		}
	}
}
