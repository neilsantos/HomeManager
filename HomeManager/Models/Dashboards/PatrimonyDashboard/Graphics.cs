namespace Apresentacao.Models.Dashboards.PatrimonyDashboard
{
    public class Graphics
    {
        public List<string> Labels { get; set; } = new();
        public List<double> Data { get; set; } = new();
        public List<string> BackGroundColors { get; set; } = new List<string>() { "#f56954", "#00a65a", "#f39c12", "#00c0ef", "#e7a612", "#7740c0", "#6ac971", "#18d2c0" };



        public Graphics(int labelsCount, List<string> labels, List<double> data)
        {
            Labels = labels;
            Data = data;
            var random = new Random();

            if (labelsCount > BackGroundColors.Count)
            {
                int extra = labelsCount - BackGroundColors.Count;
                for (int i = 0; i < extra; i++)
                {
                    var newColor = string.Format("#{0:X6}", random.Next(0x1000000));
                    if (BackGroundColors.Any(c => c == newColor))
                        continue;
                    BackGroundColors.Add(newColor);
                }
            }

        }
        
    }

}
