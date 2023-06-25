namespace Apresentacao.Models.PatrimonyDashboard
{
    public class Graphics
    {
        public List<string> Labels { get; set; } = new();
        public List<int> Data { get; set; } = new();
        public List<string> BackGroundColors { get; set; } = new List<string>() { "#f56954", "#00a65a", "#f39c12", "#00c0ef", "#e7a612" };

       

        public Graphics(int dataCount, List<string> labels, List<int> data)
        {
            this.Labels = labels;
            this.Data = data;
            var random = new Random();
            if (dataCount > BackGroundColors.Count)
            {
                int extra = dataCount - BackGroundColors.Count;
                for (int i = 0; i < extra; i++)
                {
                    var newColor = String.Format("#{0:X6}", random.Next(0x1000000));
                    if (BackGroundColors.Any(c => c == newColor))
                        continue;
                    this.BackGroundColors.Add(newColor);
                }

            }
            
        }
    }

}
