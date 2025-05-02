using Microsoft.Data.Sql;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using OxyPlot;
using OxyPlot.Axes;
using OxyPlot.Series;
using OxyPlot.WindowsForms;
namespace MMA_Tracker
{
	public partial class Form1 : Form
	{
		string connString = Config.GetConnectionString("DefaultConnection");

		private int _Duration;
		private string _Type;
		private string _Intensity;

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
			DataGriedViewRefresh();
			InitializeGraphDuration();
			InitializeGraphType();
			InitializeGraphIntensity();
			CharProgress.Visible = false;
			ChartType.Visible = false;
			ChartIntensity.Visible = false;
			ButtonLogWorkout.BorderRadius = 10;
			comboBoxDuration.Items.AddRange("15", "30", "45", "60", "75", "90", "105", "120");
			comboBoxType.Items.AddRange("Cardio", "Sparring", "Striking", "Grappling");
			comboBoxIntensity.Items.AddRange("Low", "Medium", "High");
			comboBoxChart.Items.AddRange("Duration", "Type", "Intensity");
		}

		private void ButtonLogWorkout_Click(object sender, EventArgs e)
		{
			DataGriedViewHistory.Rows.Clear();
			try
			{
				_Duration = int.Parse(comboBoxDuration.Text);
				_Type = comboBoxType.Text;
				_Intensity = comboBoxIntensity.Text;


				using (SqlConnection conn = new SqlConnection(connString))
				{
					conn.Open();
					SqlCommand cmd = new SqlCommand("INSERT INTO Data (Date, Duration, Type, Intensity) VALUES (@Date, @Duration, @Type, @Intensity)", conn);
					cmd.Parameters.AddWithValue("@Date", DateTime.Now);
					cmd.Parameters.AddWithValue("@Duration", _Duration);
					cmd.Parameters.AddWithValue("@Type", _Type);
					cmd.Parameters.AddWithValue("@Intensity", _Intensity);
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
						reader["Intensity"].ToString()
					);
				}
				reader.Close();
			}
			DataGriedViewHistory.Refresh();
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

			var typeCounts = new Dictionary<string, int>();

			using (SqlConnection conn = new SqlConnection(connString))
			{
				conn.Open();
				var cmd = new SqlCommand("SELECT * FROM Data ORDER BY Date DESC", conn);
				var reader = cmd.ExecuteReader();

				while (reader.Read())
				{
					string type = reader.GetString(reader.GetOrdinal("Type"));
					if (typeCounts.ContainsKey(type))
						typeCounts[type]++;
					else
						typeCounts[type] = 1;
				}

				reader.Close();
			}

			foreach (var kvp in typeCounts)
			{
				categoryAxis.Labels.Add(kvp.Key);
				series.Items.Add(new BarItem { Value = kvp.Value });
			}

			model.Axes.Add(categoryAxis);
			model.Axes.Add(valueAxis);
			model.Series.Add(series);

			ChartType.Model = model;
		}
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

			var typeCounts = new Dictionary<string, int>();

			using (SqlConnection conn = new SqlConnection(connString))
			{
				conn.Open();
				var cmd = new SqlCommand("SELECT * FROM Data ORDER BY Date DESC", conn);
				var reader = cmd.ExecuteReader();

				while (reader.Read())
				{
					string intensity = reader.GetString(reader.GetOrdinal("Intensity"));
					if (typeCounts.ContainsKey(intensity))
						typeCounts[intensity]++;
					else
						typeCounts[intensity] = 1;
				}

				reader.Close();
			}

			foreach (var kvp in typeCounts)
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
			}
			if (comboBoxChart.SelectedIndex == 1)
			{
				CharProgress.Visible = false;
				ChartIntensity.Visible = false;
				ChartType.Visible = true;
			}
			if (comboBoxChart.SelectedIndex == 2)
			{
				CharProgress.Visible = false;
				ChartType.Visible = false;
				ChartIntensity.Visible = true;
			}
		}

		private void DataGriedViewHistory_CellContentClick(object sender, DataGridViewCellEventArgs e)
		{
			if(e.ColumnIndex == DataGriedViewHistory.Columns["Delete"].Index && e.RowIndex >= 0)
			{
				int id = Convert.ToInt32(DataGriedViewHistory.Rows[e.RowIndex].Cells["Id"].Value);
				using (SqlConnection conn = new SqlConnection(connString))
				{
					conn.Open();
					SqlCommand cmd = new SqlCommand("DELETE FROM Data WHERE Id = @Id", conn);
					cmd.Parameters.AddWithValue("@Id", id);
					cmd.ExecuteNonQuery();
					
				}
				DataGriedViewHistory.Rows.Clear();
				DataGriedViewRefresh();
			}
		}
	}
}
